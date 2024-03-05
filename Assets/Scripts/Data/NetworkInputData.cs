using Fusion;

namespace MultiPong.Data
{
    public struct NetworkInputData : INetworkInput, IBlackboardData
    {
        public float Movement { get; set; }
    }
}