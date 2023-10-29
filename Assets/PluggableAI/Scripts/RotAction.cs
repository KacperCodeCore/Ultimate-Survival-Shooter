using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Rot")]
public class RotAction : Action
{
    public override void Act(StateController controller)
    {
        Rotate360Degrees(controller);

    }

    private void Rotate360Degrees(StateController controller)
    {
        controller.navMeshAgent.isStopped = true;
        controller.transform.Rotate(0, controller.enemyStats.searchingTurnSpeed * Time.deltaTime, 0);
    }
}
