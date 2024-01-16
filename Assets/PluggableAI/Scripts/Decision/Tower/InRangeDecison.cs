using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/InRange")]
public class InRangeDecison : Decision
{
    public override bool Decide(StateController controller)
    {
        return inRage(controller);
    }

    private bool inRage(StateController controller)
    {

        return Vector3.Distance(controller.chaseTarget.position, controller.transform.position) < controller.enemyStats.lookRange;
    }
}