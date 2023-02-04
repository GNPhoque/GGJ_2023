using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherItem : MonoBehaviour
{
	[SerializeField] Image image;

	public void Setup(Weather weather)
	{
		image.sprite = weather.sprite;

	}
}
