namespace MultiPong.Managers.Gameplay
{
    public class GameplayManager : IUpdateableManager
    {
        private readonly GameplayInitializer initializer;

        public GameplayManager()
        {
            initializer = new GameplayInitializer();
            initializer.Initialize();
        }

        public void Activate()
        {
        }

        public void Deactivate()
        {
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
        }
    }
}