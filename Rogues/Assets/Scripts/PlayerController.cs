using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float originalSpeed;
    public float jumpForce;
    public float originalJumpForce;
    private Rigidbody2D rb2d;
    private Vector2 moveVelocity;
    
    public bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;

    public int maxJumps;
    public int extraJumps;

    private bool isFiring;
    private bool isStationary;

    Animator animator;

    public int currentColor = 0; //0 - white, 1 - red, 2 - green, 3 - blue 
    public Transform lightColor;

    public int points;
    public int maxPoints;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isFiring = false;
        originalJumpForce = jumpForce;
        originalSpeed = speed;
    }
    void Update(){
        animator.SetBool("IsStationary", isStationary);
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetBool("IsFiring", isFiring);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PrevColor();
            print(currentColor);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            NextColor();
            print(currentColor);
        }
        switch (currentColor)
        {
            case 0:
                lightColor.GetComponent<Light2D>().color = Color.white;
                break;
            case 1:
                lightColor.GetComponent<Light2D>().color = Color.red;
                break;
            case 2:
                lightColor.GetComponent<Light2D>().color = Color.green;
                break;
            case 3:
                lightColor.GetComponent<Light2D>().color = Color.blue;
                break;
            default: 
                lightColor.GetComponent<Light2D>().color = Color.white;
                break;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {   
        if(Mathf.Abs(rb2d.velocity.x) > 0) isStationary = false;
        else isStationary = true;
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
    void NextColor(){
        if(currentColor == 3){
            currentColor = 0;
        } else {
            currentColor += 1;
        }
    }
    void PrevColor(){
        if(currentColor == 0){
            currentColor = 3;
        } else {
            currentColor -= 1;
        }

    }
}
