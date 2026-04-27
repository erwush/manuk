using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public float speed = 2f;
    private float width;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        width -= 0.1f; // 🔥 overlap biar nutup gap
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= -30f)
        {
            transform.position += new Vector3(width * 2f, 0, 0);
        }
    }
}