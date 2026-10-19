using UnityEngine;

public class EnterGame : MonoBehaviour
{
    public Canvas GameMenu;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Đã va chạm với: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Nhận diện đúng Player, tiến hành bật Menu!");
            GameMenu.enabled = true;
        }
    }
}