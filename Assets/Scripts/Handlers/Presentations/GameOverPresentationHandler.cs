namespace MultiPong.Handlers.Presentations
{
    using Managers;
    using Services;
    using Presenters.Popups;

    public class GameOverPresentationHandler : IPresentationHandler
    {
        private PopupManager PopupManager => ServiceLocator.Find<PopupManager>();

        public void OpenGameOverPopup()
        {
            PopupManager.OpenPopup<GameOverPopup>();
        }
    }
}