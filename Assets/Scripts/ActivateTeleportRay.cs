using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace MyVrSample
{
    /// <summary>
    /// Teleport Ray�� �����ϴ� Ŭ����
    /// </summary>
    public class ActivateTeleportRay : MonoBehaviour
    {
        #region Variables
        public GameObject leftTeleportRay;          // �ڷ���Ʈ Ray ������Ʈ
        public GameObject rightTeleportRay;         // �ڷ���Ʈ ������ Ray ������Ʈ

        public InputActionProperty leftActivate;    // ���� ��Ʈ�ѷ��� activate �Է�
        public InputActionProperty rightActivate;   // ������ ��Ʈ�ѷ��� activate �Է�

        public XRRayInteractor leftGrabLay;         // ���� �ߺ� �ɽ�Ʈ ���� 
        public XRRayInteractor rightGrabLay;
        #endregion

        void Update()
        {
            float leftActivateValue = leftActivate.action.ReadValue<float>();
            float rightActivateValue = rightActivate.action.ReadValue<float>();

            bool isLeftRayHovering = leftGrabLay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal,
                out int leftNumber, out bool leftVailed);

            bool isRightRayHovering = rightGrabLay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal,
                out int rightNumber, out bool rightVailed);

            leftTeleportRay.SetActive(!isLeftRayHovering && leftActivateValue > 0.1f);
            rightTeleportRay.SetActive(!isLeftRayHovering && rightActivateValue > 0.1f);
        }
    }
}