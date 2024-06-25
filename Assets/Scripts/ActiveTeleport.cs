using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class ActiveTeleport : MonoBehaviour
    {
        public GameObject leftRay, rightRay;

        public InputActionProperty leftAction, rightAction;

        private void Update()
        {
            leftRay.SetActive(leftAction.action.IsPressed());
            rightRay.SetActive(rightAction.action.IsPressed());
        }

        public void ChangeActive(GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
