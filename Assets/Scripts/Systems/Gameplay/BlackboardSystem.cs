using System;
using System.Collections.Generic;

namespace MultiPong.Systems.Gameplay
{
    using Managers.Gameplay;
    using Services;
    using Data;

    public class BlackboardSystem : GameplaySystem, ISystem, IService
    {
        private readonly Dictionary<Type, IBlackboardData> dataCollection;

        public BlackboardSystem(GameplayManager gameplayManager, ActivationMode activationMode)
            : base(gameplayManager, activationMode)
        {
            this.dataCollection = new Dictionary<Type, IBlackboardData>();
        }
        
        public override void Activate()
        {
            ServiceLocator.Register(this);
        }

        public override void Deactivate()
        {
            ServiceLocator.Unregister(this);
        }

        public void AddData<T>(T data) where T : IBlackboardData
        {
            dataCollection.Add(data.GetType(), data);
        }

        public void UpdateData<T>(T updatedData) where T : IBlackboardData
        {
            dataCollection[updatedData.GetType()] = updatedData;
        }

        public T GetData<T>() where T : IBlackboardData
        {
            return (T)dataCollection[typeof(T)];
        }
    }
}