using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Animator animator;
    public GameObject PlayerKeyPrompt;
    private bool WithinRange;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetInteger("IsOpen", 0);
        PlayerKeyPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (WithinRange && Input.GetKeyDown(KeyCode.E))
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.Door, this.transform.position);
            Debug.Log("Loading Scene");
            SceneManager.LoadScene("Ending1");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetInteger("IsOpen", 1);
            PlayerKeyPrompt.SetActive(true);
            WithinRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetInteger("IsOpen", 0);
            PlayerKeyPrompt.SetActive(false);
        }
    }


}
