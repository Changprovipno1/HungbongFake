using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSave : MonoBehaviour
{
    int score = 0 ;
    int highScore;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (UIManager.instance != null)
        {
            UIManager.instance.IsScoreText(score.ToString());
            UIManager.instance.IsHighScoreText(highScore.ToString());
        }
    }
    public void IncrementScore()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UIManager.instance.IsHighScoreText(highScore.ToString());
        }
        UIManager.instance.IsScoreText(score.ToString());
    }
}
