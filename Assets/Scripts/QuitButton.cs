using UnityEngine;

public class QuitButton : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.End) || Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
