using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class InGameAreaLoader : MonoBehaviour {

    [System.Serializable]
    public class DynamicLoadingGameObject {
        public GameObject gameObject;
        public Vector2 location;
        public string resourceName;
        public string loadTag;

        public DynamicLoadingGameObject() {
            gameObject = null;
            location = Vector2.zero;
            resourceName = "";
            loadTag = "";
        }

        public DynamicLoadingGameObject(GameObject gameObject, Vector3 location, string resourceName, string loadTag) {
            this.gameObject = gameObject;
            this.location = location;
            this.resourceName = resourceName;
            this.loadTag = loadTag;
        } 
    }

    private List<DynamicLoadingGameObject> currentLoaded;

	// Use this for initialization
	void Start () {
        currentLoaded = new List<DynamicLoadingGameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void AddToScene(Vector2 location, string resourceName, string tag) {
        Debug.Log("Attempting to load object: " + resourceName);
        GameObject gameObject = (GameObject)Resources.Load(resourceName, typeof(GameObject));
        Assert.IsNotNull(gameObject);
        gameObject.transform.position = location;
        gameObject = Instantiate(gameObject);
        DynamicLoadingGameObject dynamicLoadingGameObject = new DynamicLoadingGameObject(gameObject, location, resourceName, tag);
        currentLoaded.Add(dynamicLoadingGameObject);
    }

    public void RemoveFromScene(string tag) {
        foreach(DynamicLoadingGameObject removalAsset in currentLoaded) {
            //Remove all assets with given tag
            if(removalAsset.loadTag == tag && gameObject != null) {
                Debug.Log("Removing  gameObject: " + gameObject.name);
                Destroy(removalAsset.gameObject);
            }
        }
    
    } 
}
