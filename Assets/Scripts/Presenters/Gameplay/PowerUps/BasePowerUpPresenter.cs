using System;
using UnityEngine;

namespace MultiPong.Presenters.Gameplay.PowerUps
{
    using Systems.Gameplay;

    public abstract class BasePowerUpPresenter : NetworkPresenter
    {
        private Action<PowerUpType> onTrigger;  
        protected abstract PowerUpType Type { get; }

        public void Setup(Action<PowerUpType> onTrigger)
        {
            this.onTrigger = onTrigger;
        }

        public void Despawn()
        {
            Runner.Despawn(Object);
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            onTrigger.Invoke(Type);
        }
    }
}