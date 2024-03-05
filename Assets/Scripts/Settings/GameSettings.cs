namespace MultiPong.Settings
{
    using Services;
    using Data.Settings;

    public class GameSettings
    {
        public NetworkSettingsData Network { get; private set; }
        public GameplaySettingsData Gameplay { get; private set; }

        public static GameSettings Instance;

        public GameSettings()
        {
            if (Instance != null)
                return;
            
            Instance = this;

            ServiceLocator.Find<ConfigurerService>().Configure(this);
        }

        public void Setup(NetworkSettingsData network, GameplaySettingsData gameplay)
        {
            this.Network = network;
            this.Gameplay = gameplay;
        }
    }
}