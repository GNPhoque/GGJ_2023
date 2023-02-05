using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boutonScroller : MonoBehaviour
{
    public GameObject[]  screens = new GameObject[3];
    public GameObject sceneManagerGO;
    public GameObject boutonNext;

    public bool nextSelected = false;
    public int nextActiveScreen = 0;


    void Awake()
    {
        Debug.Log(nextActiveScreen);

        boutonNext.SetActive(false);
        for ( int i = 0; i <3; i++)
        {
            screens[i].SetActive(false);
        }


    }

    void Update()
    {
        Debug.Log(nextActiveScreen);
        if (nextSelected)
        {
            GoNextScreen();
        }

        if(nextActiveScreen>0)
        {
            boutonNext.SetActive(true);
        }

    }

void GoNextScreen()
    {
            if(nextActiveScreen < 3)
            {
                nextSelected = false;
                screens[nextActiveScreen].SetActive(true);
                nextActiveScreen++;
            }
            else
            {
                sceneManagerGO.GetComponent<SceneManagerGO>().GoToPlayScene();
            }
    }

    private void OnMouseDown()
    {
        nextSelected = true;
    }
}
