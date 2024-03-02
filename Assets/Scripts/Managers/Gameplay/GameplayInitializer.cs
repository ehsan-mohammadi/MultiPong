namespace MultiPong.Managers.Gameplay
{
    using Foundation;
    using Factories;
    using Systems;

    public class GameplayInitializer
    {
        private const string TAG = "system";
        private readonly Container<BaseSystem> systems;
        private GameplayFactory gameplayFactory;

        public GameplayInitializer()
        {
            this.systems = new Container<BaseSystem>(TAG);
        }

        public void Initialize()
        {
            InitializeGameplayFactory();
        }

        private void InitializeGameplayFactory()
        {
            gameplayFactory = new GameplayFactory();
        }
    }
}