using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGrowingState : AppleBaseState
{
    private Vector3 _startingScale = new Vector3(1, 1, 1);
    private Vector3 _grownScale = new Vector3(2.7f, 2.7f, 2.7f);
    private Vector3 _growAppleScalar = new Vector3(0.1f, 0.1f, 0.1f);
    public override void EnterState(AppleStateMachine apple)
    {
        apple.AppleWhole.SetActive(true);
        apple.AppleWhole.transform.localScale = _startingScale;
    }

    public override void UpdateState(AppleStateMachine apple)
    {
        if (apple.transform.localScale.x > _grownScale.x)
        {
            apple.SwitchState(apple.FullState);
            return;
        }
            

        apple.transform.localScale += _growAppleScalar;
    }

    public override void OnInteraction(AppleStateMachine apple)
    {
        Debug.Log("It's too early to eat me");
    }
}
