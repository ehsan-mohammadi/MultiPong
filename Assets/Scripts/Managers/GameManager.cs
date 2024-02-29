using UnityEngine;

namespace MultiPong.Managers
{
    public class GameManager : MonoBehaviour
    {
        private StateManager stateManager;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            this.stateManager = new StateManager();
        }
    }
}