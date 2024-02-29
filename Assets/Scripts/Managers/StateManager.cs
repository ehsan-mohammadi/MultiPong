using System;

namespace MultiPong.Managers
{
    using Services;
    using Events;

    public enum GameState { Start, Play, End }

    public class StateManager : IEventListener
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
            if (evt is PlayButtonClickedEvent)
                GoToState(GameState.Play);
        }

        public void GoToState(GameState state) => GameState = state;
    }
}