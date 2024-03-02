using System.Collections.Generic;

namespace MultiPong.Managers.Game
{
    using Foundation;
    using Managers;
    using Services;
    using Configurations;

    public class GameInitializer
    {
        private const string MANAGER_TAG = "manager";
        private const string UPDATEABLE_MANAGER_TAG = "updateableManager";

        private readonly GameManager gameManager;
        private readonly Container<IManager> managers;
        private readonly Container<IUpdateableManager> updateableManagers;
        private readonly ConfigurationMaster configurationMaster;
        
        private ConfigurerService configurerService;
        
        internal Container<IManager> Managers => managers;
        internal IEnumerable<IUpdateableManager> UpdateableManagers => updateableManagers.GetAll();

        public GameInitializer(GameManager gameManager, ConfigurationMaster configurationMaster)
        {
            this.managers = new Container<IManager>(MANAGER_TAG);
            this.updateableManagers = new Container<IUpdateableManager>(UPDATEABLE_MANAGER_TAG);

            this.gameManager = gameManager;
            this.configurationMaster = configurationMaster;
        }

        public void Initialize()
        {
            InitializeRootServices();
            InitializeRootManagers();
            ActivateRootManagers();

            void InitializeRootServices()
            {
                InitializeServiceLocator();
                InitializeConfigurationService();
            }

            void InitializeRootManagers()
            {
                InitializeEventManager();
                InitializePopupManager();
                InitializeTransitionManager();
                InitializeStateManager();
            }

            void ActivateRootManagers()
            {
                foreach(var manager in managers.GetAll())
                    ActivateManager(manager);
            }
        }

        internal void AddManager(IManager manager)
        {
            managers.Add(manager);

            if (manager is IUpdateableManager)
                updateableManagers.Add(manager as IUpdateableManager);
        }

        internal void ActivateManager(IManager manager)
        {
            manager.Activate();
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
            var eventManager = new EventManager();
            AddManager(eventManager);
        }

        private void InitializePopupManager()
        {
            var popupManager = new PopupManager();
            AddManager(popupManager);
        }

        private void InitializeTransitionManager()
        {
            var transitionManager = new TransitionManager();
            AddManager(transitionManager);
        }

        private void InitializeStateManager()
        {
            var stateManager = new StateManager();
            stateManager.Setup(gameManager.PrepareForState);
            AddManager(stateManager);
        }
    }
}