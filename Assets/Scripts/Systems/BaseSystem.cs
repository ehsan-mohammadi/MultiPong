namespace MultiPong.Systems
{
    public abstract class BaseSystem
    {
        public abstract void Activate();

        public abstract void Deactivate();

        public virtual void Update()
        {
        }

        public virtual void FixedUpdate()
        {   
        }
    }
}