using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float asteroidSpawnRate = 1.5f;
    public GameObject starPrefab;
    public float starSpawnRate = 7f;

    [Header("Tọa độ rớt (Vượt ngoài màn hình)")]
    public float spawnX = 10f;
    public float spawnY = 6f;
    public float limitX = 8.5f;
    public float limitY = 4.5f;

    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0.3f, asteroidSpawnRate);
        InvokeRepeating("SpawnStar", 4f, starSpawnRate);
    }

    void SpawnAsteroid()
    {
        SpawnObject(asteroidPrefab);
    }

    void SpawnStar()
    {
        SpawnObject(starPrefab);
    }

    void SpawnObject(GameObject prefabToSpawn)
    {
        int edge = Random.Range(0, 4);
        Vector3 spawnPos = Vector3.zero;
        Vector3 dir = Vector3.zero;

        if (edge == 0)
        {
            spawnPos = new Vector3(Random.Range(-limitX, limitX), spawnY, 0f);
            dir = Vector3.down;
        }
        else if (edge == 1)
        {
            spawnPos = new Vector3(Random.Range(-limitX, limitX), -spawnY, 0f);
            dir = Vector3.up;
        }
        else if (edge == 2)
        {
            spawnPos = new Vector3(-spawnX, Random.Range(-limitY, limitY), 0f);
            dir = Vector3.right;
        }
        else if (edge == 3)
        {
            spawnPos = new Vector3(spawnX, Random.Range(-limitY, limitY), 0f);
            dir = Vector3.left;
        }

        GameObject obj = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);

        if (obj.CompareTag("Star"))
        {
            obj.GetComponent<StarController>().moveDirection = dir;
        }
        else
        {
            obj.GetComponent<AsteroidController>().moveDirection = dir;
        }
    }
}
