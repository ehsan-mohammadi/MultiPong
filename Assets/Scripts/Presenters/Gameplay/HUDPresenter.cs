using UnityEngine;
using TMPro;
using Fusion;

namespace MultiPong.Presenters.Gameplay
{
    using Managers;
    using Services;
    using Events;

    public class HUDPresenter : NetworkPresenter
    {
        [SerializeField] private TMP_Text textTimer;
        [SerializeField] private TMP_Text textScoreForPlayer1;
        [SerializeField] private TMP_Text textScoreForPlayer2;

        [Networked] private TickTimer Timer { get; set; }
        [Networked] private int ScoreForPlayer1 { get; set; }
        [Networked] private int ScoreForPlayer2 { get; set; }

        public override void Spawned()
        {
            ServiceLocator.Find<EventManager>().Propagate(
                evt: new HUDPresenterCreatedEvent(this), 
                sender: this
            );
        }

        public void Setup(int gameTime)
        {
            Timer = TickTimer.CreateFromSeconds(
                runner: Runner,
                delayInSeconds: gameTime
            );
        }

        public void SetPlayerScore(int index, int score)
        {
            if (index == 0)
                ScoreForPlayer1 = score;
            else if (index == 1)
                ScoreForPlayer2 = score;
        }

        public void FixedUpdate()
        {
            UpdateTimer();
            UpdateScores();
        }

        private int GetRemianingTime()
        {
            return Mathf.RoundToInt(Timer.RemainingTime(Runner) ?? 0);
        }

        private void UpdateTimer()
        {
            textTimer.text = GetRemianingTime().ToString();
        }

        private void UpdateScores()
        {
            textScoreForPlayer1.text = ScoreForPlayer1.ToString();
            textScoreForPlayer2.text = ScoreForPlayer2.ToString();
        }
    }
}