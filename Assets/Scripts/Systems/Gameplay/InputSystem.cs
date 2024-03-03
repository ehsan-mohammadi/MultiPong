using UnityEngine;

namespace MultiPong.Systems.Gameplay
{
    using Managers.Gameplay;
    using Data;

    public class InputSystem : GameplaySystem, IUpdateableSystem
    {
        private NetworkInputData inputData;

        public InputSystem(GameplayManager gameplayManager) : base(gameplayManager)
        {
            this.inputData = new NetworkInputData();
        }

        public void Activate()
        {
            AddBlackBoardData(inputData);
        }

        public void Deactivate()
        {
        }

        public void Update()
        {
            inputData.Movement = Input.GetAxis("Vertical");
            UpdateBlackBoardData(inputData);
        }

        public void FixedUpdate()
        {
        }
    }
}