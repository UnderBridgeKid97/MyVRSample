using UnityEngine;
using UnityEngine.InputSystem;

namespace MyVRSamlple
{
public class AnimatorHandsOnInput : MonoBehaviour
{
        #region Variables

        private Animator handAnimator;

        // 인풋 입력값 처리
        public InputActionProperty pinchAnimationAction;
        public InputActionProperty gripAnimationAction;

        #endregion
   void Start()
   {
        // 참조
        handAnimator = GetComponent<Animator>();
   }

    void Update()
    {
        float triggerValue =  pinchAnimationAction.action.ReadValue<float>();
            float gripValue = gripAnimationAction.action.ReadValue<float>();
            //   Debug.Log($"triggerValue: {triggerValue}");

            handAnimator.SetFloat("Trigger",triggerValue);
            handAnimator.SetFloat("Grip", gripValue);
    }
}
}