using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed = 2f;
    private float height;

    void Start()
    {
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= -height)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2f * height, transform.position.z);
        }
    }
}
