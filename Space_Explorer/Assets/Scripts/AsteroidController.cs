using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float baseSpeed = 3f;
    public GameObject explosionPrefab;

    public Vector3 moveDirection = Vector3.down;

    void Start()
    {
        Destroy(gameObject, 6f);
    }

    void Update()
    {
        float currentSpeed = baseSpeed + (Time.timeSinceLevelLoad * 0.05f);

        transform.Translate(moveDirection * currentSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            FindAnyObjectByType<ScoreManager>().AddScore(10);
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManager>().GameOver();
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}