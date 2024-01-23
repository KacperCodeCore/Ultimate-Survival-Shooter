using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/TotateTower")]
public class RotateTowardsAction : Action
{
    public override void Act(StateController controller)
    {
        RotateTowards(controller);
    }

    private void RotateTowards(StateController controller)
    {
        var target = controller.chaseTarget.position - controller.transform.position;
        var newRot = Quaternion.LookRotation(Vector3.RotateTowards(controller.transform.forward, target,
            Mathf.Deg2Rad * controller.enemyStats.searchingTurnSpeed * Time.deltaTime, 0.0f)).eulerAngles;
        controller.transform.rotation = Quaternion.Euler(0,newRot.y, 0);
    }
}
