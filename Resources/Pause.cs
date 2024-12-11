using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    [SerializeField] Text text;

    public void Switch ()
    {
        if (paused)
        {
            Time.timeScale = 1.0f;
            text.text = "PAUSE";
            paused = false;
        }
        else
        {
            Time.timeScale = 0.0f;
            text.text = "UNPAUSE";
            paused = true;
        }
    }
}
