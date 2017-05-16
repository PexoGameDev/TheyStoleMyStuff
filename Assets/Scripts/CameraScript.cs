using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    GameObject Player;
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	
	void FixedUpdate () {

        transform.position = Player.transform.position + new Vector3(0,15,-15);
	}
}
