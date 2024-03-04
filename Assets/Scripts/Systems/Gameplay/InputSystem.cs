using UnityEngine;

namespace MultiPong.Systems.Gameplay
{
    using Managers.Gameplay;
    using Data;

    public class InputSystem : GameplaySystem, IUpdateableSystem
    {
        private NetworkInputData inputData;

        public InputSystem(GameplayManager gameplayManager, ActivationMode activationMode)
            : base(gameplayManager, activationMode)
        {
            this.inputData = new NetworkInputData();
        }

        public override void Activate()
        {
            AddBlackBoardData(inputData);
        }

        public override void Deactivate()
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