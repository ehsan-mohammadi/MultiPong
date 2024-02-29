namespace MultiPong.Handlers.Presentaions
{
    using Managers;
    using Services;
    using Presenters.Popups;

    public class WaitingForOpponentPresentationHandler : IHandler
    {
        private PopupManager PopupManager => ServiceLocator.Find<PopupManager>();

        public void OpenWaitingForOpponentPopup()
        {
            PopupManager.OpenPopup<WaitingForOpponentPopup>();
        }
    }
}