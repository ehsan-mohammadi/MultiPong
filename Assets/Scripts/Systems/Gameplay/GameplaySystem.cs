namespace MultiPong.Systems.Gameplay
{
    using Managers.Gameplay;
    using Data;

    public abstract class GameplaySystem
    {
        private GameplayManager gameplayManager;

        public GameplaySystem(GameplayManager gameplayManager)
        {
            this.gameplayManager = gameplayManager;
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