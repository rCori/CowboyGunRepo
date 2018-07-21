﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    Vector2 currentMovement;
    Vector2 lastDirection;
    Rigidbody2D rb;
    public float speed = 3.0f;
    private float currHoriz = 0.0f;
    private float currVert = 0.0f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        currentMovement = new Vector2(0f,0f);
        lastDirection = new Vector2(1.0f, 0.0f);
        CharacterShooting.Fire += GetCurrentMovement;
	}
	
	// Update is called once per frame
	void Update () {
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
        currentMovement.Normalize();
        currentMovement *= Time.deltaTime * speed;
        if(currentMovement.x != 0.0f && currentMovement.y != 0.0f) {
            lastDirection = currentMovement;
        }
        rb.velocity = currentMovement;
    }

    public Vector2 GetCurrentMovement() {
        return currentMovement;
    }

}