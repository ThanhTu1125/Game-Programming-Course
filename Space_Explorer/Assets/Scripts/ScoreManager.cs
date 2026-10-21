using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private int nextThreshold = 300;

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "Score: " + score;

        if (score >= nextThreshold)
        {
            nextThreshold += 300;

            FindAnyObjectByType<GameManager>().RotatePlayerRandomly();
        }
    }
}
