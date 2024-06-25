using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class GameOverChecker : MonoBehaviour
    {
        [SerializeField] private ItemBasketCollisionFixator _itemBasketCollisionFixator;
        [SerializeField] private GameTimer _gameTimer;
        [SerializeField] private string _statisticsSceneName;


        private void OnEnable()
        {
            _itemBasketCollisionFixator.DangerousItemCountWasChanged += 
                CheckItemCountOnRequirements;
            _gameTimer.NotifyTimeIsOver += EndGameWithNegativeResult;
        }

        private void OnDisable()
        {
            _itemBasketCollisionFixator.DangerousItemCountWasChanged -=
                CheckItemCountOnRequirements;
            _gameTimer.NotifyTimeIsOver -= EndGameWithNegativeResult;
        }


        private void CheckItemCountOnRequirements()
        {
            if(_itemBasketCollisionFixator.IsTargetNumberDangerousItemHasBeenMet)
                EndGameWithPositiveResult();
        }

        private void EndGameWithPositiveResult()
        {
            _gameTimer.SetTimerOnPause();
            GoToStatisticsScene();
        }

        private void EndGameWithNegativeResult()
        {
            GoToStatisticsScene();
        }

        private void GoToStatisticsScene()
        {
            LastGameStatistics.lastGameStatistics = new GameStatistics()
            {
                RemainingTime = _gameTimer.RemainingTime,
                CollectedDangerousItems = _itemBasketCollisionFixator.DangerousItemsCount,
                AllDangerousItemsOnScene = _itemBasketCollisionFixator.DangerousitemsCountOnScene,
                CollectedBasicItems = _itemBasketCollisionFixator.NonDangerousItemsCount
            };
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene(_statisticsSceneName);
        }
    }
}
