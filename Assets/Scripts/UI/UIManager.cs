using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField] TMP_Text redValue;
	[SerializeField] TMP_Text blueValue;
	[SerializeField] TMP_Text yellowValue;

	public static UIManager instance;

	private void Awake()
	{
		if (instance) Destroy(instance);
		instance = this;
	}

	public void UpdateUI()
	{
		redValue.text = $"RED : {Player.instance.Red}";
		blueValue.text = $"BLUE : {Player.instance.Blue}";
		yellowValue.text = $"YELLOW : {Player.instance.Yellow}";
	}
}
