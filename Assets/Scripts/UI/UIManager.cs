using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField] TMP_Text redValue;
	[SerializeField] TMP_Text blueValue;
	[SerializeField] TMP_Text yellowValue;
	[SerializeField] TMP_Text healthValue;
	
	[SerializeField] TMP_Text weatherRedValue;
	[SerializeField] TMP_Text weatherBlueValue;
	[SerializeField] TMP_Text weatherYellowValue;

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
		healthValue.text = $"HEALTH : {Player.instance.Hp}";
	}

	public void UpdateWeatherUI(Weather weather)
	{
		weatherRedValue.text = $"RED : {weather.red}";
		weatherBlueValue.text = $"BLUE : {weather.blue}";
		weatherYellowValue.text = $"YELLOW : {weather.yellow}";
	}
}
