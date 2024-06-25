using System;
using System.Threading;
using TMPro;
using UnityEngine;

namespace Scripts
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _remainingSecondsTime;
        [SerializeField] private TextMeshPro _displayForTime;

        private TimeSpan _remainingTime;
        private TimerStatus _timerStatus;


        public event Action NotifyTimeIsOver;


        private enum TimerStatus
        {
            Enabled,
            Paused,
            Disabled
        }


        public TimeSpan RemainingTime => _remainingTime;


        #region MonoBehavior
        private void Start()
        {
            if (GameSettingSaver.CurrentGameDifficult is not null)
                _remainingTime = TimeSpan.FromSeconds(GameSettingSaver
                .CurrentGameDifficult
                .timeInSecondToFindAllDangerousItems);
            else
                _remainingTime = TimeSpan.FromSeconds(_remainingSecondsTime);
            _timerStatus = TimerStatus.Enabled;
            new Thread(Tick).Start();
        }

        private void OnDestroy()
        {
            _timerStatus = TimerStatus.Disabled;
        }
        #endregion


        public void SetTimerOnPause()
        {
            _timerStatus = TimerStatus.Paused;
        }

        private void Tick()
        {
            while (_remainingTime.TotalSeconds > 0d) 
            {
                if (_timerStatus == TimerStatus.Paused)
                    continue;
                if (_timerStatus == TimerStatus.Disabled)
                    return;
                Thread.Sleep(1000);
                _remainingTime = _remainingTime.Subtract(TimeSpan.FromSeconds(1d));
                if (_displayForTime is not null)
                    #if UNITY_EDITOR
                    UnityEditor.Search.Dispatcher.Enqueue(() =>
                    {
                        _displayForTime.text = _remainingTime.ToString();
                    });
                    #else
                        _displayForTime.text = _remainingTime.ToString();
                    #endif
            }
#if UNITY_EDITOR
            UnityEditor.Search.Dispatcher.Enqueue(() =>
            {
                NotifyTimeIsOver?.Invoke();
            });
#else
            NotifyTimeIsOver?.Invoke();
#endif
        }
    }
}
