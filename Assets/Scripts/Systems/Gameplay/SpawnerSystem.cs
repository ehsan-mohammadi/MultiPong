using UnityEngine;

namespace MultiPong.Systems.Gameplay
{
    using Managers;
    using Managers.Gameplay;
    using Services;
    using Factories;
    using Settings;
    using Presenters.Gameplay;
    using Data;
    using Data.Settings;

    public class SpawnerSystem : GameplaySystem, ISystem
    {
        private readonly GameplayFactory gameplayFactory;
        private readonly NetworkManager networkManager;

        private GameplaySettingsData GameplaySettings => GameSettings.Instance.Gameplay;

        public SpawnerSystem(GameplayManager gameplayManager, ActivationMode activationMode)
            : base(gameplayManager, activationMode)
        {
            this.gameplayFactory = new GameplayFactory();
            this.networkManager = ServiceLocator.Find<NetworkManager>();
        }

        public override void Activate()
        {
            SpawnEnvironmentPresenter();
            SpawnPaddlePresenters();
            SpawnBallPresenter();
        }

        public override void Deactivate()
        {
        }

        private void SpawnEnvironmentPresenter()
        {
            gameplayFactory.SpawnNetworkPresenter<EnvironmentPresenter>(
                networkRunner: networkManager.NetworkRunner,
                position: Vector2.zero
            );
        }

        private void SpawnPaddlePresenters()
        {
            for (int i = 0; i < GameplaySettings.SpawnPositions.Count; i++)
            {
                gameplayFactory.SpawnNetworkPresenter<PaddlePresenter>(
                    networkRunner: networkManager.NetworkRunner,
                    position: GameplaySettings.SpawnPositions[i],
                    player: networkManager.Players[i]
                );
            }
        }

        private void SpawnBallPresenter()
        {
            var ballPresenter = gameplayFactory.SpawnNetworkPresenter<BallPresenter>(
                networkRunner: networkManager.NetworkRunner,
                position: Vector2.zero
            );

            AddBlackBoardData(new BallData(ballPresenter));
        }
    }
}