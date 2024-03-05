using Fusion;

namespace MultiPong.Events
{
    public class GoalScoredEvent : IEvent
    {
        public PlayerRef Player { get; private set; }

        public GoalScoredEvent(PlayerRef player)
        {
            this.Player = player;
        }
    }
}