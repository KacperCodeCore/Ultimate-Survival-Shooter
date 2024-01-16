using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ScanTower")]
public class ScanTowerDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool noEnemyInSight = Scan(controller);
        return noEnemyInSight;
    }

    private bool Scan(StateController controller)
    {
        controller.navMeshAgent.isStopped = true;
        controller.navMeshAgent.updateRotation = false;

        var currentRot = controller.enemyStats.searchingTurnSpeed * Time.deltaTime;
        controller.totalRotateAngle += currentRot;
        controller.transform.Rotate(0, currentRot, 0);
        if (controller.totalRotateAngle > 360f)
            return true;
        else
            return false;

    }
}