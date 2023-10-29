using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/RotDecision")]
public class RotDecision : Decision
{
    public float targetRotationAngle = 360f; // Docelowy kąt obrotu, np. 30 stopni
    private float currentRotation = 0f;

    public override bool Decide(StateController controller)
    {
        currentRotation += controller.enemyStats.searchingTurnSpeed * Time.deltaTime;

        if (currentRotation >= targetRotationAngle)
        {
            currentRotation = 0f; // restart wartość obrotu po osiągnięciu docelowego kąta
            return false;
        }

        return true;
    }
}