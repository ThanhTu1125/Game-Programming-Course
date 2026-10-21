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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        mousePosition.x = Mathf.Clamp(mousePosition.x, minX, maxX);
        mousePosition.y = Mathf.Clamp(mousePosition.y, minY, maxY);

        transform.position = mousePosition;

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(laserPrefab, transform.position, transform.rotation);
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
