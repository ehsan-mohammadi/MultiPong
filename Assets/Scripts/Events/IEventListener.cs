namespace MultiPong.Events
{
    public interface IEventListener
    {
        void OnEvent(IEvent evt, object sender);
    }
}