using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualHandlers : MonoBehaviour
{
    public void Home ()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
