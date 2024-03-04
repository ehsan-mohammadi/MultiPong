using System;
using System.Collections.Generic;
using UnityEngine;

namespace MultiPong.Data.Settings
{
    [Serializable]
    public class GameplaySettingsData
    {
        [SerializeField] private List<Vector2> spawnPositions;
        [SerializeField] private float paddleSpeed;

        public List<Vector2> SpawnPositions => spawnPositions;
        public float PaddleSpeed => paddleSpeed;
    }
}