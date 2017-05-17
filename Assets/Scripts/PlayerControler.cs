using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    //Publics

    //Privates
    GameControler GC;
    void Start () {
        GC = GameObject.FindGameObjectWithTag("GameScripts").GetComponent<GameControler>();
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
