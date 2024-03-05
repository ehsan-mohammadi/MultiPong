namespace MultiPong.Presenters.Gameplay.PowerUps
{
    using Systems.Gameplay;

    public class BallSpeedUpPowerUpPresenter : BasePowerUpPresenter
    {
        protected override PowerUpType Type => PowerUpType.BallSpeedUp;
    }
}