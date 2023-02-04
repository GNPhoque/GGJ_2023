using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
	public float speed;

	TrailRenderer tr;

	Vector2 targetDirection;

	private void Awake()
	{
		tr = GetComponent<TrailRenderer>();
	}

	private void Update()
	{
		transform.position = (Vector2)transform.position + (Vector2)targetDirection * speed * Time.deltaTime;
		if (InputManager.instance.isMouseClicPressed)
		{
			targetDirection = InputManager.instance.GetMousePosition() - (Vector2)transform.position;
			targetDirection.Normalize();
		}
	}
}
