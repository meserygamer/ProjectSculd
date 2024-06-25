using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    [RequireComponent(typeof(Button))]
    public class SwitchDifficultButton : MonoBehaviour
    {
        [SerializeField] private CurrentDifficultShelter currentDifficultSwitcher;
        [SerializeField] private GameDifficult buttonDifficult;

        private Button button;


        private void Awake()
        {
            button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            currentDifficultSwitcher.GameDifficultWasChanged += HighlightButton;
        }

        private void OnDisable()
        {
            currentDifficultSwitcher.GameDifficultWasChanged -= HighlightButton;
        }


        public void ChangeCurrentDifficult()
        {
            
            Debug.Log($"Click {buttonDifficult}");
            currentDifficultSwitcher.ChangeGameDifficult(buttonDifficult);
        }

        private void HighlightButton(GameDifficult gameDifficult)
        {
            ColorBlock colorBlock = button.colors;
            if(gameDifficult == buttonDifficult)
                colorBlock.normalColor = Color.red;
            else
                colorBlock.normalColor = Color.white;
            button.colors = colorBlock;
        }
    }
}
