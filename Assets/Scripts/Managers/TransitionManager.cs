namespace MultiPong.Managers
{
    using Handlers.Presentaions;

    public class TransitionManager
    {
        public void GoToMainMenu()
        {
            var mainMenuPresentationHandler = new MainMenuPresentationHandler();
            mainMenuPresentationHandler.OpenMainMenuPopup();
        }
    }
}