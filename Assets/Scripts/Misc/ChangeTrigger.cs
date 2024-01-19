using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTrigger : MonoBehaviour
{
    private Collider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Collider component attached to this GameObject
        myCollider = GetComponent<Collider2D>();

        // Make sure the Collider is not initially a trigger
        myCollider.isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "InkCollector" tag
        if (other.CompareTag("InkCollector"))
        {
            // Set the Collider to be a trigger
            myCollider.isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding object has the "InkCollector" tag
        if (other.CompareTag("InkCollector"))
        {
            // Set the Collider to not be a trigger
            myCollider.isTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
