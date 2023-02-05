using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.TickWeather();
        GameManager.instance.TickResistance();
    }
}
