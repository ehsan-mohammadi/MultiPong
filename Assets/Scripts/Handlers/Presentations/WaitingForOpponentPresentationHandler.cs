namespace MultiPong.Handlers.Presentations
{
    using Managers;
    using Services;
    using Presenters.Popups;

    public class WaitingForOpponentPresentationHandler : IPresentationHandler
    {
        private PopupManager PopupManager => ServiceLocator.Find<PopupManager>();

        public void OpenWaitingForOpponentPopup()
        {
            PopupManager.OpenPopup<WaitingForOpponentPopup>();
        }
    }
}