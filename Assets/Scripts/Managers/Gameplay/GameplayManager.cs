using System.Collections.Generic;

namespace MultiPong.Managers.Gameplay
{
    using Systems;
    using Systems.Gameplay;

    public class GameplayManager : IUpdateableManager
    {
        private readonly GameplayInitializer initializer;

        public GameplayManager()
        {
            initializer = new GameplayInitializer(this);
            initializer.Initialize();
        }

        public void Activate()
        {
            foreach(var system in GetSystems())
                system.Activate();
        }

        public void Deactivate()
        {
            foreach(var system in GetSystems())
                system.Deactivate();
            
            initializer.RemoveAllSystems();
        }

        public void Update()
        {
            foreach(var updateableSystem in GetUpdateableSystems())
                updateableSystem.Update();
        }

        public void FixedUpdate()
        {
            foreach(var updateableSystem in GetUpdateableSystems())
                updateableSystem.FixedUpdate();
        }

        public T GetSystem<T>() where T : GameplaySystem => initializer.Systems.Get<T>();

        private IEnumerable<GameplaySystem> GetSystems() => initializer.Systems.GetAll();

        private IEnumerable<IUpdateableSystem> GetUpdateableSystems() => initializer.UpdateableSystems;
    }
}