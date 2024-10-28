namespace StateMachine
{
    public abstract class BasePresenterState<TInitializer> : IState<TInitializer>, IEnterable, IExitable
    {
        protected readonly IPresenter[] _presenters;

        public TInitializer Initializer { get; }

        public BasePresenterState(TInitializer initializer, params IPresenter[] presenters)
        {
            Initializer = initializer;
            _presenters = presenters;
        }

        public virtual void Enter()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Enable();
            }
        }

        public virtual void Exit()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Disable();
            }
        }
    }
}