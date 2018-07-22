using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float speed = 1.0f;
    public int damagedealt = 1;
    public float timeLimit = 4.0f;
    private float timer;


    Vector2 direction;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        direction = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
        timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > timeLimit) {
            Destroy(gameObject);
        }
	}

    public void Fire(Vector2 direction) {
        if(direction == Vector2.zero) {
            throw new System.Exception("Attempted to fire bullet in direction (0.0, 0.0)");
        }
        this.direction = direction;
        if(rb == null) {
            rb = GetComponent<Rigidbody2D>();
        }
        rb.velocity = this.direction * speed;
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Enemy") {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damagedealt);
        }
        if(collision.tag != "Player") {
            Destroy(gameObject);
        }
    }


}
