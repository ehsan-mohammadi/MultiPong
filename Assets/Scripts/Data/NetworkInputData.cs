using Fusion;

namespace MultiPong.Data
{
    public class NetworkInputData : INetworkInput, IBlackboardData
    {
        public float Movement { get; set; }
    }
}