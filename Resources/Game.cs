using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private int score = 0;
    private int level = 1;
   private int defeated = 0;

    private int enemies = 0;

    void Start()
    {   
        if (GameObject.FindGameObjectsWithTag("GameController").Length > 1)
            Destroy(this.gameObject);
        
        DontDestroyOnLoad(this);
    }

    void Update ()
    {   
        if (GameObject.FindGameObjectsWithTag("Score").Length == 0)
            return;

        Text text = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        text.text = "Score: " + score.ToString();
    }

    public void nextLevel ()
    {
        enemies = 0;
        defeated = 0;
        level++;

        if (level < 4)
        SceneManager.LoadScene(level);
        else
        {   
            SceneManager.LoadScene("HighScores");
            GameObject.FindGameObjectWithTag("MenuHandler").GetComponent<MenuHandlers>().SendScore(score);
            Destroy(this.gameObject);
        }

    }

    public void reloadLevel ()
    {
        enemies = 0;
        defeated = 0;
        SceneManager.LoadScene(level);
    }

    public void reloadDelayed ()
    {
        Invoke("reloadLevel", 3.0f);
    }

    public void gotEnemy ()
    {
        ++defeated;
        
        if (defeated == enemies)
            nextLevel();
    }

    public void setEnemy ()
    {
        ++enemies;
    }

    public void nextDelayed ()
    {
        Invoke("nextLevel", 3.0f);
    }

    public void addScore (int score)
    {
        this.score += score;
    }

    public void startGame ()
    {
        score = 0;
        SceneManager.LoadScene(0);

        /*
        UPDATE THIS NUMBER TO WHICH SCENE WILL BE THE FIRST LEVEL.
        THIS NUMBER CORRELATED TO THE SCENE BUILDER NUMBERS.
        */
    }
}
