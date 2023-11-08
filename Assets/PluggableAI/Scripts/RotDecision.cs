using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/RotDecision")]
public class RotDecision : Decision
{
    public float targetRotationAngle = 360f; // Można przenieść do ?

    public override bool Decide(StateController controller)
    {
        controller.currentRotation += controller.lastRotation;

        if (controller.currentRotation >= targetRotationAngle)
        {
            controller.currentRotation = 0f; // restart wartość obrotu po osiągnięciu docelowego kąta
            return false;
        }

        return true;
    }
}