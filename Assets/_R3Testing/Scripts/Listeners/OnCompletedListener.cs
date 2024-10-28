using TMPro;
using UniRx;
using UnityEngine;

namespace R3Testing
{
    public class OnCompletedListener : MonoBehaviour
    {
        [SerializeField] private CompleteSubject _subject;
        [SerializeField] private TMP_Text _text;

        private void OnEnable()
        {
            _subject.IntEvent
                .Subscribe(OnClick)
                .AddTo(this);
        }

        private void OnClick(int counter) =>
            _text.text = counter.ToString();
    }
}