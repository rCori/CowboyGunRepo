using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public GameObject Subject;

    private Camera cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerScreenPoint = cam.WorldToViewportPoint(Subject.transform.position);

		if(playerScreenPoint.x < 0.25f) {
            //Move camera so it's not
            Vector3 target = cam.ViewportToWorldPoint(new Vector3(0.3f, 0.0f));
            Vector3 translationVector = new Vector3(Subject.transform.position.x - target.x, 0.0f, 0.0f);
            cam.transform.Translate(translationVector);
        }

        if(playerScreenPoint.x > 0.75f) {
            //Move camera so it's not
            Vector3 target = cam.ViewportToWorldPoint(new Vector3(0.75f, 0.0f));
            Vector3 translationVector = new Vector3(Subject.transform.position.x - target.x, 0.0f, 0.0f);
            cam.transform.Translate(translationVector);
        }

         if(playerScreenPoint.y > 0.75f) {
            //Move camera so it's not
            Vector3 target = cam.ViewportToWorldPoint(new Vector3(0.0f,0.75f));
            Vector3 translationVector = new Vector3(0.0f, Subject.transform.position.y - target.y, 0.0f);
            cam.transform.Translate(translationVector);
        }

          if(playerScreenPoint.y < 0.25f) {
            //Move camera so it's not
            Vector3 target = cam.ViewportToWorldPoint(new Vector3(0.0f,0.25f));
            Vector3 translationVector = new Vector3(0.0f, Subject.transform.position.y - target.y, 0.0f);
            cam.transform.Translate(translationVector);
        }
	}
}
