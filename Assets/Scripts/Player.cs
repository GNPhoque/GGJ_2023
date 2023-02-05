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

	public float Purple { get => purple; set { purple = Mathf.Clamp(value,0f,100f); UIManager.instance.UpdateUI(); } }
	public float Orange { get => orange; set { orange = Mathf.Clamp(value, 0f, 100f); UIManager.instance.UpdateUI(); } }
	public float Green { get => green; set { green = Mathf.Clamp(value, 0f, 100f); UIManager.instance.UpdateUI(); } }
	public float Hp { get => hp; set { hp = Mathf.Clamp(value, 0f, 100f); UIManager.instance.UpdateUI(); } }

	private void Awake()
	{
		if (instance) Destroy(instance);
		instance = this;
	}
}
