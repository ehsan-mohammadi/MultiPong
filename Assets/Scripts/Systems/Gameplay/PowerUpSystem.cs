using UnityEngine;

namespace MultiPong.Systems.Gameplay
{
    using Managers;
    using Managers.Gameplay;
    using Services;
    using Factories;
    using Data;
    using Presenters.Gameplay;
    using Presenters.Gameplay.PowerUps;

    public enum PowerUpType { BallSpeedUp, BallSpeedDown }

    public class PowerUpSystem : GameplaySystem, IUpdateableSystem
    {
        private const float MIN_TIME_TO_SPAWN = 4f;
        private const float MAX_TIME_TO_SPAWN = 10f;

        private readonly NetworkManager networkManager;
        private readonly PowerUpFactory powerUpFactory;
        private BasePowerUpPresenter presenter;
        private float timeToSpawn;

        public PowerUpSystem(GameplayManager gameplayManager, ActivationMode activationMode)
            : base(gameplayManager, activationMode)
        {
            this.networkManager = ServiceLocator.Find<NetworkManager>();
            this.powerUpFactory = new PowerUpFactory();
        }

        public override void Activate()
        {
            ChooseRandomTimeToSpawnPowerUp();
        }

        public override void Deactivate()
        {
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
            if (IsReachedToSpawnTime())
            {
                ChooseRandomTimeToSpawnPowerUp();
                RemovePreviousPowerUpIfExists();
                GenerateRandomPowerUp();
            }
        }

        private void OnTrigger(PowerUpType type)
        {
            RemovePreviousPowerUpIfExists();
            switch(type)
            {
                case PowerUpType.BallSpeedUp:
                    SetBallSpeedFactor(GetBlackBoardData<BallData>().Presenter, 2f);
                    break;
                case PowerUpType.BallSpeedDown:
                    SetBallSpeedFactor(GetBlackBoardData<BallData>().Presenter, 0.5f);
                    break;
                default:
                    break;
            }

            void SetBallSpeedFactor(BallPresenter ballPresenter, float speedFactor)
            {
                ballPresenter.SetVelocity(ballPresenter.GetVelocity() * speedFactor);
            }
        }

        private void ChooseRandomTimeToSpawnPowerUp()
        {
            timeToSpawn = Time.time + Random.Range(MIN_TIME_TO_SPAWN, MAX_TIME_TO_SPAWN);
        }

        private bool IsReachedToSpawnTime()
        {
            return Time.time > timeToSpawn;
        }

        private void RemovePreviousPowerUpIfExists()
        {
            if (presenter == null)
                return;
            
            presenter.Despawn();
            presenter = null;
        }

        private void GenerateRandomPowerUp()
        {
            Vector2 randomPosition = new Vector2(
                x: Random.Range(-3f, 3f),
                y: Random.Range(-3f, 3f)
            );

            presenter = powerUpFactory.SpawnRandomPresenter(
                networkRunner: networkManager.NetworkRunner,
                position: randomPosition
            );
            presenter.Setup(OnTrigger);
        }
    }
}