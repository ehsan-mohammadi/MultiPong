namespace MultiPong.Managers
{
    public enum GameState { Start, Play, End }

    public class StateManager
    {
        private GameState gameState;

        public StateManager()
        {
            this.gameState = GameState.Start;
        }
    }
}