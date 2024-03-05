using System;
using UnityEngine;
using Fusion.Addons.Physics;

namespace MultiPong.Presenters.Gameplay
{
    using Settings;
    using Data.Settings;

    [RequireComponent(typeof(Rigidbody2D), typeof(NetworkRigidbody2D))]
    public class BallPresenter : NetworkPresenter
    {
        private Rigidbody2D rigidbody;
        private Vector2 direction;

        private Action<Collision2D> onCollision;

        private GameplaySettingsData GameplaySettings => GameSettings.Instance.Gameplay;

        public void Setup(Action<Collision2D> onCollision)
        {
            this.onCollision = onCollision;
        }

        public void SetPosition(Vector2 position)
        {
            rigidbody.position = position;
        }
        
        public void SetVelocity(Vector2 direction)
        {
            rigidbody.velocity = direction;
        }

        public override void Spawned()
        {
            this.rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!IsServerPlayer())
                return;

            onCollision.Invoke(collision);
        }

        private bool IsServerPlayer() => Runner.IsServer;
    }
}