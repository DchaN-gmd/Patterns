using UnityEngine;

namespace StateMachine
{
    public class PauseState : BasePresenterState<UIStateMachineInitialazer>
    {
        public UIStateMachineInitialazer Initializer { get; }

        public PauseState(UIStateMachineInitialazer initializer, params IPresenter[] presenters) : base(initializer, presenters) { }


        public override void Enter()
        {
            base.Enter();

            Debug.Log("Start pause");
        }

        public override void Exit()
        {
            base.Exit();

            Debug.Log("Exit pause");
        }
    }
}