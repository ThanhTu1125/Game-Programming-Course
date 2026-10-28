using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    public Image fadePanel;
    public float fadeDuration = 0.5f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadGameplay()
    {
        StartCoroutine(FadeAndLoad("Gameplay"));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(FadeAndLoad("Main"));
    }

    public void LoadEnd()
    {
        StartCoroutine(FadeAndLoad("End"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator FadeAndLoad(string sceneName)
    {
        fadePanel.raycastTarget = true;
        float timer = 0f;
        Color color = fadePanel.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadePanel.color = color;
            yield return null;
        }

        color.a = 1f;
        fadePanel.color = color;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadePanel.color = color;
            yield return null;
        }

        color.a = 0f;
        fadePanel.color = color;

        fadePanel.raycastTarget = false;
    }
}
