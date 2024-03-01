namespace MultiPong.Managers.Game
{
    using Foundation;
    using Managers;
    using Managers.Gameplay;
    using Services;
    using Factories;
    using Configurations;

    public class GameInitializer
    {
        private const string TAG = "manager";
        private readonly GameManager gameManager;
        private readonly Container<IManager> managers;
        private readonly ConfigurationMaster configurationMaster;
        
        private ConfigurerService configurerService;
        internal Container<IManager> Managers => managers;

        public GameInitializer(GameManager gameManager, ConfigurationMaster configurationMaster)
        {
            this.gameManager = gameManager;
            this.managers = new Container<IManager>(TAG);
            this.configurationMaster = configurationMaster;
        }

        public void Initialize()
        {
            InitializeServiceLocator();
            InitializeConfigurationService();
            InitializeEventManager();
            InitializePopupManager();
            InitializeTransitionManager();
            InitializeStateManager();
        }

        public void InitializeNetworkManager()
        {
            var networkManager = new NetworkManager();
            networkManager.Setup(new NetworkFactory());
            managers.Add(networkManager);
        }

        public void InitializeGameplayManager()
        {
            var gameplayManager = new GameplayManager();
            gameplayManager.Initialize();
            managers.Add(gameplayManager);
        }

        private void InitializeServiceLocator()
        {
            ServiceLocator.Initialize();
        }

        private void InitializeConfigurationService()
        {
            configurerService = new ConfigurerService();
            configurerService.Initialize();
            configurationMaster.Register(configurerService);
        }

        private void InitializeEventManager()
        {
            managers.Add(new EventManager());
        }

        private void InitializePopupManager()
        {
            var popupManager = new PopupManager();
            popupManager.Setup(new PopupFactory());
            managers.Add(popupManager);
        }

        private void InitializeTransitionManager()
        {
            managers.Add(new TransitionManager());
        }

        private void InitializeStateManager()
        {
            var stateManager = new StateManager();
            stateManager.Setup(gameManager.PrepareForState);
            stateManager.GoToState(GameState.Start);
            managers.Add(stateManager);
        }
    }
}