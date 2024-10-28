using UnityEngine;

namespace StateMachine
{
    public class NotificationPresenter : MonoBehaviour, IPresenter
    {
        [SerializeField] private GameObject[] _objectsToEnable;
        [SerializeField] private GameObject[] _objectsToDisable;

        public void Enable()
        {
            foreach (var objectToEnable in _objectsToEnable)
            {
                objectToEnable.SetActive(true);
            }

            foreach (var objectToDisable in _objectsToDisable)
            {
                objectToDisable.SetActive(false);
            }
        }

        public void Disable()
        {
            foreach (var objectToEnable in _objectsToEnable)
            {
                objectToEnable.SetActive(false);
            }

            foreach (var objectToDisable in _objectsToDisable)
            {
                objectToDisable.SetActive(true);
            }
        }
    }
}