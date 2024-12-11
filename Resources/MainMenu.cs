using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     public void Home ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Manual ()
    {
        SceneManager.LoadScene("Manual");
    }

    public void Settings ()
    {
        SceneManager.LoadScene("Settings");
    }

    public void HighScores ()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void Game ()
    {
        SceneManager.LoadScene(1);
    }
}
