using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayGains : MonoBehaviour
{
    //public string showText;
    public float fadeTime;
    float currentTime;

    public TMP_Text Purple;
    public TMP_Text Orange;
    public TMP_Text Green;
    public TMP_Text Health;

     string purpleValue;
     string orangeValue;
     string greenValue;
     string healthValue;



    bool hasEaten;
    eatType lastEaten;


    void Awake()
    {

    }

    void Update()
    {
        if(hasEaten && currentTime >= 0)
        {
            currentTime -= Time.deltaTime;

            switch (lastEaten)
            {
                case eatType.PURPLE:
                    Purple.text = "+" + purpleValue;
                    break;
                case eatType.ORANGE:
                    Orange.text = "+" + purpleValue;
                    break;
                case eatType.GREEN:
                    Green.text = "+" + purpleValue;
                    break;
                case eatType.HEALTH:
                    Health.text = "+" + purpleValue;
                    break;
                default:
                    break;
            }
        }

        if(currentTime<=0)
        {
            hasEaten = false;
            Purple.text = "";
            Orange.text = "";
            Green.text = "";
            Health.text = "";

        }

    }

    public void ShowWhatIAte(eatType _eatType, float value)
    {
        hasEaten = true;
        currentTime = fadeTime;

        switch (_eatType)
        {
            case eatType.PURPLE:
                purpleValue = value.ToString();
                break;
            case eatType.ORANGE:
                purpleValue = value.ToString();
                break;
            case eatType.GREEN:
                purpleValue = value.ToString();
                break;
            case eatType.HEALTH:
                purpleValue = value.ToString();
                break;
            default:
                break;
        }

    }
}
