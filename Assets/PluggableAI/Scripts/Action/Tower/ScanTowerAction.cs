using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/ScanTower")]
public class ScanTowerAction : Action
{
    public override void Act(StateController controller)
    {   
        Scan(controller);
    }
    private void Scan(StateController controller)
    {
        var currentRot = controller.enemyStats.searchingTurnSpeed * Time.deltaTime;
        if(controller.Scan(currentRot, controller.enemyStats.scaleAngle))
            controller.transform.Rotate(0, currentRot, 0);
        else
            controller.transform.Rotate(0,-currentRot, 0); 

    }
}
