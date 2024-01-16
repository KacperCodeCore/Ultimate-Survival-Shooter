using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/RestoreRotTower")]
public class RestoreRotTowerDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return controller.rotRestored;
    }

}