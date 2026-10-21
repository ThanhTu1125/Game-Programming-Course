using UnityEngine;

public class StarController : MonoBehaviour
{
    public float speed = 2f;

    public Vector3 moveDirection = Vector3.down;

    void Start()
    {
        Destroy(gameObject, 8f);
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
}