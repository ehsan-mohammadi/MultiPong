namespace MultiPong.Handlers.Presentations
{
    using Managers;
    using Services;
    using Events;
    using Presenters.Popups;

    public class ConnectionLostPresentationHandler : IPresentationHandler
    {
        private PopupManager PopupManager => ServiceLocator.Find<PopupManager>();
        private EventManager EventManager => ServiceLocator.Find<EventManager>();

        public void OpenConnectionLostPopup()
        {
            PopupManager.OpenPopup<ConnectionLostPopup>().Setup(onRestartButtonClicked: RestartButtonClick);
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