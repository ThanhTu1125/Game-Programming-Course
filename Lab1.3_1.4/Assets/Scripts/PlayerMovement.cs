using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;

    // Biến trạng thái kiểm tra xem có đang chạm đất không
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Di chuyển
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // 2. Lật mặt
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // 3. Xử lý nhảy (Đã thêm điều kiện isGrounded)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Tự động gọi khi Collider của Player CHẠM vào vật khác (Mặt đất)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    // Tự động gọi khi Collider của Player RỜI KHỎI vật khác (Nhảy lên không)
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}