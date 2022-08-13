using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleStateMachine : MonoBehaviour
{
    public AppleBaseState CurrentState;
    public AppleGrowingState GrowingState = new AppleGrowingState();
    public AppleFullState FullState = new AppleFullState();
    public AppleChewedState ChewedState = new AppleChewedState();
    public AppleRottenState RottenState = new AppleRottenState();

    public GameObject AppleWhole;
    public GameObject AppleChewed;
    public GameObject AppleRotten;

    private void Start()
    {
        CurrentState = GrowingState;
        
        CurrentState.EnterState(this);
    }

    private void Update()
    {
        CurrentState.UpdateState(this);

        if (Input.GetButtonDown("Fire1"))
        {
            CurrentState.OnInteraction(this);
        }
    }

    public void SwitchState(AppleBaseState state)
    {
        CurrentState = state;
        CurrentState.EnterState(this);
    }
}
