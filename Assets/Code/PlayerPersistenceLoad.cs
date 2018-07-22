using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPersistenceLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float pX = PlayerPersistentStats.GetPlayerPersistentStats().GetPX();
        float pY = PlayerPersistentStats.GetPlayerPersistentStats().GetPY();
        Vector2 loadPos = new Vector2(pX, pY);
        transform.position = loadPos;
        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
