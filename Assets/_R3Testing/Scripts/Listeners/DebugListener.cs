using UniRx;
using UnityEngine;

namespace R3Testing
{
    public class DebugListener : MonoBehaviour
    {
        [SerializeField] private DebugSubject _subject;

        private readonly CompositeDisposable _disposable = new();

        private void OnEnable()
        {
            _subject.DebugEvent
                .Subscribe(_ => OnClick())
                .AddTo(_disposable);
        }

        private void OnDestroy() => 
            _disposable.Dispose();

        private void OnClick() => Debug.Log("Debug event");
    }
}
