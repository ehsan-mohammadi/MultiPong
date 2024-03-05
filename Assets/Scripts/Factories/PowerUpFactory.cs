using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace MultiPong.Factories
{
    using Foundation;
    using Services;
    using Presenters.Gameplay.PowerUps;

    public class PowerUpFactory : IFactory
    {
        private readonly Container<BasePowerUpPresenter> presenters;

        public PowerUpFactory()
        {
            this.presenters = new Container<BasePowerUpPresenter>();
            ServiceLocator.Find<ConfigurerService>().Configure(this);
        }

        public void Setup(List<BasePowerUpPresenter> presenters)
        {
            foreach(var presenter in presenters)
                this.presenters.Add(presenter);
        }

        public BasePowerUpPresenter SpawnRandomPresenter(
            NetworkRunner networkRunner,
            Vector2 position
        )
        {
            int index = Random.Range(0, presenters.GetAll().Count());
            var presenter = presenters.GetAll().ElementAt(index);

            return networkRunner.Spawn(
                prefab: presenter,
                position: position,
                rotation: Quaternion.identity
            );
        }
    }
}