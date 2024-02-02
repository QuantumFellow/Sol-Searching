using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TuningFork : MonoBehaviour
{
    public float proximityDistance = 2f;
    private bool WithinRange;
    public GameObject PlayerKeyPrompt;


    // Start is called before the first frame update
    void Start()
    {
        PlayerKeyPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (WithinRange)
        {
            PlayerKeyPrompt.SetActive(true);
        }
            // Check if the player is in proximity and scrolling downwards
        if (WithinRange && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("J_Level");
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            WithinRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            WithinRange = false;
            PlayerKeyPrompt.SetActive(false);
        }
    }
}

