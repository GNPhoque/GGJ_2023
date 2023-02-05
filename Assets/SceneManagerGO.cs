using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerGO : MonoBehaviour
{

    public void GoToPlayScene()
    {
        Time.timeScale = 1;
         SceneManager.LoadScene(1);
    }

    public void GoToMenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
