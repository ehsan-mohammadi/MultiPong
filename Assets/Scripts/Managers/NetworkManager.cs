namespace MultiPong.Managers
{
    using Foundation;
    using Factories;
    using Handlers;
    using Handlers.Network;

    public class NetworkManager : IManager
    {
        private const string TAG = "handler";
        private NetworkFactory networkFactory;
        private Container<IHandler> handlers;

        public NetworkManager()
        {
            this.handlers = new Container<IHandler>(TAG);
            AddHandlers();
        }

        public void Setup(NetworkFactory networkFactory)
        {
            this.networkFactory = networkFactory;
            SetupHandlers();
        }

        public void Activate()
        {
            foreach(var handler in handlers.GetAll())
                handler.Activate();
        }

        public void Deactivate()
        {
            foreach(var handler in handlers.GetAll())
                handler.Deactivate();
        }

        private void AddHandlers()
        {
            handlers.Add(new NetworkRunnerHandler());
        }

        private void SetupHandlers()
        {
            handlers.Get<NetworkRunnerHandler>().Setup(
                createNetworkRunner: networkFactory.CreateNetworkRunner,
                createNetworkSceneManager: networkFactory.CreateNetworkSceneManager
            );
        }
    }
}