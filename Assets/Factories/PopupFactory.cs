using System.Collections.Generic;
using UnityEngine;

namespace MultiPong.Factories
{
    using Foundation;
    using Services;
    using Presenters.Popups;

    public class PopupFactory : IFactory
    {
        private const string TAG = "popup";
        private Container<BasePopup> popups;

        private Canvas Canvas => GameObject.FindObjectOfType<Canvas>();

        public PopupFactory()
        {
            this.popups = new Container<BasePopup>(TAG);
            ServiceLocator.Find<ConfigurerService>().Configure(this);
        }

        public void Setup(List<BasePopup> popups)
        {
            foreach(var popup in popups)
                this.popups.Add(popup);
        }

        public T CreatePopup<T>() where T : BasePopup
        {
            var popupPrefab = popups.Get<T>();
            return Object.Instantiate(popupPrefab, Canvas.transform);
        }
    }
}