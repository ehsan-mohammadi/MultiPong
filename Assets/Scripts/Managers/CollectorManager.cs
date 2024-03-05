using UnityEngine;
using Fusion;

namespace MultiPong.Managers
{
    using Presenters;
    using Presenters.Gameplay;
    using Presenters.Gameplay.PowerUps;
    
    public class CollectorManager : IManager
    {
        public void Activate()
        {
        }

        public void Deactivate()
        {
        }

        public void CollectNetworkServices()
        {
            DestroyObjectOfType<NetworkRunner>();
            DestroyObjectOfType<NetworkSceneManagerDefault>();
        }

        public void CollectNetworkPresenters()
        {
            DespawnPresentersOfType<PaddlePresenter>();
            DespawnPresentersOfType<BallPresenter>();
            DespawnPresentersOfType<BasePowerUpPresenter>();
            DespawnPresentersOfType<EnvironmentPresenter>();
            DespawnPresentersOfType<HUDPresenter>();
        }

        private void DespawnPresentersOfType<T>() where T : NetworkPresenter
        {
            var presenters = GameObject.FindObjectsOfType<T>();

            foreach(var presenter in presenters)
                presenter.Despawn();
        }

        private void DestroyObjectOfType<T>() where T : MonoBehaviour
        {
            Object.Destroy(GameObject.FindObjectOfType<T>().gameObject);
        }
    }
}