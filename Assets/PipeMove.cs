using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float speed = 2f;
    public FlappyBird bird;

    void Start()
    {
        bird = GameObject.Find("manuk").GetComponent<FlappyBird>();
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Hapus pilar jika sudah keluar layar
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("manuk"))
        {
            bird.score++;
            bird.audioSource[1].Play();
        }
    }
}