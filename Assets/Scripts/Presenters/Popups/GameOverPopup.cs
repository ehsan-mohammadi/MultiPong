using System;
using UnityEngine;
using UnityEngine.UI;

namespace MultiPong.Presenters.Popups
{
    public class GameOverPopup : BasePopup
    {
        [SerializeField] private Button restartButton;

        public void Setup(Action onRestartButtonClicked)
        {
            restartButton.onClick.AddListener(onRestartButtonClicked.Invoke);
        }
    }
}