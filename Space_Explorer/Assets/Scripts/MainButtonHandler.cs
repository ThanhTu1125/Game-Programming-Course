using UnityEngine;

public class MainButtonHandler : MonoBehaviour
{
    public void OnPlayClick()
    {
        if (SceneController.instance != null)
        {
            SceneController.instance.LoadGameplay();
        }
    }
}
