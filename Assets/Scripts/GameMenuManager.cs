using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;

namespace MyVRSamlple
{
    /// <summary>
    ///  게임중 메뉴 관리하는 클래스 
    /// </summary>
    public class GameMenuManager : MonoBehaviour
    {
        #region Variavles

        public GameObject gameMenu;
        public InputActionProperty showButton;

        public Transform head;
        [SerializeField]private float distance = 1.5f;

        // Drop
        public SnapTurnProvider snapTurn;
        public ContinuousTurnProvider continuousTurn;

        #endregion

        private void Update()
        {
            if (showButton.action.WasPressedThisFrame())// 이번 프레임에 눌렀나?
            {
                Toggle();


            }
        }

        void Toggle()
        {
            gameMenu.SetActive(!gameMenu.activeSelf);

            // show 설정
            if(gameObject.activeSelf)
            {
                gameMenu.transform.position = head.position + 
                    new Vector3(head.forward.x, 0f, head.forward.z).normalized*distance;

                gameMenu.transform.LookAt(new Vector3(head.position.x,gameMenu.transform.position.y,
                                                                                    head.position.z));
                gameMenu.transform.forward *= -1;
                
            }

        }

        // drop 메뉴 선택 
        public void SetTurnTypeFromIndex(int index)
        {
            switch(index)
            {
                case 0:
                    snapTurn.enabled = false;
                    continuousTurn.enabled = true;
                    break;

               case 1:
                    snapTurn.enabled = true;
                    continuousTurn.enabled = false;
                    break;
            }
        }
        // Quit 버튼
        public void Quit()
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }

    }
}