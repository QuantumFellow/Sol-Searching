using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbManager : MonoBehaviour
{
    public LayerMask climbableLayer;

    private Rigidbody2D rb2d;
    private bool isClimbing = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isClimbing)
        {
            // Perform climbing actions
            Climb();
        }
    }

    void Climb()
    {
        // Add climbing behavior here
        // For example, you can move the player upward or perform other climbing actions
        // You might also want to add a check to limit how far the player can climb

        // Example: Move the player upward
        rb2d.velocity = new Vector2(rb2d.velocity.x, 5f);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Check if the player is in contact with a climbable object
        if (other.gameObject.layer == LayerMask.NameToLayer("Chladni"))
        {
            isClimbing = true;
            rb2d.gravityScale = 0f; // Disable gravity while climbing
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Reset climbing state when leaving the climbable object
        if (other.gameObject.layer == LayerMask.NameToLayer("Chladni"))
        {
            isClimbing = false;
            rb2d.gravityScale = 1f; // Restore gravity when not climbing
        }
    }
}

