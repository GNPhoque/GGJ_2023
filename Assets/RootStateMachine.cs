using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum RootState
{
    ACTIVE,
    EATING,
    INACTIVE,
    DEAD,
}
public class RootStateMachine : MonoBehaviour
{
    public RootState currentState;
    public GameObject DisplayGains;
    
    private TrailScript trailScript;
    RootsManager rootsManager;
    GameObject lastEatable;

    [Header("BalanceSettings")]
    public float eatingTime;

    eatType currentEat;
    float currentEatingTime;

    void Awake()
    {
        trailScript = GetComponent<TrailScript>();
        rootsManager = transform.parent.GetComponent<RootsManager>();
    }

    void Update()
    {
        OnStateUpdate(currentState);
    }

    #region StateMachine
    private void OnStateEnter(RootState state)
    {
        switch (state)
        {
            case RootState.ACTIVE:
                OnEnterActive();
                break;
            case RootState.EATING:
                OnEnterEating();
                break;
            case RootState.INACTIVE:
                OnEnterInactive();
                break;
            case RootState.DEAD:
                OnEnterDead();
                break;
            default:
                break;
        }
    }

    private void OnStateExit(RootState state)
    {
        switch (state)
        {
            case RootState.ACTIVE:
                OnExitActive();
                break;
            case RootState.EATING:
                OnExitEating();
                break;
            case RootState.INACTIVE:
                OnExitInactive();   
                break;
            case RootState.DEAD:
                OnExitDead();
                break;
            default:
                break;
        }
    }

    private void OnStateUpdate(RootState state)
    {
        switch (state)
        {
            case RootState.ACTIVE:
                OnUpdateActive();
                break;
            case RootState.EATING:
                OnUpdateEating();
                break;
            case RootState.INACTIVE:
                OnUpdateInactive();
                break;
            case RootState.DEAD:
                OnUpdateDead();
                break;
            default:
                break;
        }
    }

    public void TransitionToState(RootState toState)
    {
        OnStateExit(currentState);
        currentState = toState;
        OnStateEnter(toState);
    }

    private void OnEnterActive()
    {
        trailScript.isMoving = true;
    }

    private void OnEnterEating()
    {
        currentEatingTime = eatingTime * (lastEatable.GetComponent<Eatable>().size / 7);
        trailScript.isMoving = false;
    }

    private void OnEnterInactive()
    {

    }

    private void OnEnterDead()
    {

    }

    private void OnUpdateActive()
    {
        transform.GetComponent<SpriteRenderer>().color = Color.green;
        if (rootsManager.activeRoot != transform)
        {
            TransitionToState(RootState.INACTIVE);
        }
    }

    private void OnUpdateEating()
    {
        transform.GetComponent<SpriteRenderer>().color = Color.red;
        currentEatingTime -= Time.deltaTime;
        if(currentEatingTime<0)
        {
            if(rootsManager.activeRoot == transform)
            {
                TransitionToState(RootState.ACTIVE);
            }
            else
            {
                TransitionToState(RootState.INACTIVE);
            }
        }

    }

    private void OnUpdateInactive()
    {
        if(rootsManager.activeRoot == transform)
        {
            TransitionToState(RootState.ACTIVE);
        }
    }

    private void OnUpdateDead()
    {

    }

    private void OnExitActive()
    {

    }

    private void OnExitEating()
    {
        lastEatable.GetComponent<Collider2D>().enabled = false;

        switch (currentEat)
        {
            case eatType.PURPLE:
                Player.instance.Purple += lastEatable.GetComponent<Eatable>().size;
                DisplayGains.GetComponent<DisplayGains>().ShowWhatIAte(eatType.PURPLE, lastEatable.GetComponent<Eatable>().size);
                break;
            case eatType.ORANGE:
                Player.instance.Orange += lastEatable.GetComponent<Eatable>().size;
                DisplayGains.GetComponent<DisplayGains>().ShowWhatIAte(eatType.ORANGE, lastEatable.GetComponent<Eatable>().size);

                break;
            case eatType.GREEN:
                Player.instance.Green += lastEatable.GetComponent<Eatable>().size;
                DisplayGains.GetComponent<DisplayGains>().ShowWhatIAte(eatType.GREEN, lastEatable.GetComponent<Eatable>().size);

                break;
            case eatType.HEALTH:
                Player.instance.Hp += lastEatable.GetComponent<Eatable>().size;
                DisplayGains.GetComponent<DisplayGains>().ShowWhatIAte(eatType.HEALTH, lastEatable.GetComponent<Eatable>().size);

                break;
            default:
                break;
        }

        trailScript.isMoving = true;



    }

    private void OnExitInactive()
    {

    }

    private void OnExitDead()
    {

    }

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentEat = collision.GetComponent<Eatable>().myEatType;
        lastEatable = collision.gameObject;
        TransitionToState(RootState.EATING);
        collision.GetComponent<Eatable>().StartEating(currentEatingTime);
    }

    eatType WhatDidIJustEat()
    {
        return currentEat;
    }
}

