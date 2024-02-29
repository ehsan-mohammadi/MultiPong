using UnityEngine;

namespace MultiPong.Managers
{
    using Factories;
    using Services;
    using Presenters.Popups;

    public class PopupManager : IService
    {
        private PopupFactory popupFactory;

        public PopupManager()
        {
            ServiceLocator.Register(this);
        }

        public void Setup(PopupFactory popupFactory)
        {
            this.popupFactory = popupFactory;
        }

        public T OpenPopup<T>() where T : BasePopup => popupFactory.CreatePopup<T>();

        public void CloseAll()
        {
            var openPopups = GameObject.FindObjectsOfType<BasePopup>();
            foreach(var popup in openPopups)
                popup.Close();
        }
    }
}