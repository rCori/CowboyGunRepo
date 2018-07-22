using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int health = 3;

    public delegate void HealthRemaining(int health);
    public static event HealthRemaining healthRemainingEvent;

    public delegate void PlayerDied();
    public static event PlayerDied playerDiedEvent;

    public AudioClip hitSound;
    public AudioClip deathSound;
    private AudioSource audioSource;
    private Animator animator;

    private bool playerDied;
    private float deathTimer;
    private float deathTimeLimit;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        deathTimeLimit = 3.0f;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerDied) {
            deathTimer += Time.deltaTime;
            if(deathTimer >= deathTimeLimit) {
                SceneManager.LoadScene(0);
            }
        }
	}

    public void TakeDamage(int amount) {
        if (playerDied) return;
        health -= amount;
        healthRemainingEvent(health);
        audioSource.PlayOneShot(hitSound);
        Debug.Log("Player took damage");
        if(health <= 0) {
            playerDied = true;
            animator.SetBool("PlayerDead", true);
            audioSource.PlayOneShot(deathSound);
            playerDiedEvent();
        }
    }
}
