using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/RestoreRot")]
public class RestoreRotAction : Action
{
    public override void Act(StateController controller)
    {
        RestoreRot(controller);
    }

    private void RestoreRot(StateController controller)
    {
        var target = controller.initLookAt - controller.transform.position;
        var newRot = Vector3.RotateTowards(controller.transform.forward, target,
            Mathf.Deg2Rad * controller.enemyStats.searchingTurnSpeed * Time.deltaTime, 0.0f);
        var angle = Mathf.Abs(controller.startRotY - (controller.transform.rotation.y + newRot.y));
        if (angle <= 0.0f || angle >= 359.0f)
            controller.rotRestored = true;


        controller.transform.rotation = Quaternion.LookRotation(newRot);
    }
}
