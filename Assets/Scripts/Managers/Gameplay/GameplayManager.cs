using System.Collections.Generic;

namespace MultiPong.Managers.Gameplay
{
    using Systems;

    public class GameplayManager : IUpdateableManager
    {
        private readonly GameplayInitializer initializer;

        public GameplayManager()
        {
            initializer = new GameplayInitializer();
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

        private IEnumerable<ISystem> GetSystems() => initializer.Systems;

        private IEnumerable<IUpdateableSystem> GetUpdateableSystems() =>initializer.UpdateableSystems;
    }
}