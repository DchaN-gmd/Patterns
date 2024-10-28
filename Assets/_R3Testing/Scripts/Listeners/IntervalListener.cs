using System;
using TMPro;
using UniRx;
using UnityEngine;

namespace R3Testing
{
    public class IntervalListener : MonoBehaviour
    {
        [SerializeField] private DebugSubject _subject;
        [SerializeField] private TMP_Text _text;

        private readonly CompositeDisposable _disposable = new();

        private int _seconds;

        private void OnEnable()
        {
            _subject.DebugEvent
                .Subscribe(_ => 
                    Observable
                        .Interval(TimeSpan.FromSeconds(1))
                        .Subscribe(_ => OnClick()))
                .AddTo(_disposable);
        }

        private void OnDestroy() =>
            _disposable.Dispose();

        private void OnClick()
        {
            _seconds++;
            _text.text = _seconds.ToString();
        }
            
    }
}