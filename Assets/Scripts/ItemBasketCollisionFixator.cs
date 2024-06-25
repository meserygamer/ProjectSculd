using System;
using TMPro;
using UnityEngine;

namespace Scripts
{
    public class ItemBasketCollisionFixator : MonoBehaviour
    {
        [SerializeField] private ItemsBasketZone _checkedBasket;
        [SerializeField] private TextMeshPro _targetStateDisplayer;
        [SerializeField] private DangerousItemSpawner _dangerousItemSpawner;


        public event Action DangerousItemCountWasChanged;


        public int DangerousItemsCount { get; private set; }
        public int NonDangerousItemsCount { get; private set; }
        public int DangerousitemsCountOnScene { get; private set; }

        public bool IsTargetNumberDangerousItemHasBeenMet =>
            DangerousItemsCount == DangerousitemsCountOnScene;


        #region MonoBehavior
        private void OnEnable()
        {
            _dangerousItemSpawner.NotifyDangerousItemsWasSpawned += UpdateCountDangerousItemsOnScene;
            _checkedBasket.NotifyItemWasDroppedInBasket += ChangeDroppedItemsCount;
        }

        private void OnDisable()
        {
            _dangerousItemSpawner.NotifyDangerousItemsWasSpawned -= UpdateCountDangerousItemsOnScene;
            _checkedBasket.NotifyItemWasDroppedInBasket -= ChangeDroppedItemsCount;
        }
        #endregion


        private void ChangeDroppedItemsCount(bool isDangerousItem)
        {
            if(isDangerousItem)
                DangerousItemsCount++;
            else
                NonDangerousItemsCount++;
            UpdateDisplayingDangerousItemsCount();
            DangerousItemCountWasChanged?.Invoke();
        }

        private void UpdateDisplayingDangerousItemsCount() =>
                _targetStateDisplayer.text = $"{DangerousItemsCount} Предметов из {DangerousitemsCountOnScene}";

        private void UpdateCountDangerousItemsOnScene()
        {
            DangerousitemsCountOnScene = _dangerousItemSpawner.LastGeneratedDangerousItemsCount;
            UpdateDisplayingDangerousItemsCount();
        }
    }
}
