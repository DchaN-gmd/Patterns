using UnityEngine;

namespace StateMachine
{
    public class NotificationState : BasePresenterState<UIStateMachineInitialazer>
    {
        public NotificationState(UIStateMachineInitialazer initializer, params IPresenter[] presenters) : base(initializer, presenters) { }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Start notification");
        }

        public override void Exit()
        {
            base.Exit();

            Debug.Log("Exit notification");
        }
    }
}