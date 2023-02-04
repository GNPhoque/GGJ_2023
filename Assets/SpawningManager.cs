using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{

    [Header("Balancing")]
    public int simultaneosSpawns;
    public float spawnPercentage;
    public float spawnTime;

    float currentTime;

    [Header("Set up")]

    public GameObject eatableOne;
    public GameObject eatableTwo;
    public GameObject eatableThree;
    public Transform[] SpawningAreas = new Transform[3];
    Transform eatables;



    // Start is called before the first frame update
    void Awake()
    {
        currentTime = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime<=0)
        {
            SpawnEatables();
            currentTime = spawnTime;
        }
    }

    void SpawnEatables()
    {
        foreach (Transform area in SpawningAreas)
        {
            if (spawnPercentage < Random.Range(0f, 1f))
            {
                //spawn un truc
                int a = Random.Range(1, 4);
                if(a == 1)
                {
                    //Instantiate(eatableOne, new Vector2(transform.GetComponent<BoxCollider2D>().bounds.extents));
                }
            }  
        }
    }
}
