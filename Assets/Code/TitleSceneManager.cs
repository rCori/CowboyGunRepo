using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager: MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
            PlayerPersistentStats.GetPlayerPersistentStats().SetPX(0.0f);
            PlayerPersistentStats.GetPlayerPersistentStats().SetPY(0.0f);
            SceneManager.LoadScene(1);
        }
	}
}
