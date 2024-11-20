using UnityEngine;

namespace MyFps
{
    public class XRPickUpPistol : GrabInteractableTwoAttach
    {
        #region Variables
        //Action
        public GameObject arrow;

        public GameObject enemyTrigger;
        public GameObject ammoBox;
        public AmmoUI ammoUI;
        #endregion

        protected override void DoAction()
        {
            arrow.SetActive(false);
            ammoBox.SetActive(true);
            enemyTrigger.SetActive(true);

            //����ȹ��
            PlayerStats.Instance.SetHasGun(true);
            ammoUI.ShowMenuUI();

            //  Destroy(gameObject);
            
        }
    }
}
