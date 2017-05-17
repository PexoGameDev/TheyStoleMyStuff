using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour {

    private TargetState stateOfTarget;
    private GameObject[] patrolPoints;
    public GameObject[] PatrolPoints
    {
        get { return patrolPoints; }
        set { patrolPoints = value; }
    }
    public Mouse myMouse;
    public TargetState StateOfTarget
    {
        get
        {
            return stateOfTarget;
        }

        set
        {
            stateOfTarget = value;
        }
    }

    public enum TargetState
    {
        NotPickedUp,PickedUp
    }

	void Awake () {
        // myMouse = Instantiate<Mouse>(new Mouse());
        // print(myMouse.shootTexture);
        //Cursor.SetCursor(myMouse.shootTexture, Vector2.zero, CursorMode.Auto);
        PatrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");
        print(PatrolPoints);
    }
	void Update () {
        
    }

}
