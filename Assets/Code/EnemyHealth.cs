using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int health = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //I will make this function later
    public void TakeDamage(int damage){
        Debug.Log("Damage Taken");
        health -= damage;

        if(health <= 0) {
            Destroy(gameObject);
        }
    }
 }
