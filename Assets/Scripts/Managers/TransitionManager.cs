namespace MultiPong.Managers
{
    using Services;
    using Handlers.Presentations;

    public class TransitionManager : IManager
    {
        PopupManager PopupManager => ServiceLocator.Find<PopupManager>();

        public void Activate()
        {
        }

        public void Deactivate()
        {
        }

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

        public void GoToGameOver()
        {
            CloseAllPopups();

            var gameOverPresentationHandler = new GameOverPresentationHandler();
            gameOverPresentationHandler.OpenGameOverPopup();
        }

        public void GoToConnectionLost()
        {
            CloseAllPopups();
            
            var connectionLostPresentationHandler = new ConnectionLostPresentationHandler();
            connectionLostPresentationHandler.OpenConnectionLostPopup();
        }

        private void CloseAllPopups()
        {
            PopupManager.CloseAll();
        }
    }
}