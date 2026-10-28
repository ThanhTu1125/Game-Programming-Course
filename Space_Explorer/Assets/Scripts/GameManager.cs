using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Hệ thống Máu")]
    public int playerHP = 3;
    public TextMeshProUGUI hpText;

    void Start()
    {
        if (hpText != null) hpText.text = "HP: " + playerHP;
    }

    public void TakeDamage()
    {
        playerHP--;
        if (hpText != null) hpText.text = "HP: " + playerHP;

        if (playerHP <= 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) Destroy(player);

            GameOver();
        }
    }

    public void GameOver()
    {
        if (SceneController.instance != null)
        {
            SceneController.instance.LoadEnd();
        }
        else
        {
            SceneManager.LoadScene("End");
        }
    }
}
