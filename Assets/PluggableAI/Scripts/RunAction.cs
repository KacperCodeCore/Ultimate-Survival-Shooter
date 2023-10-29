using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Run")]
public class RunAction : Action
{
    public override void Act(StateController controller)
    {
        RunFromPlayer(controller);
    }

    private void RunFromPlayer(StateController controller)
    {
        if (controller.chaseTarget == null)
        {
            // Jeśli nie ma celu do ucieczki
            return;
        }

        // Oblicza kierunek ucieczki - kierunek od gracza do AI
        Vector3 runDirection = controller.transform.position - controller.chaseTarget.position;
        runDirection.Normalize();

        // Określa punkt do ucieczki
        Vector3 runToPosition = controller.transform.position + runDirection * 50;

        // Przenosi AI w kierunku punktu docelowego
        controller.navMeshAgent.SetDestination(runToPosition);
        controller.navMeshAgent.isStopped = false;
    }
}
