using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float red;
	[SerializeField] private float blue;
	[SerializeField] private float yellow;
	[SerializeField] private float hp;

	public static Player instance;

	public float Red { get => red; set { red = value; UIManager.instance.UpdateUI(); } }
	public float Blue { get => blue; set { blue = value; UIManager.instance.UpdateUI(); } }
	public float Yellow { get => yellow; set { yellow = value; UIManager.instance.UpdateUI(); } }
	public float Hp { get => hp; set { hp = value; UIManager.instance.UpdateUI(); } }

	private void Awake()
	{
		if (instance) Destroy(instance);
		instance = this;
	}
}
