using UnityEngine;

namespace MultiPong.Managers
{
    using Factories;
    using Services;
    using Presenters.Popups;

    public class PopupManager : IManager, IService
    {
        private readonly PopupFactory popupFactory;

        public PopupManager()
        {
            this.popupFactory = new PopupFactory();
        }

        public void Activate()
        {
            ServiceLocator.Register(this);
        }

        public void Deactivate()
        {
            ServiceLocator.Unregister(this);
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