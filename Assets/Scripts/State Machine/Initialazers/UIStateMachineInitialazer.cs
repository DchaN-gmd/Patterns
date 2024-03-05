using UnityEngine;
using UnityEngine.UI;

namespace StateMachine
{
    public class UIStateMachineInitialazer : MonoBehaviour
    {
        [Header("Pause")]
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _resumeButton;

        [Header("Notification Panel")]
        [SerializeField] private Button _notificationButton;
        [SerializeField] private Button _skipButton;

        [Header("Presenters")]
        [SerializeField] private PausePresenter _pausePresenter;
        [SerializeField] private NotificationPresenter _notificationPresenter;

        public StateMachine<UIStateMachineInitialazer> StateMachine { get; private set; }

        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(() => ChangeState<PauseState>());
            _resumeButton.onClick.AddListener(() => ChangeState<PlayingState>());
            _notificationButton.onClick.AddListener(() => ChangeState<NotificationState>());
            _skipButton.onClick.AddListener(() => ChangeState<PlayingState>());
        }

        private void OnDisable()
        {
            _pauseButton.onClick.RemoveListener(() => ChangeState<PauseState>());
            _resumeButton.onClick.RemoveListener(() => ChangeState<PlayingState>());
            _notificationButton.onClick.RemoveListener(() => ChangeState<NotificationState>());
            _skipButton.onClick.RemoveListener(() => ChangeState<PlayingState>());
        }

        private void Start()
        {
            StateMachine = new StateMachine<UIStateMachineInitialazer>(
                new PauseState(this, _pausePresenter),
                            new NotificationState(this, _notificationPresenter),
                            new PlayingState(this));

            ChangeState<PlayingState>();
        }

        private void ChangeState<TState>() where TState : IState<UIStateMachineInitialazer>
        {
            StateMachine.SwitchState<TState>();
        }
    }
}