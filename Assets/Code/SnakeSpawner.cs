using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSpawner : MonoBehaviour {

    public float spawnRate;
    private float spawnTimer;

    private GameObject SnakeObject;

	// Use this for initialization
	void Start () {
        spawnTimer = 0.0f;
		SnakeObject = Resources.Load("Prefabs/Snake") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > spawnRate) {
            spawnTimer = 0.0f;
            SnakeObject.transform.position = transform.position;
            Instantiate(SnakeObject);
        }
	}
}
