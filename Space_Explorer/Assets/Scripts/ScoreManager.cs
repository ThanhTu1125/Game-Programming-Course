using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "Score: " + score;

        PlayerPrefs.SetInt("FinalScore", score);
    }

    public void DeductScore(int penalty)
    {
        score -= penalty;
        if (score < 0) score = 0;
        scoreText.text = "Score: " + score;

        PlayerPrefs.SetInt("FinalScore", score);
    }
}
