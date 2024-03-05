using UnityEngine;

namespace MultiPong.Configurations
{
    using Settings;
    using Data.Settings;
    using Values;

    [CreateAssetMenu(
        fileName = nameof(GameSettingsConfiguration), 
        menuName = AssetMenu.SETTINGS + "/" + nameof(GameSettingsConfiguration)
    )]
    public class GameSettingsConfiguration : BaseConfiguration<GameSettings>
    {
        [SerializeField] private NetworkSettingsData network;
        [SerializeField] private GameplaySettingsData gameplay;

        public override void Configure(GameSettings target)
        {
            target.Setup(network, gameplay);
        }
    }
}