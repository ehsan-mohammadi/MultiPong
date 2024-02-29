namespace MultiPong.Managers
{
    using Services;
    using Presenters.Popups;

    public class TransitionManager
    {
        private PopupManager PopupManager => ServiceLocator.Find<PopupManager>();

        public void GoToMainMenu()
        {
            PopupManager.OpenPopup<MainMenuPopup>();
        }
    }
}