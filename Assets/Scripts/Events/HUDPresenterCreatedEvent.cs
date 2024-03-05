namespace MultiPong.Events
{
    using Presenters.Gameplay;

    public class HUDPresenterCreatedEvent : IEvent
    {
        public HUDPresenter Presenter { get; private set; }

        public HUDPresenterCreatedEvent(HUDPresenter presenter)
        {
            this.Presenter = presenter;
        }
    }
}