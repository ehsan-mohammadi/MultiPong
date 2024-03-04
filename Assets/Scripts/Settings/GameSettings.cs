using UnityEngine;

namespace MultiPong.Settings
{
    using Data.Settings;
    using Values;

    [CreateAssetMenu(
        fileName = nameof(GameSettings), 
        menuName = AssetMenu.SETTINGS + "/" + nameof(GameSettings)
    )]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private NetworkSettingsData network;
        [SerializeField] private GameplaySettingsData gameplay;

        public NetworkSettingsData Network => network;
        public GameplaySettingsData Gameplay => gameplay;

        public static GameSettings Instance;

        public GameSettings()
        {
            if (Instance != null)
                return;
            
            Instance = this;
        }
    }
}