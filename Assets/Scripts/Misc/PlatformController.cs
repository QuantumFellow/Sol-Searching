using System.Collections;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float boostForce = 10f;
    public float proximityDistance = 2f;
    public Animator animator;

    private Coroutine delayCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Apply a force to boost the player upwards
                playerRb.AddForce(Vector2.up * boostForce, ForceMode2D.Impulse);
            }
        }
    }

    private void Update()
    {
        // Check if the player is within proximity
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            // Check if the player is in proximity and scrolling downwards
            if (distance < proximityDistance && Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                animator.SetBool("SummonPlat", true);
            }
            else if (distance < proximityDistance && Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                animator.SetBool("SummonSpike", true);

                // Start a coroutine to delay the execution of the next animation
                if (delayCoroutine != null)
                {
                    StopCoroutine(delayCoroutine);
                }
                delayCoroutine = StartCoroutine(DelayBeforeNextAnimation());
            }
            else
            {
                animator.SetBool("SummonPlat", false);
                animator.SetBool("SummonSpike", false);
            }
        }
    }

    private IEnumerator DelayBeforeNextAnimation()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(1);

        // Trigger the next animation here
        animator.SetBool("LowerSpike", true);
    }

    void changetag()
    {
        if (gameObject.tag == "Ground")
        {
            gameObject.tag = "Spike";
        }
        else
        {
            gameObject.tag = "Ground";
        }
    }
}

