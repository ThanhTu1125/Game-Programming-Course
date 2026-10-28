using UnityEngine;
using TMPro;

public class EndMenu : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject newRecordText;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        if (scoreText != null)
            scoreText.text = "YOUR SCORE: " + finalScore;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (finalScore > highScore)
        {
            highScore = finalScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

            if (newRecordText != null)
                newRecordText.SetActive(true);
        }
        else
        {
            if (newRecordText != null)
                newRecordText.SetActive(false);
        }

        if (highScoreText != null)
            highScoreText.text = "HIGH SCORE: " + highScore;
    }
}
