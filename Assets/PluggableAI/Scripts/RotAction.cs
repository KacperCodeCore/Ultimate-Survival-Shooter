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
        controller.lastRotation = controller.enemyStats.searchingTurnSpeed * Time.deltaTime;
        controller.transform.Rotate(0, controller.lastRotation, 0);
    }
}
