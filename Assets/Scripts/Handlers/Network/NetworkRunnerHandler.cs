using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Fusion;
using Fusion.Sockets;

namespace MultiPong.Handlers.Network
{
    using Utilities;

    public class NetworkRunnerHandler : IHandler, INetworkRunnerCallbacks
    {
        private NetworkRunner networkRunner;
        private NetworkSceneManagerDefault networkSceneManager;

        private Func<NetworkRunner> createNetworkRunner;
        private Func<NetworkSceneManagerDefault> createNetworkSceneManager;

        public void Setup(
            Func<NetworkRunner> createNetworkRunner,
            Func<NetworkSceneManagerDefault> createNetworkSceneManager
        )
        {
            this.createNetworkRunner = createNetworkRunner;
            this.createNetworkSceneManager = createNetworkSceneManager;
        }

        public void Activate()
        {
            networkRunner = createNetworkRunner.Invoke();
            networkSceneManager = createNetworkSceneManager.Invoke();
            StartGame(GameMode.AutoHostOrClient);
        }

        public void Deactivate()
        {
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
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
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
        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
        }

        private async void StartGame(GameMode mode)
        {
            networkRunner.ProvideInput = true;
            var scene = SceneRef.FromIndex(
                index: SceneManager.GetActiveScene().buildIndex
            );

            await networkRunner.StartGame(new StartGameArgs()
                {
                    GameMode = mode,
                    SessionName = IdentificationUtility.GenerateSessionId(),
                    Scene = scene,
                    SceneManager = networkSceneManager
                }
            );
        }
    }
}