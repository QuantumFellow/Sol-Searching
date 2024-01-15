using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public int damageAmount = 1; //dmg enemy deals

    public void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            //checks for player tag
            HealthManager playerHealth = other.GetComponent<HealthManager>();

            if (playerHealth != null)
            {
                //calls takedmg function
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
