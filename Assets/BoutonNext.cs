using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonNext : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        transform.parent.GetComponent<boutonScroller>().nextSelected = true;
    }
}
