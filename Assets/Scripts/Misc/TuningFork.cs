using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuningFork : MonoBehaviour
{
    public float proximityDistance = 2f;
    public GameObject Chladni;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            // Check if the player is in proximity and scrolling downwards
            if (distance < proximityDistance && Input.GetKeyDown(KeyCode.E))
            {
                Chladni.SetActive(true);
            }
            else
            {

            }
        }
    }
}

