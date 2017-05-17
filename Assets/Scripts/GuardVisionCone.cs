using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardVisionCone : MonoBehaviour {

    public GuardScript myGuard;
    PatrolScript myPatrol;
    GameObject Player;
    GameControler GC;
    Coroutine SeeingPlayer;
    void Start() {
        GC = GameObject.FindGameObjectWithTag("GameScripts").GetComponent<GameControler>();
        Player = GameObject.FindGameObjectWithTag("Player");
        myPatrol = gameObject.GetComponentInParent<PatrolScript>();
    }
    IEnumerator CanISeePlayer()
    {
        if (!Physics.Linecast(transform.parent.position, Player.transform.position))
            myPatrol.actualState = PatrolScript.State.Hostile;
        else
            if (myPatrol.actualState == PatrolScript.State.Hostile)
            myPatrol.actualState = PatrolScript.State.Alerted;
        yield return new WaitForSeconds(0.5f);
        SeeingPlayer = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        print("PlayerEnteredFOV");   
    }

    private void OnTriggerStay(Collider other)
    {
        if (GC.StateOfTarget == GameControler.TargetState.PickedUp)
        {
            if (other.CompareTag("Player") && SeeingPlayer == null)
                SeeingPlayer = StartCoroutine(CanISeePlayer());
            if (other.CompareTag("TargetContainer") && myPatrol.actualState != PatrolScript.State.Hostile)
            {
                print("I've noticed empty target container! I'm alerted now!");
                myPatrol.actualState = PatrolScript.State.Alerted;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // if(SeeingPlayer != null)
            // StopCoroutine(SeeingPlayer);
            // SeeingPlayer = null;
            if (myPatrol.actualState == PatrolScript.State.Hostile)
            {
                myPatrol.SeenPlayerPosition = Player.transform.position;
                myPatrol.actualState = PatrolScript.State.SeenPlayer;
            }
            print("PlayerLeftFOV");
        }
    }
}
