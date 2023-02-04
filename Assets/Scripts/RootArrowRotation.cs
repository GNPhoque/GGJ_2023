using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootArrowRotation : MonoBehaviour
{
	public void RotateTo(Vector2 position)
	{
		Vector2 direction = position - (Vector2)transform.position;
		transform.up = direction;
	}
}
