using Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class StartGameScript : MonoBehaviour
    {
        [SerializeField] private CurrentDifficultShelter _currentDifficultShelter;


        public void StartGameScene()
        {
            GameSettingSaver.CurrentGameDifficult = _currentDifficultShelter.CurrentGameDifficult;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
