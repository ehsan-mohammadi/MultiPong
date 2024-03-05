using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fusion;

namespace MultiPong.Presenters.Gameplay
{
    public class EnvironmentPresenter : NetworkPresenter
    {
        [SerializeField] private List<GoalPresenter> goals;

        public void Setup(List<PlayerRef> players)
        {
            for(int i = 0; i < goals.Count; i++)
                goals[i].Setup(player: players[i]);
        }
    }
}