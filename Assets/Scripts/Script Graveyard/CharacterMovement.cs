using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //MOVING VARS----------------
    Rigidbody2D rb;
    float HorizontalVal;
    public float moveSpeed = 5f;

    //JUMPING VARS---------------
    public float jumpForce;
    int jumpsLeft;
    public float groundCheckRadius;
    public Transform groundCheck;
    public LayerMask groundLayer; //for groundchecks
    bool isGrounded;
    public Animator animator;
    //bool isMoving;

    //GRAV JUMP VARS-------------
    public float jumpmod = 1.5f;
    public float lowjumpmult = 1.25f;

    //ANIMATIONS-----------------
    //public Animator animator;
    public float scaleX;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        Jump();
        GravJump();
        //animator.SetFloat("Walking", Mathf.Abs(HorizontalVal)); //regardless of + or - speed

    }


    //FUNCTIONS---------------------------------------------------------------

    void move(float dir)
    {
        Flip();
        rb.velocity = new Vector2(HorizontalVal * moveSpeed, rb.velocity.y); //moves player left, right
        //isMoving = true;
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //if space pressed
        {
            animator.SetBool("Jumping", true);
            animator.SetFloat("Walking", 0);
            CheckIfGrounded();
            if (jumpsLeft > 0)
            {
                //FMODUnity.RuntimeManager.PlayOneShot("event:/Jump"); //plays jump sound
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpsLeft--;
            }
        }
    }

    public void CheckIfGrounded() //checks if player is on solid surface
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        ResetJumps();
        animator.SetBool("Jumping", false);
    }

    public void ResetJumps() //Allows reset of count for double jump
    {
        if (isGrounded)
        {
            jumpsLeft = 2; //resets the double jump
        }
    }

    public void GravJump() //allows for more control over gravity of jump, whether player falls faster
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (jumpmod - 1) * Time.fixedDeltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowjumpmult - 1) * Time.fixedDeltaTime;
        }
    }

    public void Flip() //allows image of sprite to be flipped in direction of movement
    {
        if (HorizontalVal < 0)
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        if (HorizontalVal > 0)
        {
            transform.localScale = new Vector3((-1) * scaleX, transform.localScale.y, transform.localScale.z);
        }

    }
}
