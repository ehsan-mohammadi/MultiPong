using UnityEngine;

namespace MultiPong.Systems.Gameplay
{
    using Managers.Gameplay;
    using Data;

    public class BallSystem : GameplaySystem, IUpdateableSystem
    {
        private BallData ballData;

        public BallSystem(GameplayManager gameplayManager, ActivationMode activationMode)
            : base(gameplayManager, activationMode)
        {
            this.ballData = new BallData();
        }

        public override void Activate()
        {
            AddBlackBoardData(ballData);
            GenerateRandomDirection();
        }

        public override void Deactivate()
        {
        }

        public void Update()
        {
            UpdateBlackBoardData(ballData);
        }

        public void FixedUpdate()
        {
        }

        void GenerateRandomDirection()
        {
            ballData.Direction = new Vector2(
                x: Random.Range(-1f , 1f),
                y: Random.Range(-1f, 1f)
            );
        }
    }
}