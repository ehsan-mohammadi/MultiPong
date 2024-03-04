using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace MultiPong.Factories
{
    using Foundation;
    using Services;

    public class GameplayFactory : IFactory
    {
        private readonly Container<MonoBehaviour> presenters;

        public GameplayFactory()
        {
            this.presenters = new Container<MonoBehaviour>();
            ServiceLocator.Find<ConfigurerService>().Configure(this);
        }

        public void Setup(List<MonoBehaviour> presenters)
        {
            foreach(var presenter in presenters)
                this.presenters.Add(presenter);
        }

        public T CreatePresenter<T>() where T : MonoBehaviour
        {
            var presenter = presenters.Get<T>();
            return Object.Instantiate(presenter);
        }

        public T SpawnNetworkPresenter<T>(
            NetworkRunner networkRunner,
            Vector2 position,
            PlayerRef player
        ) where T : NetworkBehaviour
        {
            var presenter = presenters.Get<T>();
            return networkRunner.Spawn(
                prefab: presenter,
                position: position,
                rotation: Quaternion.identity,
                inputAuthority: player
            );
        }

        public T SpawnNetworkPresenter<T>(
            NetworkRunner networkRunner,
            Vector2 position
        ) where T : NetworkBehaviour
        {
            var presenter = presenters.Get<T>();
            return networkRunner.Spawn(
                prefab: presenter,
                position: position,
                rotation: Quaternion.identity
            );
        }
    }
}