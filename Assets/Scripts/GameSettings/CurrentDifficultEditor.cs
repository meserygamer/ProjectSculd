using System;
using TMPro;
using UnityEngine;

namespace Scripts
{
    public class CurrentDifficultEditor : MonoBehaviour
    {
        [SerializeField] private CurrentDifficultShelter _currentDifficultShelter;
        [SerializeField] private DifficultSettingsDisplayer _difficultSettingsDisplayer;

        [SerializeField]
        [Min(1)]
         private int _deltaTime = 30;
        [SerializeField]
        [Min(1)]
         private int _maxTime = 600;
        [SerializeField]
        [Min(1)]
        private int _maxItemCount = 12;

        
        public event Action NotifyUserWantChangeDifficultSetting;


        private int TimeInSecondToFindAllDangerousItems
        {
            get => _currentDifficultShelter.CurrentGameDifficult.timeInSecondToFindAllDangerousItems;
            set
            {
                GameDifficult gameDifficult = _currentDifficultShelter.CurrentGameDifficult;
                gameDifficult.timeInSecondToFindAllDangerousItems = value;
                _difficultSettingsDisplayer.UpdateDisplayingDataWithShelter();
            }
        }
        private int MinItemCount
        {
            get => _currentDifficultShelter.CurrentGameDifficult.fromDangerousObjectsCount;
            set
            {
                GameDifficult gameDifficult = _currentDifficultShelter.CurrentGameDifficult;
                gameDifficult.fromDangerousObjectsCount = value;
                _difficultSettingsDisplayer.UpdateDisplayingDataWithShelter();
            }
        }
        private int MaxItemCount
        {
            get => _currentDifficultShelter.CurrentGameDifficult.toDangerousObjectsCount;
            set
            {
                GameDifficult gameDifficult = _currentDifficultShelter.CurrentGameDifficult;
                gameDifficult.toDangerousObjectsCount = value;
                _difficultSettingsDisplayer.UpdateDisplayingDataWithShelter();
            }
        }


        public void IncreaseTime()
        {
            NotifyUserWantChangeDifficultSetting?.Invoke();
            if(TimeInSecondToFindAllDangerousItems + _deltaTime > _maxTime)
                return;
            TimeInSecondToFindAllDangerousItems += _deltaTime;
        }

        public void DecreaseTime()
        {
            NotifyUserWantChangeDifficultSetting?.Invoke();
            if(TimeInSecondToFindAllDangerousItems - _deltaTime <= 0)
                return;
            TimeInSecondToFindAllDangerousItems -= _deltaTime;
        } 

        public void IncreaseMinItemCount()
        {
            NotifyUserWantChangeDifficultSetting?.Invoke();
            if(MinItemCount < MaxItemCount)
                MinItemCount++;
        }

        public void DecreaseMinItemCount()
        {
            NotifyUserWantChangeDifficultSetting?.Invoke();
            if(MinItemCount > 1)
                MinItemCount--;
        } 
    
        public void IncreaseMaxItemCount()
        {
            NotifyUserWantChangeDifficultSetting?.Invoke();
            if(MaxItemCount < _maxItemCount)
                MaxItemCount++;
        }

        public void DecreaseMaxItemCount()
        {
            NotifyUserWantChangeDifficultSetting?.Invoke();
            if(MaxItemCount > MinItemCount)
                MaxItemCount--;
        } 
    }
}
