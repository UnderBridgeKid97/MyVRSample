using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace MyVRSamlple
{
    /// <summary>
    ///  오브젝트를 잡을 때 오프셋 위치 설정
    /// </summary>
    public class XRGrabInteracterbleOffSet : XRGrabInteractable
    {
        #region Variables

        private GameObject attachPoint;

        private Vector3 initialLocalPosition;
        private Quaternion initialLocalRotation;
        #endregion

        private void Start()
        {
            if(attachTransform == null)
            {
                attachPoint = new GameObject("OffSet Grab Pivot");
                attachPoint.transform.SetParent(transform, false);
                attachTransform = attachPoint.transform;
            }
            else
            {
                initialLocalPosition = attachTransform.localPosition;
                initialLocalRotation = attachTransform.localRotation;
            }
        }

       /* protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            if (args.interactorObject is XRDirectInteractor)
            {
                attachTransform.position = args.interactorObject.transform.position;
                attachTransform.rotation = args.interactorObject.transform.rotation;
            }
            else
            {
                attachTransform.localPosition = initialLocalPosition;
                attachTransform.localRotation = initialLocalRotation;
            }
            base.OnSelectEntered(args);

        }*/
        protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        attachTransform.position = args.interactorObject.transform.position;
        attachTransform.rotation = args.interactorObject.transform.rotation;

        base.OnSelectEntering(args);
    }

}
}