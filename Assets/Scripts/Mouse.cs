using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour{

    
    public Texture2D defTexture, shootTexture, moveTexture, decoyTexture, dragTexture, blendinTexture;

	public Mouse() {
        //shootTexture = Resources.Load("/Graphics/Mouse/Cursors/shootTexture") as Texture2D;
    }
	
    enum Cursor
    {
        def,
        shoot,
        move,
        decoy,
        drag,
        blendin
    }

	void Update () {
		
	}
}
