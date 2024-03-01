namespace MultiPong.Managers
{
    using Services;
    using Handlers.Presentaions;

    public class TransitionManager : IManager
    {
        PopupManager PopupManager => ServiceLocator.Find<PopupManager>();

        public void GoToMainMenu()
        {
            CloseAllPopups();
            
            var mainMenuPresentationHandler = new MainMenuPresentationHandler();
            mainMenuPresentationHandler.OpenMainMenuPopup();
        }

        public void GoToWaitingForOpponent()
        {
            CloseAllPopups();

            var waitingForOpponentPresentationHandler = new WaitingForOpponentPresentationHandler();
            waitingForOpponentPresentationHandler.OpenWaitingForOpponentPopup();
        }

        public void GoToPlay()
        {
            CloseAllPopups();
        }

        private void CloseAllPopups()
        {
            PopupManager.CloseAll();
        }
    }
}