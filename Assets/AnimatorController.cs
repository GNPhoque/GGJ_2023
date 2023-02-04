using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    public float changePercentage;
    float odds;
    float smileOdds;
    public float oddsSwap;
    //1
    public float normalSmileOdds;
    //2
    public float creepySmileOdds;
    //3
    public float hihiSmileOdds;

    float totalOddsSmile;
    float currentOddsSwaps;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        currentOddsSwaps = oddsSwap;
        totalOddsSmile = normalSmileOdds + creepySmileOdds + hihiSmileOdds;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(odds);
        currentOddsSwaps -= Time.deltaTime;
        if(currentOddsSwaps <= 0)
        {
            odds = (float)Random.Range(0f, 1f);
            currentOddsSwaps = oddsSwap;

            //smiles
            smileOdds = Random.Range(0f, totalOddsSmile);
            if(smileOdds< normalSmileOdds)
            {
                animator.SetInteger("WhichAnimation", 1);
            }
            else if (smileOdds < normalSmileOdds+creepySmileOdds)
            {
                animator.SetInteger("WhichAnimation", 2);
            }
            else
            {
                animator.SetInteger("WhichAnimation", 3);
            }

        }

        if (odds <= changePercentage)
        {
            animator.SetBool("DoItAgain", true);
        }
        else
        {
            animator.SetBool("DoItAgain", false);
        }
    }
}
