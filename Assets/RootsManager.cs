using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsManager : MonoBehaviour
{
    public GameObject[] Roots = new GameObject[3];
    public Transform activeRoot;
    int activeIndex;


    void Awake()
    {
        //int size = 0;
        //foreach (Transform child in transform)
        //{
        //    size++;
        //}
        activeIndex = 0;
        activeRoot = Roots[activeIndex].transform;
    }

    private void Start()
    {
        InputManager.instance.inputs.Action.ChangeRootA.performed += ChangeRootA_performed;
        InputManager.instance.inputs.Action.ChangeRootE.performed += ChangeRootE_performed;
    }

    private void ChangeRootE_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        activeIndex = System.Array.IndexOf(Roots, activeRoot.gameObject);
        if (activeIndex == 2)
        {
            activeIndex = 0;
        }
        else
        {
            activeIndex = activeIndex + 1;
        }
        activeRoot = Roots[activeIndex].transform;
    }

    private void ChangeRootA_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        activeIndex = System.Array.IndexOf(Roots, activeRoot.gameObject);
        if(activeIndex ==0)
        {
            activeIndex = 2;
        }
        else
        {
            activeIndex = activeIndex - 1;
        }
        activeRoot = Roots[activeIndex].transform;
    }

    // Update is called once per frame
    void Update()
    {
        System.Array.Sort(Roots, YPositionComparison);
        Debug.Log(activeIndex);
    }

    private int YPositionComparison(GameObject a, GameObject b)
    {
        //null check, I consider nulls to be less than non-null
        if (a == null) return (b == null) ? 0 : -1;
        if (b == null) return 1;

        var ya = a.transform.position.x;
        var yb = b.transform.position.x;
        return ya.CompareTo(yb); //here I use the default comparison of floats
    }

}
