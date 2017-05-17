using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    //Publics

    //Privates
    GameControler GC;
    [SerializeField]
    private PlayerState myPlayerState;
    public PlayerState MyPlayerState
    {
        get { return myPlayerState; }
        set { myPlayerState = value; if (value == PlayerState.Caught) print("TheyGotMe"); }
    }
    public enum PlayerState
    { Normal,Caught,Dead };

    void Start () {
        GC = GameObject.FindGameObjectWithTag("GameScripts").GetComponent<GameControler>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Target")
        {
            other.transform.SetParent(transform);
            other.transform.localPosition = new Vector3(0f, 2f, 0f);
            GC.StateOfTarget = GameControler.TargetState.PickedUp;
            other.GetComponent<Collider>().enabled = false;
        }
    }
}
