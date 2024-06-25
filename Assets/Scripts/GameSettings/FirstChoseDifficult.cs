using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FirstChoseDifficult : MonoBehaviour
{
    private void Start()
    {
        Button button = GetComponent<Button>();
        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = Color.red;
        button.colors = colorBlock;
        button.onClick.Invoke();
    }
}
