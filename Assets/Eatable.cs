using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eatType
{
    PURPLE,
    ORANGE,
    GREEN,
    HEALTH,
}

public class Eatable : MonoBehaviour
{
    [SerializeField] Animator animator;
    public eatType myEatType;
    private BoxCollider2D boxCollider2d;
    public float size;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        size = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.GetComponent<Collider2D>().enabled == false)
        {
            Destroy(gameObject,0.5f);
        }
    }

    public void StartEating(float duration)
	{
        animator.SetFloat("speed", 1f/(duration / 0.375f));
	}
}
