using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float bulletSpeed = 0.1f, RotateSpeed = 1f, timeTillDestroy = 0.5f;
    Vector3 Target;
	void Start () {
        Vector3 mousePos = Input.mousePosition;
        RaycastHit hit;
        Ray TargetRay = Camera.main.ScreenPointToRay(mousePos);
        Physics.Raycast(TargetRay, out hit);
        transform.LookAt(hit.point);
        Target = hit.point - transform.position;
        Target.y = 0;
        Target = Target.normalized;
        StartCoroutine(DestroySelf());
    }

    void FixedUpdate () {
        transform.position += Target*bulletSpeed;
        transform.Rotate(new Vector3(0, 0, RotateSpeed));
        }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(timeTillDestroy);
        Destroy(gameObject);
    }
}
