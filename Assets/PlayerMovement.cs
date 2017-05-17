using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {
    NavMeshAgent myNavMesh;
    Vector3 mousePos, MovementDestination, DEBUG;
    RaycastHit hit;
    Ray TargetRay;
    void Start () {
        myNavMesh = GetComponent<NavMeshAgent>();

	}

	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            mousePos = Input.mousePosition;
            TargetRay = Camera.main.ScreenPointToRay(mousePos);
            Physics.Raycast(TargetRay, out hit);
            MovementDestination = hit.point;
            //MovementDestination.y = 0;
            mousePos = Input.mousePosition;
            myNavMesh.SetDestination(MovementDestination);
            print(myNavMesh.destination);
        }
	}
}
