using UnityEngine;

namespace MultiPong.Configurations
{
    using Services;

    public abstract class BaseConfiguration : ScriptableObject
    {
        public abstract void Register(ConfigurerService configurerService);
    }

    public abstract class BaseConfiguration<T> : BaseConfiguration
    {
        public abstract void Configure(T target);

        public override void Register(ConfigurerService configurerService)
        {
            configurerService.Register<T>(this);
        }
    }
}