using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace MultiPong.Configurations
{
    using Factories;
    using Presenters.Popups;
    using Values;

    [CreateAssetMenu(
        fileName = nameof(NetworkFactoryConfiguration), 
        menuName = AssetMenu.CONFIGURATION + "/" + nameof(NetworkFactoryConfiguration)
    )]
    public class NetworkFactoryConfiguration : BaseConfiguration<NetworkFactory>
    {
        [SerializeField] private NetworkRunner networkRunner;

        public override void Configure(NetworkFactory target)
        {
            target.Setup(networkRunner);
        }
    }
}