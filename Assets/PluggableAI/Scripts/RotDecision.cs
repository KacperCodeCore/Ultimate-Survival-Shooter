using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/RotDecision")]
public class RotDecision : Decision
{
    public float rotationAngle = 360f;
    public override bool Decide(StateController controller)
    {
        if(controller.transform.rotation.eulerAngles.y >= rotationAngle)
        {
            return false;
        }
        return true;
    }
}