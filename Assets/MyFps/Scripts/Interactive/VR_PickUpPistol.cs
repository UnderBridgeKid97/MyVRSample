using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyFps
{
    public class VR_PickUpPistol : Interactive
    {
        #region Variables
        //Action
        public GameObject arrow;

        public GameObject enemyTrigger;
        public GameObject ammoBox;
        public GameObject ammoUI;

        private XRSimpleInteractable grabInteractable;    // plus
        #endregion

        #region plus
        private void Start()
        {
            // XRGrabInteractable 추가
            grabInteractable = gameObject.AddComponent<XRSimpleInteractable>();
            grabInteractable.selectEntered.AddListener(OnSelect); // Select 이벤트 연결
        }

        private void OnSelect(SelectEnterEventArgs args)
        {
            // Select 이벤트가 발생하면 DoAction 호출
            DoAction();
        }
        #endregion

        protected override void DoAction()
        {
            arrow.SetActive(false);
            ammoBox.SetActive(true);
            enemyTrigger.SetActive(true);

            //무기획득
            PlayerStats.Instance.SetHasGun(true);
            ammoUI.SetActive(true);

            Destroy(gameObject);
        }
    }
}