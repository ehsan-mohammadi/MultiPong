namespace MultiPong.Managers.Gameplay
{
    public class GameplayManager : IManager
    {
        private GameplayInitializer initializer;

        public void Initialize()
        {
            initializer = new GameplayInitializer();
            initializer.Initialize();
        }

        public void Activate()
        {
        }
    }
}