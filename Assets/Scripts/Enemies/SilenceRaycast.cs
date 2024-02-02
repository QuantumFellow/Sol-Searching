using System.Collections;
using UnityEngine;

public class SilenceRaycast : MonoBehaviour
{
    public float raycastDistance = 5f; // Distance to raycast
    public LayerMask Player;      // Layer mask for the player
    public Animator enemyAnimator;     // Reference to the enemy's Animator component


    private bool playerDetected = false;

    void Update()
    {
        // Raycast to the left to detect the player
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance, Player);
        Debug.DrawRay(transform.position, Vector2.left * raycastDistance, Color.red);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            // Player detected
            if (!playerDetected)
            {
                PlayerDetected();
            }
        }
        else
        {
            // Player not detected
            if (playerDetected)
            {
                StartCoroutine(WaitForPlayerLost());
            }
        }
    }

    void PlayerDetected()
    {
        Debug.Log("PlayerSeen");
        playerDetected = true;
        // Play animation for player detected
        enemyAnimator.SetTrigger("PlayerDetected");
        enemyAnimator.ResetTrigger("PlayerLost");
    }

    IEnumerator WaitForPlayerLost()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("PlayerLost");
        // Play animation for player lost
        enemyAnimator.SetTrigger("PlayerLost");
        enemyAnimator.ResetTrigger("PlayerDetected");

        playerDetected = false;
    }
}

