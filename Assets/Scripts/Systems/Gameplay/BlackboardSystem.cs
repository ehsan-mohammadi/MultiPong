namespace MultiPong.Systems.Gameplay
{
    using Foundation;
    using Managers.Gameplay;
    using Services;
    using Data;

    public class BlackboardSystem : GameplaySystem, ISystem, IService
    {
        private readonly Container<IBlackboardData> dataCollection;

        public BlackboardSystem(GameplayManager gameplayManager) : base(gameplayManager)
        {
            this.dataCollection = new Container<IBlackboardData>();
        }
        
        public void Activate()
        {
            ServiceLocator.Register(this);
        }

        public void Deactivate()
        {
            ServiceLocator.Unregister(this);
        }

        public void AddData<T>(T data) where T : IBlackboardData
        {
            dataCollection.Add(data);
        }

        public void UpdateDta<T>(T updatedData) where T : IBlackboardData
        {
            var outdatedData = dataCollection.Get<T>();
            outdatedData = updatedData;
        }

        public T GetData<T>() where T : IBlackboardData
        {
            return dataCollection.Get<T>();
        }
    }
}