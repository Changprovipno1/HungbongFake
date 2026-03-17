using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject theBall;
    private float spawnTime;
    [SerializeField] float baseSpawnTime = 2f;
    [SerializeField] float minSpawnTime = 0.5f;
    [SerializeField] float decreaseRate = 0.05f;
    ScoreSave scoreSave;
    float currentSpawnTime;
    bool isGameOver;

    private void Awake()
    {
        scoreSave = FindObjectOfType<ScoreSave>();
    }
    void Start()
    {
        
        Time.timeScale = 1;
        spawnTime = baseSpawnTime;
        currentSpawnTime = spawnTime;
        isGameOver = false;
        
    }
    void Update()
    {
        if (isGameOver) return;

        int score = scoreSave != null ? scoreSave.GetScore() : 0;

        float newSpawnTime = Mathf.Max(minSpawnTime, baseSpawnTime - score * decreaseRate);

        if (Mathf.Abs(newSpawnTime - spawnTime) > 0.01f)
        {
            spawnTime = newSpawnTime;
            currentSpawnTime = spawnTime; 
        }
        currentSpawnTime -= Time.deltaTime;
        if (currentSpawnTime <= 0)
        {
            SpawnBall();
            currentSpawnTime = spawnTime;
        }
    }
    public void SpawnBall()
    {
        float camHeight = Camera.main.orthographicSize;
        float camWidth = camHeight * Camera.main.aspect;

        float x = Random.Range(-camWidth, camWidth);
        float y = camHeight + 1f;

        Vector2 spawnPos = new Vector2(x, y);

        Instantiate(theBall, spawnPos, Quaternion.identity);
    }


    public void Replay()
    {
        PlayerPrefs.DeleteKey("CurrentScore");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public bool IsGameOver
    {
        get { return isGameOver; }
        set
        {
            Time.timeScale = 0;
            isGameOver = value;
            if (isGameOver)
            {
                UIManager.instance.IsPanelLose(true);
            }
        }
    }
}
