using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{

    [Header("Balancing")]
    public int simultaneosSpawns;
    public float spawnPercentage;
    public float spawnTime;
    public float minSize;
    public float maxSize;
    public int maxSimilarEatable;
    public Transform eatableParent;
    int eatablesPurple;
    int eatablesOrange;
    int eatablesGreen;
    int eatablesHealth;


    float currentTime;

    [Header("Set up")]

    public GameObject eatablePurple;
    public GameObject eatableOrange;
    public GameObject eatableGreen;
    public GameObject eatableHealth;
    public Transform[] SpawningAreas = new Transform[3];



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

        

        eatablesPurple = 0;
        eatablesOrange = 0;
        eatablesGreen = 0;
        eatablesHealth = 0;
        foreach (Transform child in eatableParent)
        {
            if(child.GetComponent<Eatable>().myEatType == eatType.GREEN)
            {
                eatablesGreen++;
            }
            if (child.GetComponent<Eatable>().myEatType == eatType.PURPLE)
            {
                eatablesPurple++;
            }
            if (child.GetComponent<Eatable>().myEatType == eatType.ORANGE)
            {
                eatablesOrange++;
            }
            if (child.GetComponent<Eatable>().myEatType == eatType.HEALTH)
            {
                eatablesHealth++;
            }
           
        }
        //Debug.Log("G" + eatablesGreen + "P" + eatablesPurple + "O" + eatablesOrange + "H" + eatablesHealth);
    }

    void SpawnEatables()
    {
        foreach (Transform area in SpawningAreas)
        {
            if (spawnPercentage < Random.Range(0f, 1f))
            {
                //spawn un truc
                int a = Random.Range(1, 5);
                if(a == 1)
                {
                    if(eatablesPurple >=maxSimilarEatable)
                    {
                        a = 2;
                        Debug.Log("Don't Spawn Purple" );
                    }
                    else
                    {
                        float coorX = Random.Range(area.position.x - area.GetComponent<BoxCollider2D>().bounds.extents.x, area.position.x + area.GetComponent<BoxCollider2D>().bounds.extents.x);
                        float coorY = Random.Range(area.position.y - area.GetComponent<BoxCollider2D>().bounds.extents.y, area.position.y + area.GetComponent<BoxCollider2D>().bounds.extents.y);
                        GameObject eat = Instantiate(eatablePurple, new Vector3(coorX, coorY, 0), Quaternion.identity);
                        eat.GetComponent<Eatable>().size = Random.Range(minSize, maxSize);
                        eat.transform.localScale *= Mathf.Clamp(eat.GetComponent<Eatable>().size / 10, 1, 2);
                        eat.transform.parent = eatableParent;
                    }
                }
                if (a == 2)
                {
                    if (eatablesOrange >= maxSimilarEatable)
                    {
                        a = 3;
                        Debug.Log("Don't Spawn Orange");

                    }
                    else
                    {
                        float coorX = Random.Range(area.position.x - area.GetComponent<BoxCollider2D>().bounds.extents.x, area.position.x + area.GetComponent<BoxCollider2D>().bounds.extents.x);
                        float coorY = Random.Range(area.position.y - area.GetComponent<BoxCollider2D>().bounds.extents.y, area.position.y + area.GetComponent<BoxCollider2D>().bounds.extents.y);
                        GameObject eat = Instantiate(eatableOrange, new Vector3(coorX, coorY, 0), Quaternion.identity);
                        eat.GetComponent<Eatable>().size = Random.Range(minSize, maxSize);
                        eat.transform.localScale *= Mathf.Clamp(eat.GetComponent<Eatable>().size / 10, 1, 2);
                        eat.transform.parent = eatableParent;
                    }
                }
                if (a == 3)
                {
                    if (eatablesGreen >= maxSimilarEatable)
                    {
                        a = 4;
                        Debug.Log("Don't Spawn Green");

                    }
                    else
                    {
                        float coorX = Random.Range(area.position.x - area.GetComponent<BoxCollider2D>().bounds.extents.x, area.position.x + area.GetComponent<BoxCollider2D>().bounds.extents.x);
                        float coorY = Random.Range(area.position.y - area.GetComponent<BoxCollider2D>().bounds.extents.y, area.position.y + area.GetComponent<BoxCollider2D>().bounds.extents.y);
                        GameObject eat = Instantiate(eatableGreen, new Vector3(coorX, coorY, 0), Quaternion.identity);
                        eat.GetComponent<Eatable>().size = Random.Range(minSize, maxSize);
                        eat.transform.localScale *= Mathf.Clamp(eat.GetComponent<Eatable>().size / 10, 1, 2);
                        eat.transform.parent = eatableParent;
                    }
                }
                if (a == 4)
                {
                    if (eatablesHealth >= maxSimilarEatable)
                    {
                        Debug.Log("Don't Spawn Health");

                    }
                    else
                    {
                        float coorX = Random.Range(area.position.x - area.GetComponent<BoxCollider2D>().bounds.extents.x, area.position.x + area.GetComponent<BoxCollider2D>().bounds.extents.x);
                        float coorY = Random.Range(area.position.y - area.GetComponent<BoxCollider2D>().bounds.extents.y, area.position.y + area.GetComponent<BoxCollider2D>().bounds.extents.y);
                        GameObject eat = Instantiate(eatableHealth, new Vector3(coorX, coorY, 0), Quaternion.identity);
                        eat.GetComponent<Eatable>().size = Random.Range(minSize, maxSize);
                        eat.transform.localScale *= Mathf.Clamp(eat.GetComponent<Eatable>().size / 10, 1, 2);
                        eat.transform.parent = eatableParent;
                    }
                }
            }  
        }
    }
}
