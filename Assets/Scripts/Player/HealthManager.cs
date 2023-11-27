using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HealthManager : MonoBehaviour
{
    public int maxHealth = 4;
    private int currentHealth;
    public float invincibilityDuration = 2f; //invincibility in secs
    private bool isInvincible = false;
    private float invincibilityTimer = 0f;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        //update timer
        if (isInvincible)
        {
            invincibilityTimer -= Time.fixedDeltaTime;

            //if time out deactivate invincibility
            if (invincibilityTimer <= 0)
            {
                isInvincible = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike") && !isInvincible)
        {
            // If not invincible and collides w enemy takes dmg
            TakeDamage(1);

            //start invincibility
            StartInvincibility();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //add deathscrn / death noise here
        Debug.Log("Player has died!");
    }

    private void StartInvincibility()
    {
        if (currentHealth > 0)
        {
            Debug.Log("Is invincible");
            isInvincible = true;
            invincibilityTimer = invincibilityDuration;
        }

    }
}

