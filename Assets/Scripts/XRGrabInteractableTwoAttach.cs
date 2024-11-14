using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyVRSamlple
{
    /// <summary>
    ///  �ΰ��� attach Point ����
    /// </summary>

    public class XRGrabInteractableTwoAttach :XRGrabInteractable
    {
        #region

        public Transform leftAttachTransform;
        public Transform rightAttachTransform;

        #endregion

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            // �ΰ��� attach Point�� ��� �տ� ���� �����ؼ� ����
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