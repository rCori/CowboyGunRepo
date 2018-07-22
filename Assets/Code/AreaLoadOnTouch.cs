using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLoadOnTouch : MonoBehaviour {

    [System.Serializable]
    public class AddObject {
        public string resourceName;
        public Vector2 location;
        public string tag;
    }

    //public List<GameObject> Locations;
    //public List<GameObject> PrefabsToLoad;

    public List<AddObject> addObjects;
    public List<string> removeTags;

    public InGameAreaLoader inGameAreaLoader;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        /*
        if(collision.tag == "Player") {
            Debug.Log("LoadingS Stuff");
            for(int i = 0; i<PrefabsToLoad.Count; i++) {
                GameObject prefab = PrefabsToLoad[i];
                Transform location = Locations[i].transform;
                prefab.transform.position = location.position;
                Instantiate(prefab);
            }
        }
        */
        foreach(AddObject addObject in addObjects) {
            inGameAreaLoader.AddToScene(addObject.location, addObject.resourceName,addObject.tag);
        }

        foreach(string tag in removeTags) {
            inGameAreaLoader.RemoveFromScene(tag);
        }
    }
}
