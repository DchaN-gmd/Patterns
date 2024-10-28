using MVP.Extensions;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace R3Testing
{
    public class CompleteSubject : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private int _maxCount;

        public readonly Subject<int> IntEvent = new();

        private int _counter = 0;

        private void OnEnable() =>
            _button.AddListener(OnClick);

        private void OnDisable() =>
            _button.AddListener(OnClick);

        private void OnClick()
        {
            _counter++;
            IntEvent.OnNext(_counter);

            if(_counter >= _maxCount) 
                IntEvent.OnCompleted();
        }
    }
}