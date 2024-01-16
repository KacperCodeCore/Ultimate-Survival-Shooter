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
    [HideInInspector] public IHealth iTankHealth;
    //[HideInInspector] public TankHealth tankHealth;  // to do???
    [HideInInspector] public float previousHp;

    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public float currentRotation = 0;
    [HideInInspector] public float lastRotation = 0;

    [HideInInspector] public float totalRotateAngle;

    [HideInInspector] public float totalRotY;
    [HideInInspector] public bool sacnDir = true;

    [HideInInspector] public float startRotY = 0.0f;
    [HideInInspector] public Vector3 initLookAt = Vector3.zero;
    [HideInInspector] public bool rotRestored = false;

    private bool aiActive;
    protected bool isHitDetected;


    void Awake () 
	{

        _patrolPointContainer = GameObject.FindGameObjectWithTag("patroPointContainer").transform;

        tankShooting = GetComponent<TankShooting> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
        iTankHealth = GetComponent<TankHealth> ();
        previousHp = iTankHealth.CurrentHealth;
        //tankHealth = GetComponent<TankHealth> ();

        startRotY = transform.rotation.y;
        initLookAt = transform.position + (transform.forward * 3.0f);

        SetupAI(true, _patrolPointContainer != null ?
            _patrolPointContainer.GetComponentsInChildren<Transform>() : null);
	}


    public void SetupAI(bool aiActivationFromTankManager, Transform[] wayPointsFromTankManager)
    {
        wayPointList = wayPointsFromTankManager;
        aiActive = aiActivationFromTankManager;

        if(navMeshAgent != null)
        {
            navMeshAgent.enabled = aiActive;
        }

	}

    void Update()
    {
        if (!aiActive)
            return;
        stateTimeElapsed += Time.deltaTime;
        currentState.UpdateState(this);
        ////if (iTankHealth != null)
        ////{
        ////    isHitDetected = tankHealth.HasHitDetecred; // to jest źle;
        ////}
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

    public bool Scan(float rotation, float maxAngle)
    {
        if (sacnDir)
        {
            totalRotY += rotation;
            if(totalRotY >= maxAngle)
            {
                sacnDir = false; 
            }
            return true;
        }
        else
        {
            totalRotY -= rotation;
            if (totalRotY <= 0)
            {
                sacnDir = true;
            }
            return false;
        }
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
        totalRotateAngle = 0;
        totalRotY = 0f;
        rotRestored = false;
    }
}