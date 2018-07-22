using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CharacterShooting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
        GameObject bullet = Resources.Load("Prefabs/PlayerBullet") as GameObject;
        Vector2 bulletDirection = Fire();
       // Debug.Log("Bullet Direction:" + bulletDirection);
        Assert.IsNotNull(bullet);
        bullet.transform.position = gameObject.transform.position;
        bullet = Instantiate(bullet);
        bulletDirection = -bulletDirection;
        PlayerBullet playerBullet = bullet.GetComponent<PlayerBullet>();
        playerBullet.Fire(bulletDirection);
    }

}
