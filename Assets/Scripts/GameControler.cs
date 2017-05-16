using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour {

    private TargetState stateOfTarget;
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

	void Start () {
        // myMouse = Instantiate<Mouse>(new Mouse());
        // print(myMouse.shootTexture);
        //Cursor.SetCursor(myMouse.shootTexture, Vector2.zero, CursorMode.Auto);
    }
	void Update () {
        
    }

}
