using UnityEngine;
using Fusion;

namespace MultiPong.Presenters
{
    [RequireComponent(typeof(NetworkObject))]
    public abstract class NetworkPresenter : NetworkBehaviour, IPresenter
    {
        public void Despawn()
        {
            Runner.Despawn(Object);
        }
    }
}