using Scripts;
using System;
using UnityEngine;
using UnityEngine.Networking;

public class SendToServer : MonoBehaviour
{
    private const string SERVER_LINK = "https://docs.unity3d.com";

    void Start()
    {
        GameStatistics gameStatistics = LastGameStatistics.lastGameStatistics;
        Debug.Log(JsonUtility.ToJson(new GameInfoToServer()
        {
            RemainingTime = gameStatistics.RemainingTime.ToString(),
            CollectedDangerousItems = gameStatistics.CollectedDangerousItems,
            AllDangerousItemsOnScene = gameStatistics.AllDangerousItemsOnScene,
            CollectedBasicItems = gameStatistics.CollectedBasicItems
        }));
        UnityWebRequest request = UnityWebRequest.Post(SERVER_LINK, JsonUtility.ToJson(new GameInfoToServer()
        {
            RemainingTime = gameStatistics.RemainingTime.ToString(),
            CollectedDangerousItems = gameStatistics.CollectedDangerousItems,
            AllDangerousItemsOnScene = gameStatistics.AllDangerousItemsOnScene,
            CollectedBasicItems = gameStatistics.CollectedBasicItems
        }), "application/json");
        request.SendWebRequest();
        Debug.Log("Сообщение отправлено!");
    }
}

[Serializable]
public class GameInfoToServer
{
    public string Type = "VR_GAME";

    public string GameName = "PROJECT_SCULD";

    public string RemainingTime;

    public int CollectedDangerousItems;

    public int AllDangerousItemsOnScene;

    public int CollectedBasicItems;
}
