using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private float red;
	private float blue;
	private float yellow;

	public static Player instance;

	public float Red { get => red; set { red = value; UIManager.instance.UpdateUI(); } }
	public float Blue { get => blue; set { blue = value; UIManager.instance.UpdateUI(); } }
	public float Yellow { get => yellow; set { yellow = value; UIManager.instance.UpdateUI(); } }

	private void Awake()
	{
		if (instance) Destroy(instance);
		instance = this;
	}
}
