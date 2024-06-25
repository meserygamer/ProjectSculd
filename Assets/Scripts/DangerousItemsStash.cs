using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class DangerousItemsStash : MonoBehaviour
    {

        private ICollection<DangerousItem> _collectedDangerousItems;


        public event Action DangerousItemsCountWasChanged;


        public int DangerousItemsCount =>
            _collectedDangerousItems.Count;


        #region MonoBehaviour

        private void Awake()
        {
            _collectedDangerousItems = new HashSet<DangerousItem>();
        }

        private void OnTriggerEnter(Collider other)
        {
            DangerousItem gameObject = other.gameObject.GetComponent<DangerousItem>();
            if (gameObject is not null)
                AddDangerousItemInStash(gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            DangerousItem gameObject = other.gameObject.GetComponent<DangerousItem>();
            if (gameObject is not null)
                RemoveDangerousItemFromStash(gameObject);
        }

        #endregion


        private void AddDangerousItemInStash(DangerousItem item)
        {
            _collectedDangerousItems.Add(item);
            DangerousItemsCountWasChanged?.Invoke();
        }

        private void RemoveDangerousItemFromStash(DangerousItem item)
        {
            _collectedDangerousItems.Remove(item);
            DangerousItemsCountWasChanged?.Invoke();
        }

    }
}