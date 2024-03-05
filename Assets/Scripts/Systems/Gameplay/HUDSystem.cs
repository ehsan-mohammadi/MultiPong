using UnityEngine;
using Fusion;

namespace MultiPong.Systems.Gameplay
{
    using Managers;
    using Managers.Gameplay;
    using Services;
    using Settings;
    using Events;
    using Data.Settings;
    using Presenters.Gameplay;

    public class HUDSystem : GameplaySystem, IEventListener
    {
        [Networked] private TickTimer Timer { get; set; }

        private HUDPresenter presenter;
        private NetworkManager networkManager;

        private GameplaySettingsData GameplaySettings => GameSettings.Instance.Gameplay;

        public HUDSystem(GameplayManager gameplayManager, ActivationMode activationMode)
            : base(gameplayManager, activationMode)
        {
            this.networkManager = ServiceLocator.Find<NetworkManager>();
        }

        public override void Activate()
        {
            ServiceLocator.Find<EventManager>().Register(this);
        }

        public override void Deactivate()
        {
            ServiceLocator.Find<EventManager>().Unregister(this);
        }

        public void OnEvent(IEvent evt, object sender)
        {
            switch(evt)
            {
                case HUDPresenterCreatedEvent hudPresenterCreated:
                    presenter = hudPresenterCreated.Presenter;
                    presenter.Setup(GameplaySettings.GameTime);
                    break;
                default:
                    break;
            }
        }
    }
}