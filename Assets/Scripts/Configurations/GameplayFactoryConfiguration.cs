using System.Collections.Generic;
using UnityEngine;

namespace MultiPong.Configurations
{
    using Factories;
    using Values;

    [CreateAssetMenu(
        fileName = nameof(GameplayFactoryConfiguration), 
        menuName = AssetMenu.CONFIGURATION + "/" + nameof(GameplayFactoryConfiguration)
    )]
    public class GameplayFactoryConfiguration : BaseConfiguration<GameplayFactory>
    {
        [SerializeField] private List<MonoBehaviour> presenters;

        public override void Configure(GameplayFactory target)
        {
            target.Setup(presenters);
        }
    }
}