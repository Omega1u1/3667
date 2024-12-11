using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingHandler : MonoBehaviour
{   
    [SerializeField] Slider volume;

    void Start ()
    {
        volume.value = PlayerPrefs.GetFloat("CurrentVolume");
    }
    
    public void Home ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Name (string name)
    {
        PlayerPrefs.SetString("CurrentPlayerName", name);
    }

    public void Volume (float volume)
    {
        PlayerPrefs.SetFloat("CurrentVolume", volume);
    }
}
