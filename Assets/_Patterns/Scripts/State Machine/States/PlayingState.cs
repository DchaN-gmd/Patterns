using UnityEngine;

namespace StateMachine
{
    public class PlayingState : BasePresenterState<UIStateMachineInitialazer>
    {
        public PlayingState(UIStateMachineInitialazer initializer, params IPresenter[] presenters) : base(initializer, presenters) { }
        
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Start Playing");
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Playing Exit");
        }
    }
}