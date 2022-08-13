using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleRottenState : AppleBaseState
{
    public override void EnterState(AppleStateMachine apple)
    {
        apple.AppleWhole.SetActive(false);
        apple.AppleRotten.SetActive(true);
    }

    public override void UpdateState(AppleStateMachine apple)
    {
        return;
    }

    public override void OnInteraction(AppleStateMachine apple)
    {
        Debug.Log("It's too late...");
    }
}
