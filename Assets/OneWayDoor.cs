using UnityEngine;

public class OneWayDoor : MonoBehaviour
{
    private bool playerInside = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !playerInside)
        {
            // Player has entered the one-way door
            playerInside = true;
            // Perform any actions you want when the player enters the door
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerInside)
        {
            // Player is trying to exit the one-way door
            // Prevent the player from leaving (you can modify this behavior as needed)
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.transform.position = transform.position;
            // Perform any actions you want when the player attempts to exit
        }
    }
}

