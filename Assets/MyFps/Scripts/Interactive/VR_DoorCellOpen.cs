using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyFps
{
    public class VR_DoorCellOpen : Interactive
    {
        #region Variables
        // Action
        private Animator animator;
        private Collider m_Collider;
        public AudioSource audioSource;

        // XR Interaction
        private XRSimpleInteractable grabInteractable;
        #endregion

        private void Start()
        {
            animator = GetComponent<Animator>();
            m_Collider = GetComponent<BoxCollider>();

            // XRGrabInteractable 추가
            grabInteractable = gameObject.AddComponent<XRSimpleInteractable>();
            grabInteractable.activated.AddListener(OnActivate); // Activate 이벤트 연결
        }

        private void OnDestroy()
        {
            // 이벤트 리스너 해제
            if (grabInteractable != null)
                grabInteractable.activated.RemoveListener(OnActivate);
        }

        private void OnActivate(ActivateEventArgs args)
        {
            // Activate 버튼이 눌리면 DoAction 호출
            DoAction();
        }

        protected override void DoAction()
        {
            animator.SetBool("IsOpen", true); // 문 열림 애니메이션 실행
            m_Collider.enabled = false; // 충돌 비활성화
            if (audioSource != null)
            {
                audioSource.Play(); // 오디오 재생
            }
        }
    }
}
