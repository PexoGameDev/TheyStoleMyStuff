using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {
    NavMeshAgent myNavMesh;
    Vector3 mousePos, MovementDestination, DEBUG; // DEBUG is a hit.point with y set to 0
    RaycastHit hit;
    Ray TargetRay;
    // Use this for initialization
    void Start () {
        myNavMesh = GetComponent<NavMeshAgent>();

	}

	void Update () {
        mousePos = Input.mousePosition;
        TargetRay = Camera.main.ScreenPointToRay(mousePos);
        Physics.Raycast(TargetRay, out hit);
        DEBUG = hit.point;
        DEBUG.y = 0;
        MovementDestination = DEBUG - transform.position; 

        Debug.DrawRay(Camera.main.transform.position, DEBUG, Color.red);
        //Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);

        if (Input.GetMouseButtonDown(1))
        {
            mousePos = Input.mousePosition;
            TargetRay = Camera.main.ScreenPointToRay(mousePos);
            Physics.Raycast(TargetRay, out hit,9);
            MovementDestination = hit.point - transform.position;
            //MovementDestination.y = 0;
            mousePos = Input.mousePosition;
            myNavMesh.SetDestination(MovementDestination);
            print(myNavMesh.destination);
            print("set");
        }
	}
}
