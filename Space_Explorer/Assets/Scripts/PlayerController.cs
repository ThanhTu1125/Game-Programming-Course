using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject laserPrefab;

    [Header("Giới hạn màn hình")]
    public float minX = -8.5f;
    public float maxX = 8.5f;
    public float minY = -4.5f;
    public float maxY = 4.5f;

    [Header("Cơ chế bắn tự động")]
    public float fireRate = 0.2f;
    private float nextFire = 0f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;
        transform.position += movement;

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = mousePos - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(laserPrefab, transform.position, transform.rotation);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            FindAnyObjectByType<ScoreManager>().AddScore(50);

            Destroy(other.gameObject);
        }
    }
}
