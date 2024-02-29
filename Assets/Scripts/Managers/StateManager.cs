using System;

namespace MultiPong.Managers
{
    public enum GameState { Start, Play, End }

    public class StateManager
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
        }

        public void GoToState(GameState state) => GameState = state;
    }
}