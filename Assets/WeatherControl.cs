using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherControl : MonoBehaviour
{
    public List<GameObject> weatherEnvironment = new List<GameObject>();
    public GameObject manager;
    GameManager scriptGameManager;
    float activeWeatherMax;
    

    void Awake()
    {
        scriptGameManager = manager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("P" + scriptGameManager.currentWeather.purple + "O" + scriptGameManager.currentWeather.orange + "G" + scriptGameManager.currentWeather.green);
        if (Mathf.Max(scriptGameManager.currentWeather.purple, scriptGameManager.currentWeather.orange, scriptGameManager.currentWeather.green) == scriptGameManager.currentWeather.purple)
        {
            
            weatherEnvironment[0].SetActive(true);
            weatherEnvironment[1].SetActive(false);
            weatherEnvironment[2].SetActive(false);
        }
        if (Mathf.Max(scriptGameManager.currentWeather.purple, scriptGameManager.currentWeather.orange, scriptGameManager.currentWeather.green) == scriptGameManager.currentWeather.orange)
        {
            weatherEnvironment[0].SetActive(false);
            weatherEnvironment[1].SetActive(true);
            weatherEnvironment[2].SetActive(false);
        }
        if (Mathf.Max(scriptGameManager.currentWeather.purple, scriptGameManager.currentWeather.orange, scriptGameManager.currentWeather.green) == scriptGameManager.currentWeather.green)
        {
            weatherEnvironment[0].SetActive(false);
            weatherEnvironment[1].SetActive(false);
            weatherEnvironment[2].SetActive(true);
        }
        else
        {
            weatherEnvironment[0].SetActive(true);
            weatherEnvironment[1].SetActive(false);
            weatherEnvironment[2].SetActive(false);
        }
    }
}
