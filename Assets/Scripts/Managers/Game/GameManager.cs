using UnityEngine;

namespace MultiPong.Managers.Game
{
    using Configurations;

    public class GameManager : MonoBehaviour, IManager
    {
        [SerializeField] private ConfigurationMaster configurationMaster;
        
        private GameInitializer initializer;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            initializer = new GameInitializer(this, configurationMaster);
            initializer.Initialize();
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
            initializer.InitializeNetworkManager();
            GetManager<NetworkManager>().Activate();
        }

        private T GetManager<T>() where T : IManager => initializer.Managers.Get<T>();
    }
}