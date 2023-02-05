using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField] BarFill purpleValue;
	[SerializeField] BarFill orangeValue;
	[SerializeField] BarFill greenValue;
	[SerializeField] BarFill healthValue;
	
	[SerializeField] BarFill weatherPurpleValue;
	[SerializeField] BarFill weatherOrangeValue;
	[SerializeField] BarFill weatherGreenValue;

	public static UIManager instance;

	private void Awake()
	{
		if (instance) Destroy(instance);
		instance = this;
	}

	public void UpdateUI()
	{
		purpleValue.UpadteFillAmount(Player.instance.Purple);
		orangeValue.UpadteFillAmount(Player.instance.Orange);
		greenValue.UpadteFillAmount(Player.instance.Green);
		healthValue.UpadteFillAmount(Player.instance.Hp);
		print(Player.instance.Hp);
	}

	public void UpdateWeatherUI(Weather weather)
	{
		//weatherPurpleValue.UpadteFillAmount(weather.purple);
		//weatherOrangeValue.UpadteFillAmount(weather.orange);
		//weatherGreenValue.UpadteFillAmount(weather.green);
	}
}
