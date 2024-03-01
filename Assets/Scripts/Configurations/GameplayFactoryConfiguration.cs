using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace MultiPong.Configurations
{
    using Factories;
    using Presenters.Gameplay;
    using Values;

    [CreateAssetMenu(
        fileName = nameof(GameplayFactoryConfiguration), 
        menuName = AssetMenu.CONFIGURATION + "/" + nameof(GameplayFactoryConfiguration)
    )]
    public class GameplayFactoryConfiguration : BaseConfiguration<GameplayFactory>
    {
        [SerializeField] private List<BaseGameplayPresenter> presenters;

        public override void Configure(GameplayFactory target)
        {
            target.Setup(presenters);
        }
    }
}