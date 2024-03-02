using System.Collections.Generic;

namespace MultiPong.Managers.Gameplay
{
    using Foundation;
    using Factories;
    using Systems;

    public class GameplayInitializer
    {
        private readonly Container<ISystem> systems;
        private readonly Container<IUpdateableSystem> updateableSystems;

        internal IEnumerable<ISystem> Systems => systems.GetAll();
        internal IEnumerable<IUpdateableSystem> UpdateableSystems => updateableSystems.GetAll();

        private GameplayFactory gameplayFactory;

        public GameplayInitializer()
        {
            this.systems = new Container<ISystem>();
            this.updateableSystems = new Container<IUpdateableSystem>();
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