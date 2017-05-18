using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardScript : MonoBehaviour {

    GameObject Player;
    GameControler GC;
    PatrolScript myPatrol;
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        GC     = GameObject.FindGameObjectWithTag("GameScripts").GetComponent<GameControler>();
        myPatrol = gameObject.GetComponent<PatrolScript>();
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(GC.myMouse.shootTexture,Vector2.zero, CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }


       

}
