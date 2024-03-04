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
        private readonly NetworkManager networkManager;
        private readonly Container<GameplaySystem> systems;
        private readonly Container<IUpdateableSystem> updateableSystems;

        internal Container<GameplaySystem> Systems => systems;
        internal IEnumerable<IUpdateableSystem> UpdateableSystems => updateableSystems.GetAll();

        private GameplayFactory gameplayFactory;

        public GameplayInitializer(GameplayManager gameplayManager)
        {
            this.gameplayManager = gameplayManager;
            this.networkManager = ServiceLocator.Find<NetworkManager>();
            this.systems = new Container<GameplaySystem>();
            this.updateableSystems = new Container<IUpdateableSystem>();
        }

        public void Initialize()
        {
            InitializeSystems();
        }

        private void InitializeSystems()
        {
            AddSystem(new BlackboardSystem(gameplayManager, ActivationMode.General));
            AddSystem(new InputSystem(gameplayManager, ActivationMode.General));
            AddSystem(new SpawnerSystem(gameplayManager, ActivationMode.ServerOnly));
            AddSystem(new BallSystem(gameplayManager, ActivationMode.ServerOnly));
        }

        private void AddSystem(GameplaySystem system)
        {
            if (ShouldAvoidAddingSystem())
                return;

            systems.Add(system);

            if (system is IUpdateableSystem)
                updateableSystems.Add(system as IUpdateableSystem);

            bool ShouldAvoidAddingSystem()
            {
                return !IsCalledFromServer() && system.ActivationMode == ActivationMode.ServerOnly;

                bool IsCalledFromServer() => networkManager.NetworkRunner.IsServer;
            }
        }
    }
}