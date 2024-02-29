using UnityEngine;

namespace MultiPong.Managers.Game
{
    using Configurations;
    using Presenters.Popups;

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ConfigurationMaster configurationMaster;
        
        private GameInitializer initializer;

        private TransitionManager TransitionManager => initializer.TransitionManager;

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
                    TransitionManager.GoToMainMenu();
                    break;
                case GameState.Play:
                    Debug.Log("Switched GameState to Play.");
                    break;
                case GameState.End:
                    Debug.Log("Switched GameState to End.");
                    break;
                default:
                    break;
            }
        }
    }
}