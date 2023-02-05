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

	[SerializeField] TMP_Text purpleText;
	[SerializeField] TMP_Text orangeText;
	[SerializeField] TMP_Text greenText;
	[SerializeField] TMP_Text hpText;
	
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
		purpleText.text = Mathf.Round(Player.instance.Purple).ToString();
		orangeValue.UpadteFillAmount(Player.instance.Orange);
		orangeText.text = Mathf.Round(Player.instance.Orange).ToString();
		greenValue.UpadteFillAmount(Player.instance.Green);
		greenText.text = Mathf.Round(Player.instance.Green).ToString();
		healthValue.UpadteFillAmount(Player.instance.Hp);
		hpText.text = Mathf.Round(Player.instance.Hp).ToString();
		print(Player.instance.Hp);
	}

	public void UpdateWeatherUI(Weather weather)
	{
		//weatherPurpleValue.UpadteFillAmount(weather.purple);
		//weatherOrangeValue.UpadteFillAmount(weather.orange);
		//weatherGreenValue.UpadteFillAmount(weather.green);
	}
}
