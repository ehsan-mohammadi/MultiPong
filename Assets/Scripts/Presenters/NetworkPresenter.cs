using UnityEngine;
using Fusion;

namespace MultiPong.Presenters
{
    [RequireComponent(typeof(NetworkObject))]
    public abstract class NetworkPresenter : NetworkBehaviour, IPresenter
    {
    }
}