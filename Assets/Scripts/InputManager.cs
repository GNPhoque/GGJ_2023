using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public Inputs inputs;
	public bool isMouseClicPressed;

	public static InputManager instance;

	private void Awake()
	{
		if (instance) Destroy(instance);
		instance = this;

		inputs = new Inputs();
	}

	private void OnEnable()
	{
		inputs.Enable();
		inputs.Action.MouseClick.started+= MouseClick_started;
		inputs.Action.MouseClick.canceled += MouseClick_canceled;
	}

	private void MouseClick_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		isMouseClicPressed = false;
	}

	private void OnDisable()
	{
		inputs.Action.MouseClick.started -= MouseClick_started;
	}

	private void MouseClick_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		isMouseClicPressed = true;
	}

	public Vector2 GetMousePosition()
	{
		return inputs.Action.MousePosition.ReadValue<Vector2>();
	}
}
