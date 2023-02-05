using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerGO : MonoBehaviour
{

    public void GoToPlayScene()
    {
         SceneManager.LoadScene(0);
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene(1);
    }
}
