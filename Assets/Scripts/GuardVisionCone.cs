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

    IEnumerator NoticedEmptyContainer(GameObject Container)
    {
        if (!Physics.Linecast(transform.parent.position, Container.transform.position))
        {
            transform.parent.LookAt(Container.transform);
            yield return new WaitForSeconds(0.5f);
            myPatrol.SeenPlayerPosition = Container.transform.position;
            myPatrol.actualState = PatrolScript.State.SeenPlayer;
        }
            yield return new WaitForSeconds(0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GC.StateOfTarget == GameControler.TargetState.PickedUp)
        {
            if (other.CompareTag("TargetContainer") && myPatrol.actualState != PatrolScript.State.Hostile && myPatrol.savedState != PatrolScript.State.Alerted)
            {
                StartCoroutine(NoticedEmptyContainer(other.gameObject));
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (GC.StateOfTarget == GameControler.TargetState.PickedUp)
        {
            if (other.CompareTag("Player") && SeeingPlayer == null)
                SeeingPlayer = StartCoroutine(CanISeePlayer());
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
