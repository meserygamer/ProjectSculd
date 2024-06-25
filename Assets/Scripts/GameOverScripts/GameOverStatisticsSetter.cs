using Scripts;
using TMPro;
using UnityEngine;

public class GameOverStatisticsSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CollectedDangerousItemsTextMesh;
    [SerializeField] private TextMeshProUGUI CollectedBasicItemsTextMesh;
    [SerializeField] private TextMeshProUGUI RemainingTimeTextMesh;
    [SerializeField] private TextMeshProUGUI DifficultLevelTextMesh;


    private void Start()
    {
        SetStatisticsIntoCanvas();
    }


    private void SetStatisticsIntoCanvas()
    {
        if (LastGameStatistics.lastGameStatistics is null)
            return;
        GameStatistics gameStatistics = LastGameStatistics.lastGameStatistics;
        CollectedDangerousItemsTextMesh.text = gameStatistics.CollectedDangerousItems.ToString() + " из " + gameStatistics.AllDangerousItemsOnScene;
        CollectedBasicItemsTextMesh.text = gameStatistics.CollectedBasicItems.ToString();
        RemainingTimeTextMesh.text = gameStatistics.RemainingTime.ToString();
        if (GameSettingSaver.CurrentGameDifficult is null)
            return;
        DifficultLevelTextMesh.text = GameSettingSaver.CurrentGameDifficult.GameDifficultLevelName;
    }
}
