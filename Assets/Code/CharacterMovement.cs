using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    Vector2 currentMovement;
    Vector2 lastDirection;
    Rigidbody2D rb;
    public float speed = 3.0f;
    private float currHoriz = 0.0f;
    private float currVert = 0.0f;
    Animator animator;

    bool playerDead;

	// Use this for initialization
	void Start () {
        playerDead = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentMovement = new Vector2(0f,0f);
        lastDirection = new Vector2(1.0f, 0.0f);

        //Event Subscriptions
        PlayerHealth.playerDiedEvent += PlayerHasDied;
        CharacterShooting.Fire += GetLastDirection;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerDead) return;

        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        if(currHoriz != horiz || currVert != vert) {
            MoveOnInput(horiz, vert);
        }

	}

    private void MoveOnInput(float horiz, float vert) {
        currHoriz = horiz;
        currVert = vert;

        currentMovement.x = horiz;
        currentMovement.y = vert;
        currentMovement = currentMovement.normalized;
        if(horiz != 0.0f || vert != 0.0f) {
            lastDirection = currentMovement;
            animator.SetBool("IsMoving", true);
            //Debug.Log("Last Direction:" + lastDirection);
        }
        else {
            animator.SetBool("IsMoving", false);
        }
        currentMovement *= speed;
        rb.velocity = currentMovement;
    }

    public Vector2 GetLastDirection() {
        return lastDirection;
    }

    public void PlayerHasDied() {
        rb.velocity = Vector2.zero;
        playerDead = true;
    }

    //Must unsubscribe on destroy for static events
    private void OnDestroy() {
        PlayerHealth.playerDiedEvent -= PlayerHasDied;
        CharacterShooting.Fire -= GetLastDirection;
    }
}
