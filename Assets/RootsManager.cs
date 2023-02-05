using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsManager : MonoBehaviour
{
    public GameObject[] Roots = new GameObject[3];
    public Transform activeRoot;
    public float rootSpeed;
    public float rootSlowSpeed;
    int activeIndex;
    [HideInInspector] public float score;
    public float scoreMultiplier;
    public Animator ottoAnimator;


    void Awake()
    {
        //int size = 0;
        //foreach (Transform child in transform)
        //{
        //    size++;
        //}
        activeIndex = 0;
        activeRoot = Roots[activeIndex].transform;
        ShowRootRotation();
        
    }

    private void Start()
    {
        InputManager.instance.inputs.Action.ChangeRootA.performed += ChangeRootA_performed;
        InputManager.instance.inputs.Action.ChangeRootE.performed += ChangeRootE_performed;
        activeRoot = Roots[activeIndex].transform;
        activeRoot.transform.GetComponent<TrailScript>().isMoving = true;
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
        ShowRootRotation();
    }

	private void ShowRootRotation()
	{
		//foreach (var root in Roots)
		//{
		//	foreach (var rotation in root.GetComponentsInChildren<RootArrowRotation>(true))
		//	{
  //              rotation.gameObject.SetActive(root.transform == activeRoot);
		//	}
		//}
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
        ShowRootRotation();
    }

    // Update is called once per frame
    void Update()
    {
        System.Array.Sort(Roots, YPositionComparison);
        ottoAnimator.SetFloat("Score", score);
   //     Debug.Log(activeIndex);
   //     int i = 0;
   //     int leftRootIndex = activeIndex == 0 ? 2 : activeIndex - 1;
   //     int rightRootIndex = activeIndex == 2 ? 0 : activeIndex + 1;
   //     RootArrowRotation[] rotations= activeRoot.GetComponentsInChildren<RootArrowRotation>(true);
			//rotations[0].RotateTo(Roots[leftRootIndex].transform.position);
			//rotations[1].RotateTo(Roots[rightRootIndex].transform.position);
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
