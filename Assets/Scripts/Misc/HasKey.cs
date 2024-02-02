using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HasKey : MonoBehaviour
{

    public bool WithinRange;
    public GameObject PlayerKeyPrompt;
    public Animator AnimatorTollBooth;
    public GameObject InkUnder;
    PlatformController platformController;


    // Start is called before the first frame update
    void Start()
    {
        platformController = InkUnder.GetComponent<PlatformController>();
        PlayerKeyPrompt.SetActive(false);
        platformController.proximityDistance = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(saveManager.score);
        if (WithinRange)
        {
            PlayerKeyPrompt.SetActive(true);
        }
        if (WithinRange && Input.GetKeyDown(KeyCode.E)) 
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.TuningForkUp, this.transform.position);
            Debug.Log("Playing");
            AnimatorTollBooth.SetInteger("HasKey", 1);
            platformController.proximityDistance = 5f;

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
