using Scripts;
using System;
using UnityEngine;

namespace Scripts
{
    public class ItemsBasketZone : MonoBehaviour
    {
        public event Action<bool> NotifyItemWasDroppedInBasket;


        #region MonoBehaviour
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
                return;
            NotifyItemWasDroppedInBasket?.Invoke(other.gameObject.GetComponent<DangerousItem>() is not null);
            Destroy(other.gameObject);
        }
        #endregion
    }
}
