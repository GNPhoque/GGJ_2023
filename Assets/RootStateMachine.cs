using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    private TrailScript trailScript;

    [Header("BalanceSettings")]
    public float eatingTime;

    eatType currentEat;
    float currentEatingTime;
    public bool isSelected;

    // Start is called before the first frame update
    void Awake()
    {
        trailScript = GetComponent<TrailScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentState);
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
        currentEatingTime = eatingTime;
        trailScript.isMoving = false;
    }

    private void OnEnterInactive()
    {
        trailScript.isMoving = false;
    }

    private void OnEnterDead()
    {
        trailScript.isMoving = false;
    }

    private void OnUpdateActive()
    {

    }

    private void OnUpdateEating()
    {
        currentEatingTime -= Time.deltaTime;
        if(currentEatingTime<0)
        {
            if(isSelected)
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

    }

    private void OnUpdateDead()
    {

    }

    private void OnExitActive()
    {

    }

    private void OnExitEating()
    {
        //Send Eaten type
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
        TransitionToState(RootState.EATING);
    }

    eatType WhatDidIJustEat()
    {
        return currentEat;
    }
}

