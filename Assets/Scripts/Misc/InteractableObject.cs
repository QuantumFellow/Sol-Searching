using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public float interactionDistance = 3f;
    public GameObject player;
    //basic interact script for use later

    private void Start()
    {
        if (player == null)
        {
            //finds player
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void Update()
    {
        //if player in range
        if (Vector3.Distance(transform.position, player.transform.position) <= interactionDistance)
        {
            // Player is close enough do stuff here
            Debug.Log("Player is close enough to interact with the object!");

            // code for interaction goes here
        }
        else
        {
            // Player not in range
        }
    }
}
