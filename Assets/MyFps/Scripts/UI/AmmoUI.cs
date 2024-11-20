using UnityEngine;
using System.Collections;

namespace MyFps
{
    public class AmmoUI : WorldMenu
    {
        #region Variables

        [SerializeField]private float showDelay = 2f;

        #endregion

        // ammoUI보여주고 2초 후에 사라진다
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