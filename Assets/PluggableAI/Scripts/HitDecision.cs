using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/HitDecision")]
public class HitDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool hitDetected = CheckHit(controller);
        return hitDetected;
    }

    private bool CheckHit(StateController controller)
    {
        bool isHitDetected = controller.tankHealth.HasHitDetecred();
        if (isHitDetected)
        {
            Debug.Log("Trafienie w czoło wykryte w HitDecision!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            //controller.tankHealth.hitDetected = false;
        }
        return isHitDetected;
    }
}