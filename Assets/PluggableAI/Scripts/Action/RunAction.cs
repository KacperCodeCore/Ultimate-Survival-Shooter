using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Run")]
public class RunAction : Action
{
    public override void Act(StateController controller)
    {
        RunToBase(controller);
    }

    private void RunToBase(StateController controller)
    {
        // Znajduje bazę i ustawia ją jako cel ucieczki
        Transform baseTransform = GameObject.FindGameObjectWithTag("Base").transform;

        // Przenosi AI w kierunku bazy
        controller.navMeshAgent.SetDestination(baseTransform.position);
        controller.navMeshAgent.isStopped = false;
        controller.navMeshAgent.updateRotation = true;


        //if (controller.chaseTarget == null)
        //{
        //    // Jeśli nie ma celu do ucieczki
        //    controller.chaseTarget = GameObject.FindGameObjectWithTag("Player").transform;
        //}

        //// Oblicza kierunek ucieczki - kierunek od gracza do AI
        //Vector3 runDirection = controller.transform.position - controller.chaseTarget.position;
        //runDirection.Normalize();

        //// Określa punkt do ucieczki
        //Vector3 runToPosition = controller.transform.position + runDirection * 50;

        //// Przenosi AI w kierunku punktu docelowego
        //controller.navMeshAgent.SetDestination(runToPosition);
        //controller.navMeshAgent.isStopped = false;
        //controller.navMeshAgent.updateRotation = true;
    }
}
