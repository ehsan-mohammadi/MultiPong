using System;
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

        [Networked] private TickTimer Timer { get; set; }

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

        public void FixedUpdate()
        {
            textTimer.text = GetRemianingTime().ToString();
        }

        private int GetRemianingTime()
        {
            return Mathf.RoundToInt(Timer.RemainingTime(Runner) ?? 0);
        }
    }
}