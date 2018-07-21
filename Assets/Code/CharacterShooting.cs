using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    public delegate Vector2 FireDelegate();
    public static event FireDelegate Fire;

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
            GameObject bullet = Resources.Load("Prefabs/Bullets") as GameObject;
            Vector2 bulletDirection = Fire();
            Debug.Log("Bullet Direction:" + bulletDirection);
        }
	}
}
