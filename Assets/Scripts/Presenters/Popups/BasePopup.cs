using UnityEngine;

namespace MultiPong.Presenters.Popups
{
    public abstract class BasePopup : MonoBehaviour, IPresenter
    {
        public void Close()
        {
            Destroy(this.gameObject);
        }
    }
}