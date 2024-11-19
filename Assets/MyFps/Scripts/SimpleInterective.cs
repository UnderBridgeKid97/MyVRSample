using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

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
            theDistance = PlayerCasting.distanceFromTarget;


        }

        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            if(unInteractive)
            {
                return;
            }
            base.OnHoverEntered(args);
             ShowActionUI();

          
        }

        protected override void OnHoverExited(HoverExitEventArgs args)
        {
            base.OnHoverExited(args);
             HideActionUI();
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);

            HideActionUI();

            // action
            DoAction();

        }


        void ShowActionUI()
        {
            actionUI.SetActive(true);
            actionUI.transform.position = head.position
                + new Vector3(head.forward.x, 0f, head.forward.z).normalized * theDistance;
            actionUI.transform.LookAt(new Vector3(head.position.x,actionUI.transform.position.y,head.forward.z));

            actionUI.transform.forward *= -1;
            actionText.text = action;
        }
    

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
        }
    }
}