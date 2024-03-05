using System.Collections.Generic;
using UnityEngine;

namespace MultiPong.Configurations
{
    using Factories;
    using Values;
    using Presenters.Gameplay.PowerUps;

    [CreateAssetMenu(
        fileName = nameof(PowerUpFactoryConfiguration), 
        menuName = AssetMenu.CONFIGURATION + "/" + nameof(PowerUpFactoryConfiguration)
    )]
    public class PowerUpFactoryConfiguration : BaseConfiguration<PowerUpFactory>
    {
        [SerializeField] private List<BasePowerUpPresenter> presenters;

        public override void Configure(PowerUpFactory target)
        {
            target.Setup(presenters);
        }
    }
}