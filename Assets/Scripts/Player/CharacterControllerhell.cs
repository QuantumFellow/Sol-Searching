using System.Collections;
using UnityEngine;
using FMOD.Studio;
using FMOD;

public class CharacterControllerhell : MonoBehaviour
{
    private Rigidbody2D Reggie;
    public float Speed, JumpForce;
    public LayerMask Groundis;
    public bool isGrounded;
    public Transform GroundCheck;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool hasPlayedUpSound = false;
    private bool hasPlayedDownSound = false;


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

        if (scrollInput > 0 && !hasPlayedUpSound)
        {
            // Scrolling up
            AudioManager.instance.PlayOneShot(FMODEvents.instance.BowUp, this.transform.position);
            hasPlayedUpSound = true;
            hasPlayedDownSound = false;
        }
        else if (scrollInput < 0 && !hasPlayedDownSound)
        {
            // Scrolling down
            AudioManager.instance.PlayOneShot(FMODEvents.instance.BowDown, this.transform.position);
            hasPlayedDownSound = true;
            hasPlayedUpSound = false;
        }

        // Reset flags when the mouse wheel is not being scrolled
        if (scrollInput == 0)
        {
            hasPlayedUpSound = false;
            hasPlayedDownSound = false;
        }

         //print(scrollInput);
        if (scrollInput != 0f)
        {
            animator.SetFloat("IsPlay", 0.2f);
        }


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
        AudioManager.instance.PlayOneShot(FMODEvents.instance.JumpSFX, this.transform.position);
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

    public void StopPlaying()
    {
        animator.SetFloat("IsPlay", 0f);
    }
    IEnumerator WaitForEndNote()
    {
        yield return new WaitForSeconds(1f);
    }
}


