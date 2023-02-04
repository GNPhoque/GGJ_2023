using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float purple;
	[SerializeField] private float orange;
	[SerializeField] private float green;
	[SerializeField] private float hp;

	public static Player instance;

	public float Purple { get => purple; set { purple = value; UIManager.instance.UpdateUI(); } }
	public float Orange { get => orange; set { orange = value; UIManager.instance.UpdateUI(); } }
	public float Green { get => green; set { green = value; UIManager.instance.UpdateUI(); } }
	public float Hp { get => hp; set { hp = value; UIManager.instance.UpdateUI(); } }

	private void Awake()
	{
		if (instance) Destroy(instance);
		instance = this;
	}
}
