using System;

namespace MultiPong.Managers
{
    using Services;
    using Events;

    public enum GameState { Start, WaitingForOpponent, Play, End }

    public class StateManager : IManager, IEventListener
    {
        private GameState gameState;
        private Action<GameState> onStateChanged;

        public GameState GameState
        {
            get
            {
                return gameState;
            }

            private set
            {
                gameState = value;
                onStateChanged.Invoke(gameState);
            }
        }

        public void Setup(Action<GameState> onStateChanged)
        {
            this.onStateChanged = onStateChanged;
            ServiceLocator.Find<EventManager>().Register(this);
        }

        public void OnEvent(IEvent evt, object sender)
        {
            switch(evt)
            {
                case PlayButtonClickedEvent:
                    GoToState(GameState.WaitingForOpponent);
                    break;
                case AllPlayersJoinedEvent:
                    GoToState(GameState.Play);
                    break;
                default:
                    break;
            }
        }

        public void GoToState(GameState state) => GameState = state;
    }
}