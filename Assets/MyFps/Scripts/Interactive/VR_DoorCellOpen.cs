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

            // XRGrabInteractable �߰�
            grabInteractable = gameObject.AddComponent<XRSimpleInteractable>();
            grabInteractable.activated.AddListener(OnActivate); // Activate �̺�Ʈ ����
        }

        private void OnDestroy()
        {
            // �̺�Ʈ ������ ����
            if (grabInteractable != null)
                grabInteractable.activated.RemoveListener(OnActivate);
        }

        private void OnActivate(ActivateEventArgs args)
        {
            // Activate ��ư�� ������ DoAction ȣ��
            DoAction();
        }

        protected override void DoAction()
        {
            animator.SetBool("IsOpen", true); // �� ���� �ִϸ��̼� ����
            m_Collider.enabled = false; // �浹 ��Ȱ��ȭ
            if (audioSource != null)
            {
                audioSource.Play(); // ����� ���
            }
        }
    }
}
