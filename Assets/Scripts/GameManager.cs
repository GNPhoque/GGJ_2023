using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject victory;

	float currentSecondTickTime;
	float currentWeatherTickTime;
	float currentResistanceTickTime;
	float previousWeatherTickTimeModulo;

	public int tickCountPerWeather;
	public float weatherTickTime;
	[SerializeField] float weatherSpriteWidth;
	public List<Weather> weatherList;
	[SerializeField] WeatherItem weatherItemPrefab;
	[SerializeField] List<WeatherItem> weatherItems;
	int weatherItemIndex;
	[SerializeField] Transform weatherItemsParent;
	public float resistanceTickTime;
	public float resistanceDecay;

	public Weather currentWeather;

	int tickCount;
	float weatherScrollSpeed;

	public static GameManager instance;

	private void Awake()
	{
		if (instance) Destroy(instance);
		instance = this;
	}

	private void Start()
	{
		weatherScrollSpeed = (weatherSpriteWidth * 1f) / (tickCountPerWeather * weatherTickTime);
		SetupWeatherList();
		currentWeather = weatherList[0];
		UIManager.instance.UpdateWeatherUI(currentWeather);
		//InvokeRepeating("TickWeather", 0f, weatherTickTime);
		//InvokeRepeating("TickResistance", 0f, resistanceTickTime);
		previousWeatherTickTimeModulo = 0;
				weatherItems[weatherItemIndex].Select();
	}

	private void Update()
	{
		//weatherItemsParent.position -= Vector3.right * weatherScrollSpeed * Time.deltaTime;
		currentSecondTickTime += Time.deltaTime;
		currentWeatherTickTime += Time.deltaTime;
		currentResistanceTickTime += Time.deltaTime;
        if (currentSecondTickTime >= 1f)
        {
			weatherItems[weatherItemIndex].UpdateTimer();
			currentSecondTickTime = 0;
		}
		if (currentWeatherTickTime>=tickCountPerWeather * weatherTickTime)
        {
			print("CHANGE WEATHER");
			currentWeatherTickTime = 0f;
			TickWeather();
        }
		if(currentResistanceTickTime>= currentWeatherTickTime)
        {
			currentResistanceTickTime= 0f;
			TickResistance();
        }
  //      if (currentWetherTickTime % weatherTickTime < previousWeatherTickTimeModulo)
  //      {
		//	TickWeather();
		//	TickResistance();
  //      }
		//previousWeatherTickTimeModulo = currentWetherTickTime % weatherTickTime;
	} 

	private void SetupWeatherList()
	{
		//foreach (var item in weatherList)
		//{
		//	WeatherItem weather = Instantiate(weatherItemPrefab, weatherItemsParent);
		//	weather.Setup(item);
		//}
	}

	public void TickResistance()
	{
		Player.instance.Purple-= resistanceDecay;
		Player.instance.Orange-= resistanceDecay;
		Player.instance.Green -= resistanceDecay;
	}

	public void TickWeather()
	{
		//Player.instance.Hp -= currentWeather.purple * Player.instance.Purple * 0.01f;
		//Player.instance.Hp -= currentWeather.orange * Player.instance.Orange * 0.01f;
		//Player.instance.Hp -= currentWeather.green * Player.instance.Green * 0.01f;

		//if (++tickCount >= tickCountPerWeather)
		{
			if (currentWeather.purple == 1)
			{
				Player.instance.Hp -= Mathf.Max(currentWeather.damage - Player.instance.Purple, 0f);
				Player.instance.Purple -= currentWeather.damage;
			}
			if (currentWeather.orange== 1)
			{
				Player.instance.Hp -= Mathf.Max(currentWeather.damage - Player.instance.Orange,0f);
				Player.instance.Orange -= currentWeather.damage;
			}
			if (currentWeather.green == 1)
			{
				Player.instance.Hp -= Mathf.Max(currentWeather.damage - Player.instance.Green,0f);
				Player.instance.Green -= currentWeather.damage;
			}
			//Debug.Break();
			tickCount = 0;
			if (weatherList.Count > 1)
			{
				weatherList.Remove(currentWeather);
				currentWeather = weatherList[0];
				UIManager.instance.UpdateWeatherUI(currentWeather);

				weatherItems[weatherItemIndex].Deselect();
				weatherItemIndex = weatherItemIndex == 2 ? 0 : weatherItemIndex + 1;
				weatherItems[weatherItemIndex].Select();
			}
			else if (weatherList.Count == 1)
			{
				weatherList.Remove(currentWeather);
				UIManager.instance.UpdateWeatherUI(currentWeather);

				weatherItems[weatherItemIndex].Deselect();
				weatherItemIndex = weatherItemIndex == 2 ? 0 : weatherItemIndex + 1;
				weatherItems[weatherItemIndex].Select();
			}
			else
			{
				print("SURVIVED LAST WEATHER");
				//CancelInvoke(); //Stop ticks
				victory.SetActive(true);
				Time.timeScale = 0;
			}
		}
	}
}
