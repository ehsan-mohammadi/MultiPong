using UnityEngine;
using Fusion;

namespace MultiPong.Factories
{
    using Services;

    public class NetworkFactory : IFactory
    {
        private NetworkRunner networkRunner;
        private NetworkSceneManagerDefault networkSceneManager;

        public NetworkFactory()
        {
            ServiceLocator.Find<ConfigurerService>().Configure(this);
        }

        public void Setup(
            NetworkRunner networkRunner,
            NetworkSceneManagerDefault networkSceneManager
        )
        {
            this.networkRunner = networkRunner;
            this.networkSceneManager = networkSceneManager;
        }

        public NetworkRunner CreateNetworkRunner()
        {
            return Object.Instantiate(networkRunner);
        }

        public NetworkSceneManagerDefault CreateNetworkSceneManager()
        {
            return Object.Instantiate(networkSceneManager);
        }
    }
}