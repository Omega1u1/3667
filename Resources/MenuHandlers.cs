using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MenuHandlers : MonoBehaviour
{
    private int volume;

    private int[] highScores;
    private string[] playerNames;

    void Start ()
    {
        if (GameObject.FindGameObjectsWithTag("MenuHandler").Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this);

        highScores = new int[5];
        playerNames = new string[5];
        Initialize();

        if (PlayerPrefs.HasKey("CurrentVolume"))
            volume = PlayerPrefs.GetInt("CurrentVolume");
        else
            volume = 50;
    }

    public void Game ()
    {
        SceneManager.LoadScene(1);
    }
    
    private void Initialize ()
    {
        for (int i = 0; i < 5; ++i)
        {
            if ( PlayerPrefs.HasKey("PlayerName" + i))
            {
                highScores[i] = PlayerPrefs.GetInt("HighScore" + i);
                playerNames[i] = PlayerPrefs.GetString("PlayerName" + i);
            }
            else
            {
                playerNames[i] = "--";
                PlayerPrefs.SetInt("HighScore" + i, 0);
                PlayerPrefs.SetString("PlayerName" + i, "--");
                highScores[i] = 0;
            }
        }
    }

    public void SendScore (int score)
    {
        int index = -1;

        for (int i = 0; i < 5; ++i)
        {
            if (highScores[i] < score)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            for (int i = 4; i > index; --i)
            {
                playerNames[i] = playerNames[i-1];
                highScores[i] = highScores[i-1];
            }

            highScores[index] = score;
            playerNames[index] = PlayerPrefs.GetString("CurrentPlayerName", "iStoleUrScore");

            for (int i = 0; i < 5; ++i)
            {
                PlayerPrefs.SetInt("HighScore" + i, highScores[i]);
                PlayerPrefs.SetString("PlayerName" + i, playerNames[i]);
            }
        }
    }
}
