using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    //Publics

    //Privates
    GameControler GC;
    float MovementSpeed = 0.2f, RotateSpeed = 2.5f;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    void Start () {
        GC = GameObject.FindGameObjectWithTag("GameScripts").GetComponent<GameControler>();
        controller = GetComponent<CharacterController>();
    }
	
	void FixedUpdate () {
        Movement();
    }


    void Movement()
    {
        moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= MovementSpeed;
        controller.Move(moveDirection);
        transform.Rotate(0, Input.GetAxis("Horizontal")*RotateSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Target")
        {
            other.transform.SetParent(transform);
            other.transform.localPosition = new Vector3(0.5f, 1f, 0f);
            GC.StateOfTarget = GameControler.TargetState.PickedUp;
        }
    }
}
