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
            // XRGrabInteractable �߰�
            grabInteractable = gameObject.AddComponent<XRSimpleInteractable>();
            grabInteractable.selectEntered.AddListener(OnSelect); // Select �̺�Ʈ ����
        }

        private void OnSelect(SelectEnterEventArgs args)
        {
            // Select �̺�Ʈ�� �߻��ϸ� DoAction ȣ��
            DoAction();
        }
        #endregion

        protected override void DoAction()
        {
            arrow.SetActive(false);
            ammoBox.SetActive(true);
            enemyTrigger.SetActive(true);

            //����ȹ��
            PlayerStats.Instance.SetHasGun(true);
            ammoUI.SetActive(true);

            Destroy(gameObject);
        }
    }
}