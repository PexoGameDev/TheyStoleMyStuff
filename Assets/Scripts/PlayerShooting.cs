using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject BulletPrefab;
    public float WeaponDelay = 0.2f;
    Coroutine ActualShooting = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && ActualShooting == null)
            ActualShooting = StartCoroutine(Shoot());
	}

    IEnumerator Shoot()
    {
        Instantiate(BulletPrefab,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(WeaponDelay);
        ActualShooting = null;
    }
}
