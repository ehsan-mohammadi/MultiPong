using UnityEngine;
using Fusion;
using Fusion.Addons.Physics;

namespace MultiPong.Presenters.Gameplay
{
    using Settings;
    using Data;
    using Data.Settings;

    [RequireComponent(typeof(Rigidbody2D), typeof(NetworkRigidbody2D))]
    public class PaddlePresenter : NetworkPresenter, IPlayerLeft
    {
        private Rigidbody2D rigidbody;
        private float speed;

        private GameplaySettingsData GameplaySettings => GameSettings.Instance.Gameplay;

        public override void Spawned()
        {
            this.rigidbody = GetComponent<Rigidbody2D>();
            this.speed = GameplaySettings.PaddleSpeed;
        }

        public void PlayerLeft(PlayerRef player)
        {
            if (IsLocalPlayer())
                Runner.Despawn(Object);
        }

        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData inputData))
                rigidbody.velocity = new Vector2(0, inputData.Movement) * speed;
        }

        private bool IsLocalPlayer() => Object.HasInputAuthority;
    }
}