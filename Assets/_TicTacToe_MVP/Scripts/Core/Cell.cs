using MVP.Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MVP
{
    [RequireComponent(typeof(Button))]
    public sealed class Cell : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Cell> _clicked;
        [SerializeField] private Image _image;

        private SignType _sign = SignType.None;
        private Button _button;

        public SignType Sign => _sign;

        public event UnityAction<Cell> Clicked
        {
            add => _clicked.AddListener(value);
            remove => _clicked.AddListener(value);
        }

        private void Awake() =>
            _button = GetComponent<Button>();

        private void OnEnable() =>
            _button.AddListener(OnClicked);

        private void OnDisable() =>
            _button.RemoveListener(OnClicked);

        public void SetSign(SignType sign)
        {
            if (Sign != SignType.None) return;

            _sign = sign;
        }

        public void SetSprite(Sprite sprite) =>
            _image.sprite = sprite;

        private void OnClicked() =>
            _clicked.Invoke(this);
    }
}
