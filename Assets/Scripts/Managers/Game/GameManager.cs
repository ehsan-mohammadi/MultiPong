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

        private T GetManager<T>() where T : IManager => initializer.Managers.Get<T>();

        private IEnumerable<IUpdateableManager> GetUpdateableManagers() => initializer.UpdateableManagers;
        
        private void AddManager(IManager manager) => initializer.AddManager(manager);

        private void ActivateManager(IManager manager) => initializer.ActivateManager(manager);
    }
}