using System.Collections.Generic;
using UnityEngine;

namespace MultiPong.Managers.Game
{
    using Managers.Gameplay;
    using Configurations;

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ConfigurationMaster configurationMaster;
        
        private GameInitializer initializer;

        private void Awake()
        {
            Initialize();
            GotoStartState();
        }

        private void Update()
        {
            foreach(var updateableManager in GetUpdateableManagers())
                updateableManager.Update();
        }

        private void FixedUpdate()
        {
            foreach(var updateableManager in GetUpdateableManagers())
                updateableManager.FixedUpdate();
        }

        private void Initialize()
        {
            initializer = new GameInitializer(this, configurationMaster);
            initializer.Initialize();
        }

        private void GotoStartState()
        {
            GetManager<StateManager>().GoToState(GameState.Start);
        }

        internal void PrepareForState(GameState state)
        {
            switch(state)
            {
                case GameState.Start:
                    Debug.Log("Switched GameState to Start.");
                    GetManager<TransitionManager>().GoToMainMenu();
                    break;
                case GameState.WaitingForOpponent:
                    Debug.Log("Switched GameState to WaitingForOpponent.");
                    GetManager<TransitionManager>().GoToWaitingForOpponent();
                    PreparingNetworkManager();
                    break;
                case GameState.Play:
                    Debug.Log("Switched GameState to Play.");
                    GetManager<TransitionManager>().GoToPlay();
                    PreparingGameplayManager();
                    break;
                case GameState.End:
                    Debug.Log("Switched GameState to End.");
                    GetManager<TransitionManager>().GoToGameOver();
                    PreparingGameEnding();
                    break;
                default:
                    break;
            }
        }

        private void PreparingNetworkManager()
        {
            var networkManager = new NetworkManager();
            AddManager(networkManager);
            ActivateManager(networkManager);
        }

        private void PreparingGameplayManager()
        {
            var gameplayManager = new GameplayManager();
            AddManager(gameplayManager);
            ActivateManager(gameplayManager);
        }

        private void PreparingGameEnding()
        {
            var gameplayManager = GetManager<GameplayManager>();
            var networkManager = GetManager<NetworkManager>();
            var collectorManager = GetManager<CollectorManager>();

            CollectNetworkPresenters();
            DeactivateGameplayManager();
            DeactivateNetworkManager();
            RemoveNetworkRunnerCallbacks();
            ShutdownNetworkManager();
            RemoveNeededManagers();
            CollectNetworkServices();

            void CollectNetworkPresenters() => collectorManager.CollectNetworkPresenters();

            void DeactivateGameplayManager() => gameplayManager.Deactivate();

            void DeactivateNetworkManager() => networkManager.Deactivate();

            void RemoveNetworkRunnerCallbacks() => networkManager.RemoveNetworkRunnerCallbacks();

            void ShutdownNetworkManager() => networkManager.NetworkRunner.Shutdown();

            void RemoveNeededManagers()
            {
                initializer.RemoveManager(gameplayManager);
                initializer.RemoveManager(networkManager);
            }

            void CollectNetworkServices() => collectorManager.CollectNetworkServices();
        }

        private T GetManager<T>() where T : IManager => initializer.Managers.Get<T>();

        private IEnumerable<IUpdateableManager> GetUpdateableManagers() => initializer.UpdateableManagers;
        
        private void AddManager(IManager manager) => initializer.AddManager(manager);

        private void ActivateManager(IManager manager) => initializer.ActivateManager(manager);
    }
}