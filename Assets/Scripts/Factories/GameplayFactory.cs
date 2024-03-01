using System.Collections.Generic;
using UnityEngine;

namespace MultiPong.Factories
{
    using Foundation;
    using Services;
    using Presenters.Gameplay;

    public class GameplayFactory : IFactory
    {
        private const string TAG = "presenter";
        private Container<BaseGameplayPresenter> presenters;

        public GameplayFactory()
        {
            this.presenters = new Container<BaseGameplayPresenter>(TAG);
            ServiceLocator.Find<ConfigurerService>().Configure(this);
        }

        public void Setup(List<BaseGameplayPresenter> presenters)
        {
            foreach(var presenter in presenters)
                this.presenters.Add(presenter);
        }

        public T CreatePresenter<T>() where T : BaseGameplayPresenter
        {
            var presenter = presenters.Get<T>();
            return Object.Instantiate(presenter);
        }
    }
}