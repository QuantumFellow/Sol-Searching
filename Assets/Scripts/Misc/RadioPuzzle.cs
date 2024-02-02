using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RadioPuzzle : MonoBehaviour
{
    public Animator animator;
    public int counter;
    public GameObject PlayerKeyPrompt;
    public bool PlayerInRange;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        PlayerKeyPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
            // Check if the player is in proximity
            if (PlayerInRange)
            {
                PlayerKeyPrompt.SetActive(true);
            }
            if (PlayerInRange && Input.GetKeyDown(KeyCode.E))
            {
                AudioManager.instance.PlayOneShot(FMODEvents.instance.Dial, this.transform.position);
                counter++;
                Debug.Log(counter);
                animator.SetInteger("Count", counter);
                if (counter == 8 && Input.GetKeyDown(KeyCode.E))
                {
                    counter = 0;
                }
            }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
            PlayerKeyPrompt.SetActive(false);
        }
    }
}
