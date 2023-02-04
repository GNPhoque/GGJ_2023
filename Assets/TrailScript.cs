using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrailScript : MonoBehaviour
{
    private TrailRenderer trailRenderer;
    RootsManager rootsManager;
    public float speed;

    public bool isMoving;
    Vector2 targetDirection;
    RootStateMachine stateMachine;


    // Start is called before the first frame update
    void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        rootsManager = transform.parent.GetComponent<RootsManager>();
        stateMachine = GetComponent<RootStateMachine>();
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
        targetDirection = (Vector2)Camera.main.ScreenToWorldPoint(InputManager.instance.GetMousePosition()) - (Vector2)transform.position;
        targetDirection.Normalize();

        if (isMoving)
        {
            transform.position = (Vector2)transform.position + (Vector2)targetDirection * speed * Time.deltaTime;
        }
    }

}
