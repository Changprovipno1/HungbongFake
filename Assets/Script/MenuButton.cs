using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private ScoreSave scoreSave;
    public void OnButtonNewGame( string name)
    {
        PlayerPrefs.DeleteKey("CurrentScore");
        SceneManager.LoadScene(name);
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void OnButtonContinue(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void BackToMenu(string name)
    {
        if (scoreSave != null)
        {
            scoreSave.SaveBeforeExit();
        }

        SceneManager.LoadScene(name);
    }
}
