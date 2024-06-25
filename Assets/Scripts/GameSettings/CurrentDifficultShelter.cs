using System;
using TMPro;
using UnityEngine;

namespace Scripts
{
    public class CurrentDifficultShelter : MonoBehaviour
    {
        [SerializeField] private CurrentDifficultEditor _currentDifficultEditor;
        [SerializeField] private GameDifficult _customDifficult;
        [SerializeField] private DifficultSettingsDisplayer _difficultSettingsDisplayer;

        [SerializeField] private GameDifficult DefaultGameDifficult;


        public GameDifficult CurrentGameDifficult { get; private set; } = null;


        public event Action<GameDifficult> GameDifficultWasChanged;


        private void Start()
        {
            ChangeGameDifficult(DefaultGameDifficult);
        }

        private void OnEnable()
        {
            if(_currentDifficultEditor is not null)
            _currentDifficultEditor.NotifyUserWantChangeDifficultSetting += SwitchOnCustomDifficult;
        }

        private void OnDisable()
        {
            if(_currentDifficultEditor is not null)
            _currentDifficultEditor.NotifyUserWantChangeDifficultSetting -= SwitchOnCustomDifficult;
        }


        public void ChangeGameDifficult(GameDifficult gameDifficult)
        {
            if (gameDifficult == null)
                return;
            if(gameDifficult != CurrentGameDifficult)
                _difficultSettingsDisplayer.UpdateDisplayingDataWithDifficult(gameDifficult);
            CurrentGameDifficult = gameDifficult;
            GameDifficultWasChanged?.Invoke(CurrentGameDifficult);
        }

        private void SwitchOnCustomDifficult()
        {
            if(CurrentGameDifficult != _customDifficult)
                ChangeGameDifficult(_customDifficult);
        } 
    }
}
