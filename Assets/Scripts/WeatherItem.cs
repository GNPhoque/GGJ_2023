using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeatherItem : MonoBehaviour
{
	[SerializeField] Image image;
	[SerializeField] GameObject cursor;
	[SerializeField] TMP_Text timer;

	int i=18;

	public void Select()
    {
		cursor.SetActive(true);
		timer.text = "18";
		i = 18;
    }

	public void UpdateTimer()
    {
		i--;
		timer.text = i.ToString();
    }

	public void Deselect()
    {
		cursor.SetActive(false);
		timer.text = "";
    }
}
