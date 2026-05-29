using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

    public GameObject objek, score;
    public Sprite[] sprite;
    public Image timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        objek.SetActive(false);
        score.SetActive(true);
    }
    
    public IEnumerator StartBird()
    {
        timer.sprite = sprite[0];
        yield return new WaitForSeconds(1);
        
    }
}
