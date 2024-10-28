using MVP.Extensions;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace R3Testing
{
    public class DebugSubject : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public readonly Subject<Unit> DebugEvent = new();

        private void OnEnable() => 
            _button.AddListener(() => DebugEvent.OnNext(Unit.Default));

        private void OnDisable() => 
            _button.AddListener(() => DebugEvent.OnNext(Unit.Default));
    }
}
