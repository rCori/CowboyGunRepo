using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehavior : MonoBehaviour {

    private GameObject playerObject;

    private Vector2 moveVelocity;
    private bool moveInProgress;
    private float moveTimer;
    public float moveTimeLimit;
    public float speed;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        moveTimer = 0.0f;
        moveInProgress = false;
		playerObject = GameObject.FindGameObjectsWithTag("Player")[0];
        rb = GetComponent<Rigidbody2D>();
        DecideMove();
	}
	
	// Update is called once per frame
	void Update () {
		if(moveInProgress) {
            moveTimer += Time.deltaTime;
        }
        if(moveTimer > moveTimeLimit) {
            moveInProgress = false;
            DecideMove();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            collision.GetComponent<PlayerHealth>().TakeDamage(1);
            Destroy(gameObject);
        }
    }

    void DecideMove() {
        int decision = Random.Range(0, 3);
        Vector3 currLocation = transform.position;
        Vector2 distance = currLocation - playerObject.transform.position;

        //If your horizontal disantce is greater than vertical
        if(Mathf.Abs(distance.x) > Mathf.Abs(distance.y)) {
            
            //Snake is to the right
            if(distance.x > 0) {
                switch(decision) {
                //Left
                case 0:
                    moveVelocity = Vector2.left * speed;
                    break;
                //Up
                case 1:
                    moveVelocity = Vector2.up * speed;
                    break;
                //Down
                case 2:
                    moveVelocity = Vector2.down * speed;
                    break;
                }
            //Snake is to the left
            } else{
                switch(decision) {
                //Right
                case 0:
                    moveVelocity = Vector2.right * speed;
                    break;
                //Up
                case 1:
                    moveVelocity = Vector2.up * speed;
                    break;
                //Down
                case 2:
                    moveVelocity = Vector2.down * speed;
                    break;
                }
            }
        }
        //If vertical distance is greater than horizontal
        else {
            //Snake is above
            if(distance.y > 0) {
                switch(decision) {
                //Left
                case 0:
                    moveVelocity = Vector2.left * speed;
                    break;
                //Right
                case 1:
                    moveVelocity = Vector2.right * speed;
                    break;
                //Down
                case 2:
                    moveVelocity = Vector2.down * speed;
                    break;
                }
            //Snake is below
            } else{
                switch(decision) {
                 //Left
                case 0:
                    moveVelocity = Vector2.left * speed;
                    break;
                //Right
                case 1:
                    moveVelocity = Vector2.right * speed;
                    break;
                //Up
                case 2:
                    moveVelocity = Vector2.up * speed;
                    break;
                }
            }

        }
        rb.velocity = moveVelocity;
        moveInProgress = true;
        moveTimer = 0.0f;
    }
}
