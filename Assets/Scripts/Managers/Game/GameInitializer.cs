namespace MultiPong.Managers.Game
{
    using Managers;
    using Services;
    using Factories;
    using Configurations;

    public class GameInitializer
    {
        private readonly GameManager gameManager;
        private readonly ConfigurationMaster configurationMaster;
        
        internal ConfigurerService ConfigurerService { get; private set; }
        internal EventManager EventManager { get; private set; }
        internal PopupManager PopupManager { get; private set; }
        internal TransitionManager TransitionManager { get; private set; }
        internal StateManager StateManager { get; private set; }

        public GameInitializer(GameManager gameManager, ConfigurationMaster configurationMaster)
        {
            this.gameManager = gameManager;
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

        private void InitializeServiceLocator()
        {
            ServiceLocator.Initialize();
        }

        private void InitializeConfigurationService()
        {
            ConfigurerService = new ConfigurerService();
            ConfigurerService.Initialize();
            configurationMaster.Register(ConfigurerService);
        }

        private void InitializeEventManager()
        {
            EventManager = new EventManager();
        }

        private void InitializePopupManager()
        {
            var popupFactory = new PopupFactory();
            PopupManager = new PopupManager();
            PopupManager.Setup(popupFactory);
        }

        private void InitializeTransitionManager()
        {
            TransitionManager = new TransitionManager();
        }

        private void InitializeStateManager()
        {
            StateManager = new StateManager();
            StateManager.Setup(gameManager.PrepareForState);
            StateManager.GoToState(GameState.Start);
        }
    }
}