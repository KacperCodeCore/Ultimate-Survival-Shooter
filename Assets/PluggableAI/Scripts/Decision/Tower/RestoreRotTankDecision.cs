using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/RestoreRotTank")]
public class RestoreRotTankDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return controller.rotRestored;
    }

}