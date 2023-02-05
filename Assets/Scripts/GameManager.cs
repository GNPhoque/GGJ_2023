using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	float currentWetherTickTime;
	float previousWeatherTickTimeModulo;

	public int tickCountPerWeather;
	public float weatherTickTime;
	[SerializeField] float weatherSpriteWidth;
	public List<Weather> weatherList;
	[SerializeField] WeatherItem weatherItemPrefab;
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
		previousWeatherTickTimeModulo = weatherTickTime;
	}

	private void Update()
	{
		weatherItemsParent.position -= Vector3.right * weatherScrollSpeed * Time.deltaTime;
		currentWetherTickTime += Time.deltaTime;
        if (currentWetherTickTime % weatherTickTime < previousWeatherTickTimeModulo)
        {
			TickWeather();
			TickResistance();
        }
		previousWeatherTickTimeModulo = currentWetherTickTime % weatherTickTime;
	} 

	private void SetupWeatherList()
	{
		foreach (var item in weatherList)
		{
			WeatherItem weather = Instantiate(weatherItemPrefab, weatherItemsParent);
			weather.Setup(item);
		}
	}

	void TickResistance()
	{
		Player.instance.Purple-= resistanceDecay;
		Player.instance.Orange-= resistanceDecay;
		Player.instance.Green -= resistanceDecay;
	}

	void TickWeather()
	{
		//Player.instance.Hp -= currentWeather.purple * Player.instance.Purple * 0.01f;
		//Player.instance.Hp -= currentWeather.orange * Player.instance.Orange * 0.01f;
		//Player.instance.Hp -= currentWeather.green * Player.instance.Green * 0.01f;

		if (++tickCount >= tickCountPerWeather)
		{
			Debug.LogError("Change Weather " + Time.time);
			if (currentWeather.purple == 1)
			{
				Player.instance.Hp -= currentWeather.damage * Player.instance.Purple;
				Player.instance.Purple -= currentWeather.damage;
			}
			if (currentWeather.orange== 1)
			{
				Player.instance.Hp -= currentWeather.damage * Player.instance.Orange;
				Player.instance.Orange -= currentWeather.damage;
			}
			if (currentWeather.green == 1)
			{
				Player.instance.Hp -= currentWeather.damage * Player.instance.Green;
				Player.instance.Green -= currentWeather.damage;
			}
			//Debug.Break();
			tickCount = 0;
			if (weatherList.Count > 1)
			{
				weatherList.Remove(currentWeather);
				currentWeather = weatherList[0];
				UIManager.instance.UpdateWeatherUI(currentWeather);
			}
			else
			{
				print("SURVIVED LAST WEATHER");
				CancelInvoke(); //Stop ticks
			}
		}
	}
}
