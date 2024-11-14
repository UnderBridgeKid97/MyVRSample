using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyVRSamlple
{
    /// <summary>
    ///  두개의 attach Point 구현
    /// </summary>

    public class XRGrabInteractableTwoAttach :XRGrabInteractable
    {
        #region

        public Transform leftAttachTransform;
        public Transform rightAttachTransform;

        #endregion

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            // 두개의 attach Point를 잡는 손에 따라 구분해서 적용
            if(args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = leftAttachTransform;
            }
            else if (args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform =rightAttachTransform;
            }


                base.OnSelectEntered(args);

        }
    }
}