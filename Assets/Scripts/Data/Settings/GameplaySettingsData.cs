using System;
using System.Collections.Generic;
using UnityEngine;

namespace MultiPong.Data.Settings
{
    [Serializable]
    public class GameplaySettingsData
    {
        [SerializeField] private int gameTime;
        [SerializeField] private List<Vector2> spawnPositions;
        [SerializeField] private float paddleSpeed;
        [SerializeField] private float ballSpeed;

        public int GameTime => gameTime;
        public List<Vector2> SpawnPositions => spawnPositions;
        public float PaddleSpeed => paddleSpeed;
        public float BallSpeed => ballSpeed;
    }
}