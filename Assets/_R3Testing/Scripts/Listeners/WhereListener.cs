using TMPro;
using UniRx;
using UnityEngine;

namespace R3Testing
{
    public class WhereListener : MonoBehaviour
    {
        [SerializeField] private IntSubject _subject;
        [SerializeField] private TMP_Text _text;

        private readonly CompositeDisposable _disposable = new();

        private void OnEnable()
        {
            _subject.IntEvent
                .Where(counter => counter % 2 == 0)
                .Subscribe(OnClick)
                .AddTo(_disposable);
        }

        private void OnDestroy() =>
            _disposable.Dispose();

        private void OnClick(int counter) => 
            _text.text = counter.ToString();
    }
}