using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrailScript : MonoBehaviour
{
    //private TrailRenderer trailRenderer;
    //RootStateMachine stateMachine;

    RootsManager rootsManager;
    public bool isMoving;
    Vector2 targetDirection;
    


    // Start is called before the first frame update
    void Awake()
    {
        //trailRenderer = GetComponent<TrailRenderer>();
        //stateMachine = GetComponent<RootStateMachine>();

        rootsManager = transform.parent.GetComponent<RootsManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rootsManager.activeRoot == transform)
        {
            IAmSelected();
        }
        else
        {
            IAmNotSelected();
        }
    }

    private void Start()
    {
        InputManager.instance.inputs.Action.MouseClick.performed += MouseClick_performed;
    }


    private void MouseClick_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //isMoving = !isMoving;
    }

    void IAmSelected()
    {
        if(isMoving)
        {
            targetDirection = (Vector2)Camera.main.ScreenToWorldPoint(InputManager.instance.GetMousePosition()) - (Vector2)transform.position;
            targetDirection.Normalize();
            transform.position = (Vector2)transform.position + (Vector2)targetDirection * rootsManager.rootSpeed * Time.deltaTime;
            transform.parent.GetComponent<RootsManager>().score += rootsManager.rootSpeed * Time.deltaTime * transform.parent.GetComponent<RootsManager>().scoreMultiplier;
        }
    }
    void IAmNotSelected()
    {
        if (isMoving)
        {
            transform.position = (Vector2)transform.position + (Vector2)targetDirection * rootsManager.rootSlowSpeed * Time.deltaTime;
            transform.parent.GetComponent<RootsManager>().score += rootsManager.rootSlowSpeed * Time.deltaTime * transform.parent.GetComponent<RootsManager>().scoreMultiplier;
        }
    }

}
