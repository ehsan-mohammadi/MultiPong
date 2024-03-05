using System.Collections.Generic;
using UnityEngine;

namespace MultiPong.Configurations
{
    using Factories;
    using Presenters.Popups;
    using Values;

    [CreateAssetMenu(
        fileName = nameof(PopupFactoryConfiguration), 
        menuName = AssetMenu.CONFIGURATION + "/" + nameof(PopupFactoryConfiguration)
    )]
    public class PopupFactoryConfiguration : BaseConfiguration<PopupFactory>
    {
        [SerializeField] private List<BasePopup> popups;

        public override void Configure(PopupFactory target)
        {
            target.Setup(popups);
        }
    }
}