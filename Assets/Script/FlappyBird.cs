using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlappyBird : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    public float rotationSpeed = 5f;
    public float maxUpAngle = 30f;
    public float maxDownAngle = -90f;
    public int highScore;
    public int score;
    public AudioSource[] audioSource;
    public TextMeshProUGUI scoreText;
    public GameObject gameOver;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI finalScore;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        // tampilkan ke UI
        highScoreText.text = "High Score : " + highScore;
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
        audioSource[2].Play();
        gameOver.SetActive(true);
        finalScore.text = "Score: " + score.ToString();
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High Score: " + score.ToString();
        }

        Time.timeScale = 0f;
    }

    public void Reset()
    {
        Time.timeScale = 1f;
        gameOver.SetActive(false);
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}