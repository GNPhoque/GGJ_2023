using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrailScript : MonoBehaviour
{
    private TrailRenderer trailRenderer;
    public float speed;

    public bool isMoving;
    Vector2 targetDirection;


    // Start is called before the first frame update
    void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isMoving);

        targetDirection = (Vector2)Camera.main.ScreenToWorldPoint(InputManager.instance.GetMousePosition()) - (Vector2)transform.position;
        targetDirection.Normalize();

        if (isMoving)
        {
            transform.position = (Vector2)transform.position + (Vector2)targetDirection * speed * Time.deltaTime;
        }
    }

    private void Start()
    {
        InputManager.instance.inputs.Action.MouseClick.performed += MouseClick_performed;
    }

    private void MouseClick_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        isMoving = !isMoving;
    }

}
