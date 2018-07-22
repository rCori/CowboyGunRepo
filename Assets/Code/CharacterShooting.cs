using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CharacterShooting : MonoBehaviour {

    public AudioClip fireClip;
    private AudioSource audioSource;

    private GameObject currentBullet;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
    public delegate Vector2 FireDelegate();
    public static event FireDelegate Fire;

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
            FireBullet();
        }
	}

    private void FireBullet() {
        if(currentBullet == null) {
            audioSource.PlayOneShot(fireClip);
            currentBullet = Resources.Load("Prefabs/PlayerBullet") as GameObject;
            Vector2 bulletDirection = Fire();
           // Debug.Log("Bullet Direction:" + bulletDirection);
            Assert.IsNotNull(currentBullet);
            currentBullet.transform.position = gameObject.transform.position;
            currentBullet = Instantiate(currentBullet);
            bulletDirection = -bulletDirection;
            PlayerBullet playerBullet = currentBullet.GetComponent<PlayerBullet>();
            playerBullet.Fire(bulletDirection);
        }
    }

}
