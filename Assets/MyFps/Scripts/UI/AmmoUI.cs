using UnityEngine;
using System.Collections;

namespace MyFps
{
    public class AmmoUI : WorldMenu
    {
        #region Variables

        [SerializeField]private float showDelay = 2f;

        #endregion

        // ammoUI�����ְ� 2�� �Ŀ� �������
        public void ShowAmmo()
        {
            StartCoroutine(ShowUI());
        }

        IEnumerator ShowUI()
        {
            ShowMenuUI(PlayerStats.Instance.AmmoCount.ToString());
            yield return new WaitForSeconds(showDelay);
            HideMenuUI();
        }


    }
}