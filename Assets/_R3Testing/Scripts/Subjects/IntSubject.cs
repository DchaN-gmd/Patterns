using MVP.Extensions;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace R3Testing
{
    public class IntSubject : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public readonly Subject<int> IntEvent = new();

        private int _counter = 0;
        
        private void OnEnable() =>
            _button.AddListener(OnClick);

        private void OnDisable() =>
            _button.AddListener(OnClick);

        private void OnClick()
        {
            _counter++;
            _button.AddListener(() => IntEvent.OnNext(_counter));
        }
    }
}