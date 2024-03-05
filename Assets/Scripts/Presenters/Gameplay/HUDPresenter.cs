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

        [Networked] private TickTimer GameTimer { get; set; }
        [Networked] private TickTimer DelayTimer { get; set; }
        [Networked] private int ScoreForPlayer1 { get; set; }
        [Networked] private int ScoreForPlayer2 { get; set; }

        private bool isStarted;

        public override void Spawned()
        {
            ServiceLocator.Find<EventManager>().Propagate(
                evt: new HUDPresenterCreatedEvent(this), 
                sender: this
            );
        }

        public void Setup(int gameTime)
        {
            GameTimer = TickTimer.CreateFromSeconds(
                runner: Runner,
                delayInSeconds: gameTime
            );

            PrepareForStart();
        }

        public void PrepareForStart()
        {
            isStarted = false;
            DelayTimer = TickTimer.CreateFromSeconds(
                runner: Runner,
                delayInSeconds: 2f
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
            UpdatePlayingState();
            UpdateScores();
        }

        private void ShowWaitingText()
        {
            textTimer.text = "READY?!";
        }

        private void UpdatePlayingState()
        {
            if (IsWaitingForStart())
            {
                ShowWaitingText();
                return;
            }
            else if (IsNeededToStart())
            {
                SendStartPlayingEvent();
                isStarted = true;
            }
            else
            {
                UpdateTimer();
            }

            bool IsWaitingForStart() => GetRemianingTime(DelayTimer) > 0;

            bool IsNeededToStart() => DelayTimer.Expired(Runner) && !isStarted;

            void SendStartPlayingEvent()
            {
                ServiceLocator.Find<EventManager>().Propagate(
                    evt: new StartPlayingEvent(),
                    sender: this
                );
            }

            void UpdateTimer()
            {
                textTimer.text = GetRemianingTime(GameTimer).ToString();
            }
        }

        private void UpdateScores()
        {
            textScoreForPlayer1.text = ScoreForPlayer1.ToString();
            textScoreForPlayer2.text = ScoreForPlayer2.ToString();
        }

        private int GetRemianingTime(TickTimer timer)
        {
            return Mathf.RoundToInt(timer.RemainingTime(Runner) ?? 0);
        }
    }
}