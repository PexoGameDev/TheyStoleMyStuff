using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardScript : MonoBehaviour {


    GameControler GC;
    void Start () {
        GC     = GameObject.FindGameObjectWithTag("GameScripts").GetComponent<GameControler>();
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
