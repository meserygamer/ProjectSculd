using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneNavigator : MonoBehaviour
{
    [SerializeField] private string _gameDifficultMenuScene;
    [SerializeField] private string _mainGameScene;


    public void GoToGameDifficultMenu()
    {
        SceneManager.LoadScene(_gameDifficultMenuScene);
    }

    public void GoToMainGameScene()
    {
        SceneManager.LoadScene(_mainGameScene);
    }
}
