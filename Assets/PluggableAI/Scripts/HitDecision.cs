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
        bool isHitDetected = controller.tankHealth.HasHitDetecred;
        controller.tankHealth.HasHitDetecred = false;
        return isHitDetected;
    }
}