using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreGrabber : MonoBehaviour
{
    [SerializeField] Text names;
    [SerializeField] Text scores;

    // Start is called before the first frame update
    void Start()
    {
        names.text = PlayerPrefs.GetString("PlayerName0") + "\n" + PlayerPrefs.GetString("PlayerName1") + "\n" + PlayerPrefs.GetString("PlayerName2") + "\n" + PlayerPrefs.GetString("PlayerName3") + "\n" + PlayerPrefs.GetString("PlayerName4");
        scores.text = PlayerPrefs.GetInt("HighScore0").ToString() + "\n" + PlayerPrefs.GetInt("HighScore1").ToString() + "\n" + PlayerPrefs.GetInt("HighScore2").ToString() + "\n" + PlayerPrefs.GetInt("HighScore3").ToString() + "\n" + PlayerPrefs.GetInt("HighScore4").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
