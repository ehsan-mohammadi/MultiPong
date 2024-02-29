using System.Collections.Generic;
using UnityEngine;

namespace MultiPong.Configurations
{
    using Services;
    using Values;

    [CreateAssetMenu(
        fileName = nameof(ConfigurationMaster), 
        menuName = AssetMenu.CONFIGURATION + "/" + nameof(ConfigurationMaster)
    )]
    public class ConfigurationMaster : BaseConfiguration
    {
        [SerializeField] private List<BaseConfiguration> configurations;

        public override void Register(ConfigurerService configurerService)
        {
            foreach(BaseConfiguration configuration in configurations)
                configuration.Register(configurerService);
        }
    }
}