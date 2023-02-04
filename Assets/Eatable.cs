using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eatType
{
    ONE,
    TWO,
    THREE,
}

public class Eatable : MonoBehaviour
{

    public eatType myEatType;
    private BoxCollider2D boxCollider2d;

    // Start is called before the first frame update
    void Awake()
    {
        myEatType = eatType.ONE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
