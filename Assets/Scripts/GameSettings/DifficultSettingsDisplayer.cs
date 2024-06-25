using System;
using TMPro;
using UnityEngine;

namespace Scripts
{
    public class DifficultSettingsDisplayer : MonoBehaviour
    {
        [SerializeField] private CurrentDifficultShelter _currentDifficultShelter;
        [SerializeField] private TextMeshProUGUI _timeTextField;
        [SerializeField] private TextMeshProUGUI _MinItemTextField;
        [SerializeField] private TextMeshProUGUI _MaxItemTextField;


        public void UpdateDisplayingDataWithShelter()
        {
            _timeTextField.text = TimeSpan
                                        .FromSeconds(_currentDifficultShelter.CurrentGameDifficult.timeInSecondToFindAllDangerousItems)
                                        .ToString();
            _MinItemTextField.text = _currentDifficultShelter.CurrentGameDifficult.fromDangerousObjectsCount.ToString();
            _MaxItemTextField.text = _currentDifficultShelter.CurrentGameDifficult.toDangerousObjectsCount.ToString();
        }

        public void UpdateDisplayingDataWithDifficult(GameDifficult gameDifficult)
        {
            _timeTextField.text = TimeSpan
                                        .FromSeconds(gameDifficult.timeInSecondToFindAllDangerousItems)
                                        .ToString();
            _MinItemTextField.text = gameDifficult.fromDangerousObjectsCount.ToString();
            _MaxItemTextField.text = gameDifficult.toDangerousObjectsCount.ToString();
        }
    }
}
