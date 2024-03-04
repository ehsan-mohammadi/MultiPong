using System;
using UnityEngine;

namespace MultiPong.Data.Settings
{
    [Serializable]
    public class NetworkSettingsData
    {
        [SerializeField] private string sessionName;
        [SerializeField] private int maxPlayers;

        public string SessionName => sessionName;
        public int MaxPlayers => maxPlayers;
    }
}