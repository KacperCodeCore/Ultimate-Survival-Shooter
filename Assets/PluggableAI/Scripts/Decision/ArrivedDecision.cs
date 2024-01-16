using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ArrivedDecision")]
public class ArrivedDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return HasArrived(controller);
    }

    private bool HasArrived(StateController controller)
    {
        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
