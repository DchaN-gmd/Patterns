using System;
using TMPro;
using UniRx;
using UnityEngine;

namespace R3Testing
{
    public class DelayListener : MonoBehaviour
    {
        [SerializeField] private DebugSubject _subject;
        [SerializeField] private float _delay;
        [SerializeField] private TMP_Text _text;

        private readonly CompositeDisposable _disposable = new();

        private void OnEnable()
        {
            _subject.DebugEvent
                .Delay(TimeSpan.FromSeconds(_delay))
                .Subscribe(_ => OnClick())
                .AddTo(_disposable);
        }

        private void OnDestroy() =>
            _disposable.Dispose();

        private void OnClick() =>
            _text.text = "Ready";
    }
}