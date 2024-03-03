using UnityEngine;
using Fusion;
using Fusion.Addons.Physics;

namespace MultiPong.Presenters.Gameplay
{
    using Data;

    [RequireComponent(typeof(Rigidbody2D), typeof(NetworkRigidbody2D))]
    public class PaddlePresenter : NetworkPresenter, IPlayerLeft
    {
        private Rigidbody2D rigidbody;

        public static PaddlePresenter Local;

        public override void Spawned()
        {
            if (IsLocalPlayer())
                Local = this;
        }

        public void PlayerLeft(PlayerRef player)
        {
            if (IsLocalPlayer())
                Runner.Despawn(Object);
        }

        private void Awake()
        {
            this.rigidbody = GetComponent<Rigidbody2D>();
        }

        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData inputData))
                rigidbody.velocity = new Vector2(0, inputData.Movement);
        }

        private bool IsLocalPlayer() => Object.HasInputAuthority;
    }
}