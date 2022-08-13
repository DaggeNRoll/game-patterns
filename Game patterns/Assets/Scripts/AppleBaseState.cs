using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AppleBaseState
{
   public abstract void EnterState(AppleStateMachine apple);
   public abstract void UpdateState(AppleStateMachine apple);
   public abstract void OnInteraction(AppleStateMachine apple);
}
