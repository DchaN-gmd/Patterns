using UnityEngine;

namespace MVP
{
    public class Bootstrap : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField, Min(0)] private int _height;
        [SerializeField, Min(1)] private int _width;

        [Header("References")]
        [SerializeField] private DefaultView _view;

        private void Awake()
        {
            var model = new DefaultModel(_view, _height, _width, SignType.Circle);
            var presenter = new DefaultPresenter(model);

            _view.Init(presenter);
        }
    }
}