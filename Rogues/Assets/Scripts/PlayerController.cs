﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    
    private Rigidbody2D rb2d;
    private Vector2 moveVelocity;
    
    public bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;

    public int maxJumps;
    public int extraJumps;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update(){
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {   
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
        float moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
        if (!facingRight && moveInput > 0){
            Flip();
        } else if (facingRight && moveInput < 0){
            Flip();
        }
        if(isGrounded){
            extraJumps = maxJumps;
        }
        if(!isGrounded && extraJumps == maxJumps){
            extraJumps--;
        }
        if(Input.GetButton("Jump") && extraJumps > 0){
            rb2d.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
    }
    void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
