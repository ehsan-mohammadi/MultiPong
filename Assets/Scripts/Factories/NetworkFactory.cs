using UnityEngine;
using Fusion;

namespace MultiPong.Factories
{
    using Services;

    public class NetworkFactory : IFactory
    {
        private NetworkRunner networkRunner;

        public NetworkFactory()
        {
            ServiceLocator.Find<ConfigurerService>().Configure(this);
        }

        public void Setup(NetworkRunner networkRunner)
        {
            this.networkRunner = networkRunner;
        }

        public NetworkRunner CreateNetworkRunner()
        {
            return Object.Instantiate(networkRunner);
        }
    }
}