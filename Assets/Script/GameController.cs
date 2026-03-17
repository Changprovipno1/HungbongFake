using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject theBall;
    public float spawnTime = 2f ;
    float currentSpawnTime;
    bool isGameOver;

    void Start()
    {
        
        currentSpawnTime = spawnTime;
        isGameOver = false;
        
    }
    private void Update()
    {
        if (isGameOver) { 
            return;
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
