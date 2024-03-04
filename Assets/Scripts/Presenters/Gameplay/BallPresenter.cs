using UnityEngine;
using Fusion.Addons.Physics;

namespace MultiPong.Presenters.Gameplay
{
    using Systems.Gameplay;
    using Services;
    using Settings;
    using Data;
    using Data.Settings;

    [RequireComponent(typeof(Rigidbody2D), typeof(NetworkRigidbody2D))]
    public class BallPresenter : NetworkPresenter
    {
        private Rigidbody2D rigidbody;
        private float speed;

        private BlackboardSystem blackboardSystem;
        private GameplaySettingsData GameplaySettings => GameSettings.Instance.Gameplay;

        public override void Spawned()
        {
            this.speed = GameplaySettings.BallSpeed;
            this.blackboardSystem = ServiceLocator.Find<BlackboardSystem>();
        }

        private void Awake()
        {
            this.rigidbody = GetComponent<Rigidbody2D>();
        }

        public override void FixedUpdateNetwork()
        {
            if (!IsServerPlayer())
                return;

            rigidbody.velocity = blackboardSystem.GetData<BallData>().Direction;
        }

        private bool IsServerPlayer() => Runner.IsServer;
    }
}