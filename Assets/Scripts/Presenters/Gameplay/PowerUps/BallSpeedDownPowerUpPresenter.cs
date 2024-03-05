namespace MultiPong.Presenters.Gameplay.PowerUps
{
    using Systems.Gameplay;

    public class BallSpeedDownPowerUpPresenter : BasePowerUpPresenter
    {
        protected override PowerUpType Type => PowerUpType.BallSpeedDown;
    }
}