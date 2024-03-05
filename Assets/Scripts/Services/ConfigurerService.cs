using System;
using System.Collections.Generic;

namespace MultiPong.Services
{
    using Configurations;

    public class ConfigurerService : IService
    {
        private Dictionary<Type, BaseConfiguration> configurations;

        public void Initialize()
        {
            configurations = new Dictionary<Type, BaseConfiguration>();
            ServiceLocator.Register(this);
        }

        public void Register<T>(BaseConfiguration<T> configuration)
        {
            configurations.Add(typeof(T), configuration);
        }

        public void Configure<T>(T target)
        {
            FindConfiguration<T>().Configure(target);
        }

        private BaseConfiguration<T> FindConfiguration<T>()
        {
            Type type = typeof(T);

            if (!configurations.ContainsKey(type))
                throw new Exception($"The configuration of type '{type}' does not found.");
            
            return configurations[type] as BaseConfiguration<T>;
        }
    }
}