using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField] TMP_Text purpleValue;
	[SerializeField] TMP_Text orangeValue;
	[SerializeField] TMP_Text greenValue;
	[SerializeField] TMP_Text healthValue;
	
	[SerializeField] TMP_Text weatherPurpleValue;
	[SerializeField] TMP_Text weatherOrangeValue;
	[SerializeField] TMP_Text weatherGreenValue;

	public static UIManager instance;

	private void Awake()
	{
		if (instance) Destroy(instance);
		instance = this;
	}

	public void UpdateUI()
	{
		purpleValue.text = $"RED : {Player.instance.Purple}";
		orangeValue.text = $"BLUE : {Player.instance.Orange}";
		greenValue.text = $"YELLOW : {Player.instance.Green}";
		healthValue.text = $"HEALTH : {Player.instance.Hp}";
	}

	public void UpdateWeatherUI(Weather weather)
	{
		weatherPurpleValue.text = $"RED : {weather.purple}";
		weatherOrangeValue.text = $"BLUE : {weather.orange}";
		weatherGreenValue.text = $"YELLOW : {weather.green}";
	}
}
