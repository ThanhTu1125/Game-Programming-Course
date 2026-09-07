using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Tạo một biến tốc độ, chữ 'public' giúp bạn có thể chỉnh thông số này ngay trong Inspector
    public float moveSpeed = 1f;

    void Update()
    {
        // Di chuyển đối tượng sang phải liên tục
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
}