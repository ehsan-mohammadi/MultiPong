using System;
using UnityEngine;
using UnityEngine.UI;

namespace MultiPong.Presenters.Popups
{
    public class MainMenuPopup : BasePopup
    {
        [SerializeField] private Button playButton;

        public void Setup(Action onPlayButtonClicked)
        {
            playButton.onClick.AddListener(onPlayButtonClicked.Invoke);
        }
    }
}