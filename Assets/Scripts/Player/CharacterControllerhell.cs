using System.Collections;
using UnityEngine;
using FMOD.Studio;

public class CharacterControllerhell : MonoBehaviour
{
    private Rigidbody2D Reggie;
    public float Speed, JumpForce;
    public LayerMask Groundis;
    public bool isGrounded;
    public Transform GroundCheck;
    public Animator animator;
    private SpriteRenderer spriteRenderer;


    //audio
    private EventInstance playerfootsteps;

    private bool isScrolling; // Added variable to track if scrolling is happening

    // Start is called before the first frame update
    void Start()
    {
        Reggie = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerfootsteps = AudioManager.instance.CreateEventInstance(FMODEvents.instance.PlayerFootsteps);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.5f, Groundis);

        float moveInput = Input.GetAxis("Horizontal");
        Reggie.velocity = new Vector2(moveInput * Speed, Reggie.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }



        // Check if the scroll button is being used
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float scrollingInput = Input.GetAxis("Horizontal");
        //Debug.Log(scrollingInput);
        animator.SetFloat("IsPlay", Mathf.Abs(scrollingInput));


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        UpdateSound();
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

    private void UpdateSound()
    {
        if (Reggie.velocity.x != 0 && isGrounded)
        {
            PLAYBACK_STATE playbackstate;
            playerfootsteps.getPlaybackState(out playbackstate);
            if (playbackstate.Equals(PLAYBACK_STATE.STOPPED))
            {
                playerfootsteps.start();
            }
        }
        else
        {
            playerfootsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }
}


