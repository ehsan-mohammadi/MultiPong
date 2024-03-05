namespace MultiPong.Data
{
    using Presenters.Gameplay;

    public class BallData : IBlackboardData
    {
        public BallPresenter Presenter { get; set; }

        public BallData(BallPresenter presenter)
        {
            this.Presenter = presenter;
        }
    }
}