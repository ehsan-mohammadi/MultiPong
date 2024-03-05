using Fusion;

namespace MultiPong.Presenters.Gameplay
{
    public class GoalPresenter : GeneralPresenter
    {
        private PlayerRef player;

        public PlayerRef Player => player;
        
        public void Setup(PlayerRef player)
        {
            this.player = player;
        }
    }
}