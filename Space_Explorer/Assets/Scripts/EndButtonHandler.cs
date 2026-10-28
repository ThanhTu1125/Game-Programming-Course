using UnityEngine;

public class EndButtonHandler : MonoBehaviour
{
    public void OnRestartClick()
    {
        if (SceneController.instance != null)
            SceneController.instance.LoadGameplay();
    }

    public void OnMenuClick()
    {
        if (SceneController.instance != null)
            SceneController.instance.LoadMainMenu();
    }
}