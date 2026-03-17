using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public GameObject panelLose;
    public  TMP_Text scoreText;
    public TMP_Text highScore;
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void IsPanelLose(bool isActive)
    {
        panelLose.SetActive(isActive);
    }
    public void IsScoreText(string ScoreText)
    {
        scoreText.text = ScoreText;
    }
    public void IsHighScoreText(string HighScoreText)
    {
        highScore.text = HighScoreText;
    }
}
