namespace MultiPong.Managers.Game
{
    using Managers;
    using Services;

    public class GameInitializer
    {
        private readonly GameManager gameManager;
        private StateManager stateManager;

        public GameInitializer(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public void Initialize()
        {
            InitializeServiceLocator();
            InitializeStateManager();
        }

        private void InitializeServiceLocator()
        {
            ServiceLocator.Initialize();
        }

        private void InitializeStateManager()
        {
            stateManager = new StateManager();
            stateManager.Setup(gameManager.PrepareForState);
            stateManager.GoToState(GameState.Start);
        }
    }
}