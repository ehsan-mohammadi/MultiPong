namespace MultiPong.Systems.Gameplay
{
    using Managers.Gameplay;
    using Data;

    public enum ActivationMode { General, ServerOnly }

    public abstract class GameplaySystem : ISystem
    {
        protected GameplayManager gameplayManager;
        private ActivationMode activationMode;

        public ActivationMode ActivationMode => activationMode;

        public GameplaySystem(GameplayManager gameplayManager, ActivationMode activationMode)
        {
            this.gameplayManager = gameplayManager;
            this.activationMode = activationMode;
        }

        public abstract void Activate();

        public abstract void Deactivate();

        protected T GetSystem<T>() where T : GameplaySystem
        {
            return gameplayManager.GetSystem<T>();
        }

        protected void AddBlackBoardData<T>(T data) where T : IBlackboardData
        {
            gameplayManager.GetSystem<BlackboardSystem>().AddData(data);
        }

        protected T GetBlackBoardData<T>() where T : IBlackboardData
        {
            return gameplayManager.GetSystem<BlackboardSystem>().GetData<T>();
        }

        protected void UpdateBlackBoardData<T>(T updatedData) where T : IBlackboardData
        {
            gameplayManager.GetSystem<BlackboardSystem>().UpdateData(updatedData);
        }
    }
}