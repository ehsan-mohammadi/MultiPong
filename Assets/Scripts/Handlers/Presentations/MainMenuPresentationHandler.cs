namespace MultiPong.Handlers.Presentaions
{
    using Managers;
    using Services;
    using Events;
    using Presenters.Popups;

    public class MainMenuPresentationHandler : IPresentationHandler
    {
        private PopupManager PopupManager => ServiceLocator.Find<PopupManager>();
        private EventManager EventManager => ServiceLocator.Find<EventManager>();

        public void OpenMainMenuPopup()
        {
            PopupManager.OpenPopup<MainMenuPopup>().Setup(onPlayButtonClicked: PlayButtonClick);
        }

        private void PlayButtonClick()
        {
            EventManager.Propagate(
                evt: new PlayButtonClickedEvent(),
                sender: this
            );
        }
    }
}