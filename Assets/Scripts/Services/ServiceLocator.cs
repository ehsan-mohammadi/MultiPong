namespace MultiPong.Services
{
    using Foundation;

    public static class ServiceLocator
    {
        private static Container<IService> services;

        public static void Initialize()
        {
            services = new Container<IService>();
        }

        public static void Register(IService service) => services.Add(service);

        public static void Unregister(IService service) => services.Remove(service);

        public static T Find<T>() where T : IService
        {
            var type = typeof(T);

            if (services.IsExists(type))
                return services.Get<T>();
            
            return default;
        }
    }
}