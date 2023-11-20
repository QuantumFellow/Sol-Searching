using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public GameObject Collectible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //if ending collides with the player
        {
            UnityEngine.Debug.Log("Collected");
            Object.Destroy(Collectible);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
