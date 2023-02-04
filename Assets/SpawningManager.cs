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

    float currentTime;

    [Header("Set up")]

    public GameObject eatablePurple;
    public GameObject eatableOrange;
    public GameObject eatableGreen;
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
                int a = Random.Range(1, 5);
                if(a == 1)
                {
                    float coorX = Random.Range(area.position.x - area.GetComponent<BoxCollider2D>().bounds.extents.x, area.position.x + area.GetComponent<BoxCollider2D>().bounds.extents.x);
                    float coorY = Random.Range(area.position.y - area.GetComponent<BoxCollider2D>().bounds.extents.y, area.position.y + area.GetComponent<BoxCollider2D>().bounds.extents.y);
                    GameObject eat = Instantiate(eatablePurple, new Vector3(coorX, coorY,0), Quaternion.identity);
                    eat.GetComponent<Eatable>().size = Random.Range(minSize, maxSize);
                    eat.transform.localScale *= Mathf.Clamp(eat.GetComponent<Eatable>().size / 10,1,2);
                }
                if (a == 2)
                {
                    float coorX = Random.Range(area.position.x - area.GetComponent<BoxCollider2D>().bounds.extents.x, area.position.x + area.GetComponent<BoxCollider2D>().bounds.extents.x);
                    float coorY = Random.Range(area.position.y - area.GetComponent<BoxCollider2D>().bounds.extents.y, area.position.y + area.GetComponent<BoxCollider2D>().bounds.extents.y);
                    GameObject eat = Instantiate(eatableOrange, new Vector3(coorX, coorY, 0), Quaternion.identity);
                    eat.GetComponent<Eatable>().size = Random.Range(minSize, maxSize);
                    eat.transform.localScale *= Mathf.Clamp(eat.GetComponent<Eatable>().size / 10, 1, 2);

                }
                if (a == 3)
                {
                    float coorX = Random.Range(area.position.x - area.GetComponent<BoxCollider2D>().bounds.extents.x, area.position.x + area.GetComponent<BoxCollider2D>().bounds.extents.x);
                    float coorY = Random.Range(area.position.y - area.GetComponent<BoxCollider2D>().bounds.extents.y, area.position.y + area.GetComponent<BoxCollider2D>().bounds.extents.y);
                    GameObject eat = Instantiate(eatableGreen, new Vector3(coorX, coorY, 0), Quaternion.identity);
                    eat.GetComponent<Eatable>().size = Random.Range(minSize, maxSize);
                    eat.transform.localScale *= Mathf.Clamp(eat.GetComponent<Eatable>().size / 10, 1, 2);

                }
                if (a == 4)
                {
                    float coorX = Random.Range(area.position.x - area.GetComponent<BoxCollider2D>().bounds.extents.x, area.position.x + area.GetComponent<BoxCollider2D>().bounds.extents.x);
                    float coorY = Random.Range(area.position.y - area.GetComponent<BoxCollider2D>().bounds.extents.y, area.position.y + area.GetComponent<BoxCollider2D>().bounds.extents.y);
                    GameObject eat = Instantiate(eatableGreen, new Vector3(coorX, coorY, 0), Quaternion.identity);
                    eat.GetComponent<Eatable>().size = Random.Range(minSize, maxSize);
                    eat.transform.localScale *= Mathf.Clamp(eat.GetComponent<Eatable>().size / 10, 1, 2);

                }
            }  
        }
    }
}
