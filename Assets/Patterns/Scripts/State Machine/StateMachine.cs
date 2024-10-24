using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StateMachine
{ 
    public class StateMachine<TInitializer>
    {

        private IState<TInitializer> _currentState;
        private readonly Dictionary<Type, IState<TInitializer>> _states;
        private bool _isTickable;

        public StateMachine(params IState<TInitializer>[] states)
        {
            _states = new Dictionary<Type, IState<TInitializer>>(states.Length);

            foreach (var state in states)
            {
                _states.Add(state.GetType(), state);
            }
        }

        public void SwitchState<TState>() where TState : IState<TInitializer>
        {
            TryExitPreviousState<TState>();

            TryEnterNewState<TState>();

            TryTickState<TState>();
        }

        private void TryTickState<TState>() where TState : IState<TInitializer>
        {
            if (_currentState is ITickable tickable)
            {
                _isTickable = true;
                StartTick(tickable);
            }
            else
            {
                _isTickable = false;
            }
        }

        private void TryExitPreviousState<TState>() where TState : IState<TInitializer>
        {
            if (_currentState is IExitable exitable)
            {
                exitable.Exit();
            }
        }

        private void TryEnterNewState<TState>() where TState : IState<TInitializer>
        {
            var newState = GetState<TState>();
            _currentState = newState;

            if (_currentState is IEnterable enterable)
            {
                enterable.Enter();
            }
        }

        private TState GetState<TState>() where TState : IState<TInitializer>
        {
            return (TState)_states[typeof(TState)];
        }

        private async void StartTick(ITickable tickable)
        {
            while (_isTickable)
            {
                tickable.Tick();
                await Task.Yield();
            }
        }
    }
}
