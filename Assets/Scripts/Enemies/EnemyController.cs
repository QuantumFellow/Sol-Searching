using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float dashSpeed = 5f;
    public float jumpForce = 10f;
    public GameObject projectilePrefab;
    public LayerMask playerLayer;

    private bool isAttacking = false;

    void Start()
    {
        InvokeRepeating("RandomAttack", 0f, 4f); //time between attack in secs
    }

    void RandomAttack()
    {
        if (!isAttacking)
        {
            int randomAttack = Random.Range(0, 3);

            switch (randomAttack)
            {
                case 0:
                    JumpDash();
                    break;
                case 1:
                    ShootProjectile();
                    break;
                case 2:
                    CreateDamageZone();
                    break;
            }
        }
    }

    void JumpDash()
    {
        isAttacking = true;

        Debug.Log("Jump and Dash!");

        //gets players position
        Vector2 playerPosition = PlayerPosition();
        Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;

        //jump logic
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        //moves to player
        GetComponent<Rigidbody2D>().velocity = direction * dashSpeed;

        //continues dash until close enough
        InvokeRepeating("CheckPlayerDistance", 0f, 0.1f); //checks 0.1s
    }

    void CheckPlayerDistance()
    {
        Vector2 playerPosition = PlayerPosition();
        float distance = Vector2.Distance(transform.position, playerPosition);


        if (distance < 1f)
        {
            //reset attack state
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ResetAttackState();
        }
    }

    void ShootProjectile()
    {
        //creates prefab of a projectile and follows direction on player
        isAttacking = true;
        Debug.Log("Shoot Projectile!");
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector2 direction = (PlayerPosition() - (Vector2)transform.position).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * dashSpeed;
        Invoke("ResetAttackState", 1f);
    }

    void CreateDamageZone()
    {
        isAttacking = true;

        Debug.Log("Create Damage Zone!");

        Invoke("ResetAttackState", 1f);
    }

    Vector2 PlayerPosition()
    {
        return GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void ResetAttackState()
    {
        isAttacking = false;
        CancelInvoke("CheckPlayerDistance"); //cancels check range
        GetComponent<Rigidbody2D>().velocity = Vector2.zero; //stops enemy from moving after the dash
    }

    void Update()
    {
        //constant behaviours like idle animation here
    }
}

