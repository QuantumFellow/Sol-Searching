using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HealthManager : MonoBehaviour
{
    public int maxHealth = 4;
    private int currentHealth;
    public float invincibilityDuration = 2f; //invincibility in secs
    private bool isInvincible = false;
    private float invincibilityTimer = 0f;
    public Animator enemyAnimator;
    public GameObject NewTask;

    private void Start()
    {
        currentHealth = maxHealth;
        enemyAnimator.SetBool("Dead", false);
        NewTask.SetActive(false);
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
        AudioManager.instance.PlayOneShot(FMODEvents.instance.SilenceHurt, this.transform.position);
        //add deathscrn / death noise here
        enemyAnimator.SetTrigger("Dead");
        Debug.Log("Silence has died!");
        StartCoroutine(WaitForDeath());
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


    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        NewTask.SetActive(true);

    }
}

