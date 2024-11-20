using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace MyFps
{
    public abstract class SimpleInterective :XRSimpleInteractable
    {
        protected abstract void DoAction();

        #region
        private float theDistance;

        // action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Action Text";
        [SerializeField]private float offset = 0f;

        private bool isHover = false;               //  현재 가르키고있는가

        // true면 인터렉티브 기능 정지
        protected bool unInteractive = false;

        // 카메라
        private Transform head;
        #endregion

        protected virtual void Start()
        {
            // 참조
            head = Camera.main.transform;
        }

        protected virtual void Update()
        {
            if (unInteractive)
                return;

            //  theDistance = PlayerCasting.distanceFromTarget;
            theDistance = GetDistanceToHead();
        }

        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            if (unInteractive)
                return;

            base.OnHoverEntered(args);

            if (args.interactorObject is XRDirectInteractor)
            {
              //  ShowActionUI();
            }
           // else
            {
                if (theDistance < 2.0f)
                {
                   // isHover = true;
                      ShowActionUI();
                }
            }
        }

        protected override void OnHoverExited(HoverExitEventArgs args)
        {
            base.OnHoverExited(args);
           // isHover = false;
              HideActionUI();
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {

            if (unInteractive)
                return;

            base.OnSelectEntered(args);

            if (theDistance < 2.0f)
            {
               unInteractive = true;

                HideActionUI();

                // action
                DoAction();
            }
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);
            unInteractive = false;
        }

        void ShowActionUI()
        {
            if (isHover)
                return;

            isHover = true;

            actionUI.SetActive(true);
            actionUI.transform.position = head.position
                + new Vector3(head.forward.x, 0f, head.forward.z).normalized * (theDistance - offset);
            actionUI.transform.LookAt(new Vector3(head.position.x, actionUI.transform.position.y, head.forward.z));
            actionUI.transform.forward *= -1;

            actionText.text = action;
        }


        void HideActionUI()
        {
            if (!isHover)
                return;

            isHover = false;

            actionUI.SetActive(false);
            actionText.text = "";
        }

        float GetDistanceToHead()
        {
            float distance = 0f;
            Vector3 position = new Vector3(transform.position.x, head.position.y, transform.position.z);
            distance = Vector3.Distance(position, head.position);

            return distance;
        }
    }
}