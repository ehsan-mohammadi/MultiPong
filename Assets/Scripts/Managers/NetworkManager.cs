using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Fusion;
using Fusion.Sockets;

namespace MultiPong.Managers
{
    using Factories;
    using Services;
    using Systems.Gameplay;
    using Events;
    using Settings;
    using Data;
    using Data.Settings;

    public class NetworkManager : IManager, IService, INetworkRunnerCallbacks
    {
        private readonly NetworkFactory networkFactory;
        private readonly List<PlayerRef> players;
        
        private NetworkRunner networkRunner;
        private NetworkSceneManagerDefault networkSceneManager;

        private EventManager EventManager => ServiceLocator.Find<EventManager>();
        private BlackboardSystem BlackboardSystem => ServiceLocator.Find<BlackboardSystem>();
        private NetworkSettingsData NetworkSettings => GameSettings.Instance.Network;

        public List<PlayerRef> Players => players.OrderBy(player => player.PlayerId).ToList();
        public NetworkRunner NetworkRunner => networkRunner;

        public NetworkManager()
        {
            this.networkFactory = new NetworkFactory();
            this.players = new List<PlayerRef>();
            ServiceLocator.Register(this);
        }

        public void Activate()
        {
            networkRunner = networkFactory.CreateNetworkRunner();
            networkSceneManager = networkFactory.CreateNetworkSceneManager();

            AddNetworkRunnerCallbacks();
            StartGame(GameMode.AutoHostOrClient);
        }

        public void Deactivate()
        {
            ServiceLocator.Unregister(this);
        }

        public void OnConnectedToServer(NetworkRunner runner)
        {
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
        }

        public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
        {
        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
            if (BlackboardSystem == default)
                return;
            
            input.Set(BlackboardSystem.GetData<NetworkInputData>());
        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
        }

        public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
        }

        public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
        }

        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            UnityEngine.Debug.Log($"Player joined with id: {player.PlayerId}");
            players.Add(player);

            if (players.Count == NetworkSettings.MaxPlayers)
                EventManager.Propagate(
                    evt: new AllPlayersJoinedEvent(),
                    sender: this
                );
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
            UnityEngine.Debug.Log($"Player left with id: {player.PlayerId}");
            players.Remove(player);

            if (player == runner.LocalPlayer)
                return;
           
            EventManager.Propagate(
                evt: new ConnectionLostEvent(),
                sender: this
            );
        }

        public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
        {
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
        {
        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {
        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {
        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
            EventManager.Propagate(
                evt: new ConnectionLostEvent(),
                sender: this
            );
        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
        }

        private void AddNetworkRunnerCallbacks() => networkRunner.AddCallbacks(this);

        public void RemoveNetworkRunnerCallbacks() => networkRunner.RemoveCallbacks(this);

        private async void StartGame(GameMode mode)
        {
            networkRunner.ProvideInput = true;
            var scene = SceneRef.FromIndex(
                index: SceneManager.GetActiveScene().buildIndex
            );

            await networkRunner.StartGame(
                new StartGameArgs() {
                    GameMode = mode,
                    Scene = scene,
                    SceneManager = networkSceneManager,
                    PlayerCount = NetworkSettings.MaxPlayers,
                    SessionName = NetworkSettings.SessionName
                }
            );
        }
    }
}