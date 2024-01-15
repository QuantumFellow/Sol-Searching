using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    int jumpsLeft;
    public float groundCheckRadius;
    public Transform groundCheck;
    public LayerMask groundLayer; //for groundchecks
    bool isGrounded;
    public Animator animator;


    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Input for horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // Flip the sprite if moving left
        if (moveInput < 0)
            spriteRenderer.flipX = false;
        else if (moveInput > 0)
            spriteRenderer.flipX = true;

        // Move the character
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            animator.SetTrigger("JumpTrigger");
            CheckIfGrounded();
            if (jumpsLeft > 0)
            {
                //FMODUnity.RuntimeManager.PlayOneShot("event:/Jump"); //plays jump sound
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                jumpsLeft--;
                animator.ResetTrigger("JumpTrigger");
            }
        }



    }

    public void ResetJumps() //Allows reset of count for double jump
    {
        if (isGrounded)
        {
            jumpsLeft = 2; //resets the double jump
        }
    }

    public void CheckIfGrounded() //checks if player is on solid surface
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        ResetJumps();
        

    }
}

