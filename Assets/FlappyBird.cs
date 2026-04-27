using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlappyBird : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D rb;

    public float rotationSpeed = 5f;
    public float maxUpAngle = 30f;
    public float maxDownAngle = -90f;
    public int score;
    public AudioSource[] audioSource;
    public TextMeshProUGUI scoreText;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input lompat
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        RotateBird();

        scoreText.text = score.ToString();

    }

    void Jump()
    {
        rb.linearVelocity = Vector2.up * jumpForce;
        transform.rotation = Quaternion.Euler(0, 0, maxUpAngle); // langsung nengadah
        gameObject.GetComponent<Animator>().Play("manuk");
        audioSource[0].Play();
    }

    void RotateBird()
    {
        float angle = rb.linearVelocity.y * rotationSpeed;

        // Clamp biar nggak over
        angle = Mathf.Clamp(angle, maxDownAngle, maxUpAngle);

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f;
    }
}