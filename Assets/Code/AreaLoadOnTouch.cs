using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLoadOnTouch : MonoBehaviour {

    public List<GameObject> Locations;
    public List<GameObject> PrefabsToLoad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            Debug.Log("LoadingS Stuff");
            for(int i = 0; i<PrefabsToLoad.Count; i++) {
                GameObject prefab = PrefabsToLoad[i];
                Transform location = Locations[i].transform;
                prefab.transform.position = location.position;
                Instantiate(prefab);
            }
        }
    }
}
