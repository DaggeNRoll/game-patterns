using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleChewedState : AppleBaseState
{
    public override void EnterState(AppleStateMachine apple)
    {
        apple.AppleWhole.SetActive(false);
        apple.AppleChewed.SetActive(true);
    }

    public override void UpdateState(AppleStateMachine apple)
    {
        return;
    }

    public override void OnInteraction(AppleStateMachine apple)
    {
        Debug.Log("You've already eaten me");
    }
}
