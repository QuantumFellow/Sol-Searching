using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prox : MonoBehaviour
{
    public float proximityDistance = 2f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is within proximity
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            // Check if the player is in proximity and scrolling downwards
            if (distance < proximityDistance && Input.GetAxis("Mouse ScrollWheel") < 0f)
            {

            }
            else if (distance < proximityDistance && Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                animator.SetBool("Bowstring", true);
            }
        }
    }

    public void StopAnim()
    {
        animator.SetBool("Bowstring", false);
    }
}
