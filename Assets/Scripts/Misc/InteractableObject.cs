using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public float interactionDistance = 3f; // Set the interaction distance in the Inspector
    public GameObject player; // Reference to the player GameObject

    private void Start()
    {
        if (player == null)
        {
            // If player reference is not set in the Inspector, try to find it in the scene
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void Update()
    {
        // Check if the player is close enough for interaction
        if (Vector3.Distance(transform.position, player.transform.position) <= interactionDistance)
        {
            // Player is close enough, perform interaction logic (e.g., show UI prompt, play sound, etc.)
            Debug.Log("Player is close enough to interact with the object!");

            // You can add your interaction code here
        }
        else
        {
            // Player is not close enough, do any additional logic if needed
        }
    }
}
