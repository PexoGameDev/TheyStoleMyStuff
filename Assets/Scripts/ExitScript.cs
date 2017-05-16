using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {


    GameControler GC;

	void Start () {
        GC = GameObject.FindGameObjectWithTag("GameScripts").GetComponent<GameControler>();	
	}

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Player" && GC.StateOfTarget == GameControler.TargetState.PickedUp)
          //  print("Player Won!");
    }
}
