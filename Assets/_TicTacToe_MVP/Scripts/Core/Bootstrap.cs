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

        private Model _model;
        private Presenter _presenter;

        private void Awake()
        {
            _model = new Model(_height, _width, SignType.Circle);
            _presenter = new Presenter(_model, _view);
        }

        private void OnEnable() => _presenter.Subscribe();

        private void OnDisable() => _presenter.Unsubscribe();
    }
}