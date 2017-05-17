using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class PatrolScript : MonoBehaviour
{
    [SerializeField]
    int PatrolPointsCount = 5;
    public Transform[] PatrolPoints;
    [HideInInspector]
    public Vector3 SeenPlayerPosition;
    NavMeshAgent myNavMesh;
    int ActualPoint = 0;
    GameObject Player;
    public State savedState;
    private State ActualState;
    GameControler GC;
    Coroutine ActuallMovement;
    [SerializeField]
    float lookAroundDelay = 0.5f, lookAroundSpeed = 1f, lookAroundAngleMin = 20f, lookAroundAngleMax = 100f;
    public State actualState
    {
        get
        {
            return ActualState;
        }

        set
        {
            ActualState = value;
            //print("Changed state! New state: "+ActualState);
            if(!actualState.Equals(State.Immersed))
            StartCoroutine(ContinuePatrol());
        }
    }



    void Start()
    {
        GC = GameObject.FindGameObjectWithTag("GameScripts").GetComponent<GameControler>();
        myNavMesh = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        RandomizePatrolPoints();
        myNavMesh.SetDestination(PatrolPoints[ActualPoint].position);
        actualState = State.Immersed;
    }
    void RandomizePatrolPoints()
    {
        if(PatrolPoints.Length<=0)
        {
            List<GameObject> AllPatrolPoints = new List<GameObject>();
            PatrolPoints = new Transform[5];
            for (int i = 0; i < GC.PatrolPoints.Length; i++)
            {
               AllPatrolPoints.Add(GC.PatrolPoints[i]);
            }
            for (int i = 0; i < PatrolPoints.Length; i++)
            {
                int tmpRand = (int)Random.Range(0, AllPatrolPoints.Count);
                PatrolPoints[i]=GC.PatrolPoints[tmpRand].GetComponent<Transform>();
                print("This should be removed:"+AllPatrolPoints[tmpRand]);
                AllPatrolPoints.Remove(AllPatrolPoints[tmpRand]);//AllPatrolPoints.RemoveAt(tmpRand);
                print("This is here now:"+AllPatrolPoints[tmpRand]);
            }
        }
    }
    public enum State
    {
        Peacefull, Immersed, Alerted, Hostile, SeenPlayer
    }

    IEnumerator ContinuePatrol()
    {
        switch (actualState)
        {
            case State.Immersed:
                int RandAngle = (int)Random.Range(lookAroundAngleMin, lookAroundAngleMax);
                for (int i = 0; i < RandAngle; i++)
                {
                    transform.Rotate(0, lookAroundSpeed*2, 0);
                    yield return new WaitForSeconds(0.01f);
                }
                yield return new WaitForSeconds(lookAroundDelay);
                for (int i = 0; i < RandAngle; i++)
                {
                    transform.Rotate(0, -lookAroundSpeed, 0);
                    yield return new WaitForSeconds(0.01f);
                }
                yield return new WaitForSeconds(lookAroundDelay);
                for (int i = 0; i < RandAngle; i++)
                {
                    transform.Rotate(0, lookAroundSpeed, 0);
                    yield return new WaitForSeconds(0.01f);
                }
                yield return new WaitForSeconds(lookAroundDelay);

                actualState = savedState;
                if (actualState == State.Alerted)
                    goto case State.Alerted;
                else if (actualState == State.Peacefull)
                    goto case State.Peacefull;
                else
                    break;

            default:
            case State.Peacefull:
                ActualPoint = (ActualPoint + 1) % PatrolPoints.Length;
                myNavMesh.speed = 5;
                lookAroundDelay = 0.5f;
                lookAroundSpeed = 1f;
                savedState = State.Peacefull;
                break;

            case State.Alerted:
                ActualPoint = (int)Random.Range(0, PatrolPoints.Length);
                myNavMesh.speed = 8;
                lookAroundDelay = 0.2f;
                lookAroundSpeed = 1.5f;
                savedState = State.Alerted;
                break;

            case State.Hostile:
                ActualPoint = -1;
                myNavMesh.speed = 11;
                myNavMesh.SetDestination(Player.transform.position);
                savedState = State.Alerted;
                break;
            case State.SeenPlayer:
                ActualPoint = -1;
                myNavMesh.SetDestination(SeenPlayerPosition);
                savedState = State.Alerted;
                actualState = State.Immersed;
                break;
        }
        if (ActualPoint != -1)
            myNavMesh.SetDestination(PatrolPoints[ActualPoint].position);

        ActuallMovement = null;

        if (actualState != State.Hostile && actualState != State.SeenPlayer)
            actualState = State.Immersed;
        yield return new WaitForSeconds(0.1f);
    }

void Update()
    {
        if (myNavMesh.remainingDistance < 1f && actualState != State.Hostile && ActuallMovement == null)
            ActuallMovement = StartCoroutine(ContinuePatrol());
        if (actualState == State.SeenPlayer)
            ActuallMovement = StartCoroutine(ContinuePatrol());

        if (actualState == State.Hostile)// && ActuallMovement == null)
            myNavMesh.SetDestination(Player.transform.position);
            //ActuallMovement=StartCoroutine(ContinuePatrol());

    }
}
