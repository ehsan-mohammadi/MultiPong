namespace MultiPong.Systems.Gameplay
{
    using Managers;
    using Managers.Gameplay;
    using Services;
    using Factories;
    using Settings;
    using Presenters.Gameplay;
    using Data.Settings;

    public class SpawnerSystem : GameplaySystem, ISystem
    {
        private readonly GameplayFactory gameplayFactory;
        private readonly NetworkManager networkManager;

        private GameplaySettingsData GameplaySettings => GameSettings.Instance.Gameplay;

        public SpawnerSystem(GameplayManager gameplayManager) : base(gameplayManager)
        {
            this.gameplayFactory = new GameplayFactory();
            this.networkManager = ServiceLocator.Find<NetworkManager>();
        }

        public void Activate()
        {
            if (!IsCalledFromServer())
                return;
            
            for (int i = 0; i < GameplaySettings.SpawnPositions.Count; i++)
            {
                gameplayFactory.SpawnNetworkPresenter<PaddlePresenter>(
                    networkRunner: networkManager.NetworkRunner,
                    position: GameplaySettings.SpawnPositions[i],
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