using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleFullState : AppleBaseState
{
    private float _rottenCountDown = 10f;
    public override void EnterState(AppleStateMachine apple)
    {
        return;
    }

    public override void UpdateState(AppleStateMachine apple)
    {
        if (_rottenCountDown < 0f)
        {
            apple.SwitchState(apple.RottenState);
            return;
        }
        

        _rottenCountDown -= Time.deltaTime;
    }

    public override void OnInteraction(AppleStateMachine apple)
    {
        apple.SwitchState(apple.ChewedState);
    }
}
