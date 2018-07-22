using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int health = 3;

    public delegate void HealthRemaining(int health);
    public static event HealthRemaining healthRemainingEvent;

    public AudioClip hitSound;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount) {
        health -= amount;
        healthRemainingEvent(health);
        audioSource.PlayOneShot(hitSound);
        Debug.Log("Player took damage");
        if(health <= 0) {
            SceneManager.LoadScene(0);
        }
    }
}
