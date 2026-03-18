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
        int isContinue = PlayerPrefs.GetInt("IsContinue", 0);

        if (isContinue == 1)
        {
            score = PlayerPrefs.GetInt("CurrentScore", 0);
        }
        else
        {
            score = 0;
            PlayerPrefs.DeleteKey("CurrentScore");
        }
        if (UIManager.instance != null)
        {
            UIManager.instance.IsScoreText(score.ToString());
            UIManager.instance.IsHighScoreText(highScore.ToString());
        }
    }
    public void IncrementScore()
    {
        score++;
        SaveCurrentScore();
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UIManager.instance.IsHighScoreText(highScore.ToString());
        }
        UIManager.instance.IsScoreText(score.ToString());
    }
    void SaveCurrentScore()
    {
        PlayerPrefs.SetInt("CurrentScore", score);
    }
    public void SaveBeforeExit()
    {
        PlayerPrefs.SetInt("CurrentScore", score);
        PlayerPrefs.Save();
    }
    public int GetScore()
    {
        return score;
    }
}
