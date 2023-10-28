using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Complete;

public class StateController : MonoBehaviour 
{
	public EnemyStats enemyStats;
	public Transform eyes;

    public State currentState;

    [SerializeField] private Transform _patrolPointContainer;

    [HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public TankShooting tankShooting;
    [HideInInspector] public Transform[] wayPointList;
    [HideInInspector] public TankHealth tankHealth;

    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;

    private bool aiActive;
    protected bool isHitDetected;


    void Awake () 
	{
		tankShooting = GetComponent<TankShooting> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
        tankHealth = GetComponent<TankHealth> ();
        SetupAI(true, _patrolPointContainer.GetComponentsInChildren<Transform>());
	}

	public void SetupAI(bool aiActivationFromTankManager, Transform[] wayPointsFromTankManager)
    {
        wayPointList = wayPointsFromTankManager;
        aiActive = aiActivationFromTankManager;
		if (aiActive) 
		{
			navMeshAgent.enabled = true;
		} 
        else 
		{
			navMeshAgent.enabled = false;
		}
	}

    void Update()
    {
        if (!aiActive)
            return;
        stateTimeElapsed += Time.deltaTime;
        currentState.UpdateState(this);
        //if(tankHealth!= null )
        //{
        //    isHitDetected = tankHealth.HasHitDetecred();
        //}
    }

    void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
        }
    }

    public void TransitionToState(State nextState)
    {
        currentState = nextState;
        OnExitState();
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        if(stateTimeElapsed >= duration)
        {
            stateTimeElapsed = 0;
            return true;
        }
        return false;
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }
}