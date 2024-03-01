using System.Collections.Generic;

namespace MultiPong.Managers
{
    using Services;
    using Events;

    public class EventManager: IManager, IService
    {
        private readonly List<IEventListener> listeners;

        public EventManager()
        {
            this.listeners = new List<IEventListener>();
            ServiceLocator.Register(this);
        }

        public void Register(IEventListener listener)
        {
            if (listeners.Contains(listener))
                return;
            
            listeners.Add(listener);
        }

        public void Unregister(IEventListener listener)
        {
            listeners.Remove(listener);
        }

        public void Propagate(IEvent evt, object sender)
        {
            foreach(var listener in listeners)
                listener.OnEvent(evt, sender);
        }
    }
}