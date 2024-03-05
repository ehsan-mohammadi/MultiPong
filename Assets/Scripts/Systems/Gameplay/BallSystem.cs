using UnityEngine;

namespace MultiPong.Systems.Gameplay
{
    using Managers;
    using Managers.Gameplay;
    using Services;
    using Settings;
    using Events;
    using Presenters;
    using Presenters.Gameplay;
    using Data;
    using Data.Settings;

    public class BallSystem : GameplaySystem
    {
        private const float MIN_OFFSET = 0.25f;
        private const float MAX_DIRECTION = 1f;
        private float speedFactor = 1;
        private BallData ballData;

        private GameplaySettingsData GameplaySettings => GameSettings.Instance.Gameplay;

        public BallSystem(GameplayManager gameplayManager, ActivationMode activationMode)
            : base(gameplayManager, activationMode)
        {
        }

        public override void Activate()
        {
            ballData = GetBlackBoardData<BallData>();
            ballData.Presenter.Setup(onCollision: OnCollision);
            ballData.Presenter.SetVelocity(GenerateRandomDirection());
        }

        public override void Deactivate()
        {
        }

        private void OnCollision(Collision2D collision)
        {
            IPresenter collisionPresenter = collision.gameObject.GetComponent<IPresenter>();
            
            switch(collisionPresenter)
            {
                case PaddlePresenter paddle:
                    var returnedDirection = CalculateReturnedDirectionFromPaddle(collision.collider);
                    ballData.Presenter.SetVelocity(returnedDirection);
                    break;
                case GoalPresenter goal:
                    ServiceLocator.Find<EventManager>().Propagate(
                        evt: new GoalScoredEvent(goal.Player),
                        sender: this
                    );
                    ballData.Presenter.SetPosition(Vector2.zero);
                    ballData.Presenter.SetVelocity(GenerateRandomDirection());
                    break;
                default:
                    break;
            }
        }

        private Vector2 GenerateRandomDirection()
        {
            ResetSpeedFactor();
            return new Vector2(
                x: Mathf.Sign(Random.Range(-1f, 1f)),
                y: 0
            ) * GameplaySettings.BallSpeed;
        }

        private Vector2 CalculateReturnedDirectionFromPaddle(Collider2D collider)
        {
            Vector2 ballPosition = ballData.Presenter.transform.position;
            Vector2 colliderPosition = collider.transform.position;
            Vector2 returnedDirection = new Vector2();

            returnedDirection.x = ballPosition.x > 0 ? -MAX_DIRECTION : MAX_DIRECTION;
            returnedDirection.y = (ballPosition.y - colliderPosition.y) / collider.bounds.size.y;

            if (returnedDirection.y == 0)
                returnedDirection.y = MIN_OFFSET;

            IncreaseSpeedFactor();
            return returnedDirection.normalized * GameplaySettings.BallSpeed * speedFactor;
        }

        private void ResetSpeedFactor() => speedFactor = 1;
        
        private void IncreaseSpeedFactor() => speedFactor += GameplaySettings.BallSpeedFactor;
    }
}