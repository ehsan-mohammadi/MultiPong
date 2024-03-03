namespace MultiPong.Systems.Gameplay
{
    using Managers;
    using Managers.Gameplay;
    using Services;
    using Factories;
    using Presenters.Gameplay;

    public class SpawnerSystem : GameplaySystem, ISystem
    {
        private readonly GameplayFactory gameplayFactory;
        private readonly NetworkManager networkManager;

        public SpawnerSystem(GameplayManager gameplayManager) : base(gameplayManager)
        {
            this.gameplayFactory = new GameplayFactory();
            this.networkManager = ServiceLocator.Find<NetworkManager>();
        }

        public void Activate()
        {
            if (!IsCalledFromServer())
                return;

            var validPositions = new System.Collections.Generic.List<UnityEngine.Vector2>() {
                new UnityEngine.Vector2(-2, 0),
                new UnityEngine.Vector2(2, 0)
            };
            
            for (int i = 0; i < validPositions.Count; i++)
            {
                gameplayFactory.SpawnNetworkPresenter<PaddlePresenter>(
                    networkRunner: networkManager.NetworkRunner,
                    position: validPositions[i],
                    player: networkManager.Players[i]
                );
            }

            bool IsCalledFromServer() => networkManager.NetworkRunner.IsServer;
        }

        public void Deactivate()
        {
        }
    }
}