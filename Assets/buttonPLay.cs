using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPLay : MonoBehaviour
{
    bool isSelected;
    public GameObject notSelected;
    public GameObject selected;
    BoxCollider2D bd2d;
    public GameObject buttonScroller;

    void Awake()
    {
        bd2d = GetComponent<BoxCollider2D>();
        isSelected = false;
    }

    void Update()
    {

        if(isSelected && buttonScroller.GetComponent<boutonScroller>().nextActiveScreen ==0)
        {
            notSelected.SetActive(false);
            selected.SetActive(true);
            Debug.Log("oops");
            buttonScroller.GetComponent<boutonScroller>().nextSelected = true;
        }
        else
        {
            notSelected.SetActive(true);
            selected.SetActive(false);
        }

        if(buttonScroller.GetComponent<boutonScroller>().nextActiveScreen >0)
        {
            notSelected.SetActive(false);
            selected.SetActive(false);
            bd2d.enabled = false;
        }

    }

    private void OnMouseDown()
    {
        isSelected = true;
    }

}
