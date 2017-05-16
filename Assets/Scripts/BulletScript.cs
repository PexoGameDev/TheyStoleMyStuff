using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float bulletSpeed = 0.1f, RotateSpeed = 1f;
    Vector3 Target;
	void Start () {
        Vector3 mousePos = Input.mousePosition;
        RaycastHit hit;
        Ray TargetRay = Camera.main.ScreenPointToRay(mousePos);
        Physics.Raycast(TargetRay, out hit);
        Target = hit.point - transform.position;
        Target.y = 0;
        Target = Target.normalized;
        print(Target);
        StartCoroutine(DestroySelf());
        print(mousePos);
        print(hit);
        print(TargetRay);
        print(hit.point);
        print(Target);
    }

    void FixedUpdate () {
        transform.position += Target*bulletSpeed;
        transform.Rotate(new Vector3(0,RotateSpeed, 0));
        //Vector3.MoveTowards(transform.position,Target,bulletSpeed);
        //WORKS BUT ISNT PRECISE, FIX IT
        //Maybe instead -> Guard Script, OnMouseStay, if left click then shoot from player to guard? Finally it's not 2.5D Shooter but stealth, plus you've never done such a thing
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
