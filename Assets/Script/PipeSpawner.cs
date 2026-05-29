using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipeTop;
    public GameObject pipeBottom;
    public GameObject pipe;
    public float gap = 3f;
    public float spawnRate = 2f;

    public float[] randomness;
    public float randomness2 = 3.5f;

    void Start()
    {
        InvokeRepeating("SpawnPipe", 0f, spawnRate);
    }

    void SpawnPipe()
    {
        float y = Random.Range(randomness[0], randomness[1]);

        // Instantiate(pipeTop, new Vector3(transform.position.x, y + gap, 0), Quaternion.Euler(0, 0, 180));
        // Instantiate(pipeBottom, new Vector3(transform.position.x, y - gap, 0), Quaternion.identity);
        Instantiate(pipe, new Vector3(transform.position.x, y, 0), Quaternion.identity);
    }
}