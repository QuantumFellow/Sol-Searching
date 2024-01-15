using System.Collections;
using UnityEngine;

public class CharacterControllerhell : MonoBehaviour
{
    private Rigidbody2D Reggie;
    public float Speed, JumpForce;
    public LayerMask Groundis;
    public bool isGrounded;
    public Transform GroundCheck;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private float previousYPosition;

    // Start is called before the first frame update
    void Start()
    {
        Reggie = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        previousYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.5f, Groundis);

        if (isGrounded)
        {
        }

        float moveInput = Input.GetAxis("Horizontal");
        Reggie.velocity = new Vector2(moveInput * Speed, Reggie.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput < 0)
        {
            spriteRenderer.flipX = false;
        } 
        else if (moveInput > 0)
        {
            spriteRenderer.flipX = true;
        }

        float currentYPosition = transform.position.y;
        float verticalMovement = currentYPosition - previousYPosition;


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }


    private void Jump()
    {
        animator.SetBool("IsJumping", true);
        Reggie.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        Debug.Log("isjumping");
    }

    public void resetJumpAnim() 
    {
        animator.SetBool("IsJumping", false);

    }

}

