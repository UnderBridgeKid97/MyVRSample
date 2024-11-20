using TMPro;
using UnityEngine;

namespace MyFps
{ 
public class WorldMenu: MonoBehaviour
{
        #region
        public GameObject WorldMenuUI;
        public TextMeshProUGUI textBox;

        private Transform head;
        private float distance;
        [SerializeField]private float offset = 1.0f;
        #endregion

        protected virtual void Start()
        {
            // 참조
            head = Camera.main.transform;
        }

        protected virtual void Update()
        {
            distance = PlayerCasting.distanceFromTarget;
        }

        public void ShowMenuUI(string sequenceText="")
        {
            WorldMenuUI.SetActive(true);

            //show 설정
            
                distance = (distance < offset) ? distance - 0.05f : offset;
                WorldMenuUI.transform.position = head.position + new Vector3(head.forward.x, 0f, head.forward.z).normalized * distance;
                WorldMenuUI.transform.LookAt(new Vector3(head.position.x, WorldMenuUI.transform.position.y, head.position.z));
                WorldMenuUI.transform.forward *= -1;

                // text 설정 
                if(textBox)
                {
                    textBox.text = sequenceText;
                }
        }

        public void HideMenuUI()
        {
            WorldMenuUI.SetActive(true);
            textBox.text = "";
        }
    }
}
