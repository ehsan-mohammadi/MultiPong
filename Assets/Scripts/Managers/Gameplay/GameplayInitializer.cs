namespace MultiPong.Managers.Gameplay
{
    using Factories;

    public class GameplayInitializer
    {
        private GameplayFactory gameplayFactory;

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