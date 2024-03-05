using System.Linq;
using System.Collections.Generic;
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
        private HUDPresenter presenter;
        private NetworkManager networkManager;
        private Dictionary<PlayerRef, int> playersScores;

        private GameplaySettingsData GameplaySettings => GameSettings.Instance.Gameplay;

        public HUDSystem(GameplayManager gameplayManager, ActivationMode activationMode)
            : base(gameplayManager, activationMode)
        {
            this.networkManager = ServiceLocator.Find<NetworkManager>();
            this.playersScores = new Dictionary<PlayerRef, int>();
        }

        public override void Activate()
        {
            ServiceLocator.Find<EventManager>().Register(this);
            InitializePlayersScores();
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
                    SetupPresenter(hudPresenterCreated.Presenter);
                    break;
                case GoalScoredEvent goalReceived:
                    UpdateScore(goalReceived.Player);
                    break;
                default:
                    break;
            }
        }

        private void InitializePlayersScores()
        {
            playersScores.Clear();

            foreach(var player in networkManager.Players)
                playersScores.Add(player, 0);
        }

        private void SetupPresenter(HUDPresenter hudPresenter)
        {
            presenter = hudPresenter;
            presenter.Setup(GameplaySettings.GameTime);
        }

        private void UpdateScore(PlayerRef player)
        {
            IncreaseScore(player);
            int index = networkManager.Players.IndexOf(player);
            int score = playersScores[player];
            presenter.SetPlayerScore(index, score);
        }

        private void IncreaseScore(PlayerRef player) => playersScores[player]++;
    }
}