namespace MultiPong.Handlers.Presentations
{
    using Managers;
    using Services;
    using Events;
    using Presenters.Popups;

    public class GameOverPresentationHandler : IPresentationHandler
    {
        private PopupManager PopupManager => ServiceLocator.Find<PopupManager>();
        private EventManager EventManager => ServiceLocator.Find<EventManager>();

        public void OpenGameOverPopup()
        {
            PopupManager.OpenPopup<GameOverPopup>().Setup(onRestartButtonClicked: RestartButtonClick);
        }

        private void RestartButtonClick()
        {
            EventManager.Propagate(
                evt: new RestartButtonClickedEvent(),
                sender: this
            );
        }
    }
}