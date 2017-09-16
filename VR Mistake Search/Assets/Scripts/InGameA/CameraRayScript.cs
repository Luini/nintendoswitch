using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayScript : MonoBehaviour {


    public Camera cam;
    // Use this for initialization

    private RaycastHit hit;
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(cam.transform.position,cam.transform.forward);
        Debug.DrawRay(ray.origin,ray.direction * 100);

        if (Physics.Raycast(ray,out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
	}
}
