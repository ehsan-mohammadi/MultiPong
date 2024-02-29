using UnityEngine;

namespace MultiPong.Managers.Game
{
    public class GameManager : MonoBehaviour
    {
        private GameInitializer initializer;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            initializer = new GameInitializer(this);
            initializer.Initialize();
        }

        internal void PrepareForState(GameState state)
        {
            switch(state)
            {
                case GameState.Start:
                    Debug.Log("Switched GameState to Start.");
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