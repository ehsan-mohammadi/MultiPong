using System.Collections.Generic;

namespace MultiPong.Managers.Gameplay
{
    using Foundation;
    using Factories;
    using Services;
    using Systems;
    using Systems.Gameplay;

    public class GameplayInitializer
    {
        private readonly GameplayManager gameplayManager;
        private readonly Container<ISystem> systems;
        private readonly Container<IUpdateableSystem> updateableSystems;

        internal Container<ISystem> Systems => systems;
        internal IEnumerable<IUpdateableSystem> UpdateableSystems => updateableSystems.GetAll();

        private GameplayFactory gameplayFactory;

        public GameplayInitializer(GameplayManager gameplayManager)
        {
            this.gameplayManager = gameplayManager;
            this.systems = new Container<ISystem>();
            this.updateableSystems = new Container<IUpdateableSystem>();
        }

        public void Initialize()
        {
            InitializeSystems();
        }

        private void InitializeSystems()
        {
            AddSystem(new BlackboardSystem(gameplayManager));
            AddSystem(new InputSystem(gameplayManager));
            AddSystem(new SpawnerSystem(gameplayManager));
        }

        private void AddSystem(ISystem system)
        {
            systems.Add(system);

            if (system is IUpdateableSystem)
                updateableSystems.Add(system as IUpdateableSystem);
        }
    }
}