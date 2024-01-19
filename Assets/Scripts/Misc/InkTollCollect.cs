using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkTollCollect : MonoBehaviour
{
    public int collectibleCount = 0;  // Variable to store the number of collectibles collected
    public Animator animator;  // Reference to the Animator component for animation

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            // Increment the collectible count
            collectibleCount++;

            // Destroy the collected collectible (you can replace this with your own logic)
            Destroy(other.gameObject);

            // Check if the required number of collectibles has been reached
            if (collectibleCount >= 4)
            {
                // Trigger the animation
                if (animator != null)
                {
                    animator.SetInteger("InkCollected", collectibleCount);
                }
            }
        }
    }

    void ResetInt()
    {
        animator.SetInteger("InkCollected", 0);
    }
}
