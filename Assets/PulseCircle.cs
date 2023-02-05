using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseCircle : MonoBehaviour
{
    public float pulseCycleSpeed;
    public float pulseSizeMax;
    public float pulseSizeMin;
    public RootsManager rootsManager;
    public int numberOfPulses;
    int currentPulses;
    Vector2 previousPosition;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = rootsManager.activeRoot.transform.position;

        if (currentPulses>=0)
        {
            transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * pulseCycleSpeed, transform.localScale.y + Time.deltaTime * pulseCycleSpeed, transform.localScale.z + Time.deltaTime * pulseCycleSpeed);
        }

        if (transform.localScale.x >= pulseSizeMax)
        {
            transform.localScale = new Vector3(pulseSizeMin, pulseSizeMin, pulseSizeMin);
            currentPulses--;
        }

        if(Vector2.Distance(previousPosition,transform.position)>= 0.1f)
        {
            currentPulses = numberOfPulses;
        }

        previousPosition = transform.position;

    }
}
