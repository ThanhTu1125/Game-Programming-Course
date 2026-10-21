using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void RotatePlayerRandomly()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float randomZ = Random.Range(0f, 360f);
            player.transform.rotation = Quaternion.Euler(0, 0, randomZ);

            Debug.Log("CHÓNG MẶT: Đã xoay góc " + randomZ);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("End");
    }
}