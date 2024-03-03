using UnityEngine;
using Fusion;
using Fusion.Addons.Physics;

namespace MultiPong.Presenters.Gameplay
{
    [RequireComponent(typeof(Rigidbody2D), typeof(NetworkRigidbody2D))]
    public class PaddlePresenter : NetworkPresenter
    {
        private Rigidbody2D rigidbody;

        private void Awake()
        {
            this.rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}