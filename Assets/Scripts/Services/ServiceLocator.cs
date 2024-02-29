namespace MultiPong.Services
{
    using Foundation;

    public static class ServiceLocator
    {
        private const string TAG = "service";
        private static Container<IService> services;

        public static void Initialize()
        {
            services = new Container<IService>(TAG);
        }

        public static void Register(IService service) => services.Add(service);

        public static T Find<T>() where T : IService => services.Get<T>();
    }
}