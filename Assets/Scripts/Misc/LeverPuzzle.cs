using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

//C4=7
//C3=0
//D3=1
//E3=2
//F3=3
//G3=4
//A3=5
//B3=6

public class LeverPuzzle : MonoBehaviour
{
    public GameObject Dial1;
    public GameObject Dial2;
    public GameObject Dial3;
    public GameObject Dial4;

    private RadioPuzzle Script1;
    private RadioPuzzle Script2;
    private RadioPuzzle Script3;
    private RadioPuzzle Script4;

    public bool PlayerInRange;
    public GameObject PlayerKeyPrompt;
    public GameObject Bridge;
    private Animator BridgeA;
    public Animator Lever;
    public GameObject NewInteraction;

    //----------------SECRET-----------
    public GameObject Secret;
    public Animator SecretA;
    public GameObject PrefabKey;
    public Transform SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        NewInteraction.SetActive(false);
        SecretA = Secret.GetComponent<Animator>();
        BridgeA = Bridge.GetComponent<Animator>();
        Script1 = Dial1.GetComponent<RadioPuzzle>();
        Script2 = Dial2.GetComponent<RadioPuzzle>();
        Script3 = Dial3.GetComponent<RadioPuzzle>();
        Script4 = Dial4.GetComponent<RadioPuzzle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange)
        {
            PlayerKeyPrompt.SetActive(true);
        }
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.Lever, this.transform.position);
            // Check if the MyScript components are found
            if (Script1 != null && Script2 != null && Script3 != null && Script4 != null)
            {
                // Access the public variable 'myNumber' for each instance
                int number1 = Script1.counter;
                int number2 = Script2.counter;
                int number3 = Script3.counter;
                int number4 = Script4.counter;

                PlayChords(number1);
                PlayChords(number2);
                PlayChords(number3);
                // Use the retrieved numbers as needed
                Debug.Log("Number from instance 1: " + number1);
                Debug.Log("Number from instance 2: " + number2);
                Debug.Log("Number from instance 3: " + number3);
                Debug.Log("Number from instance 4: " + number4);
                BridgeA.SetBool("IsRaised", false);
                Lever.SetInteger("Flipped", 1);

                if (number1 == 5 && number2 == 2 && number3 == 7) 
                {
                    Debug.Log("Correct");
                    StartCoroutine(Waiting());
                }
                if (number1 == 0 && number2 == 2 && number3 == 1 && number4 == 3)
                {
                    Debug.Log("SecretUnlocked");
                    UnlockSecret();
                }
            }
            else
            {
                Debug.LogError("MyScript component not found on one or more instances");
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

    private void PlayChords(int Number)
    {
        //C4=7
        //C3=0
        //D3=1
        //E3=2
        //F3=3
        //G3=4
        //A3=5
        //B3=6
        switch (Number)
        {
            case 0:
                AudioManager.instance.PlayOneShot(FMODEvents.instance.c3, this.transform.position);
                break;
            case 1:
                AudioManager.instance.PlayOneShot(FMODEvents.instance.d3, this.transform.position);
                break;
            case 2:
                AudioManager.instance.PlayOneShot(FMODEvents.instance.e3, this.transform.position);
                break;
            case 3:
                AudioManager.instance.PlayOneShot(FMODEvents.instance.f3, this.transform.position);
                break;
            case 4:
                AudioManager.instance.PlayOneShot(FMODEvents.instance.g3, this.transform.position);
                break;
            case 5:
                AudioManager.instance.PlayOneShot(FMODEvents.instance.a3, this.transform.position);
                break;
            case 6:
                AudioManager.instance.PlayOneShot(FMODEvents.instance.b3, this.transform.position);
                break;
            case 7:
                AudioManager.instance.PlayOneShot(FMODEvents.instance.c4, this.transform.position);
                break;
        }
    }

    private void ResetTrigger()
    {
        Lever.SetInteger("Flipped", 0);
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2f);
        BridgeA.SetBool("IsRaised", true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.BridgeRaise, this.transform.position);
        NewInteraction.SetActive(true);
    }

    private void UnlockSecret ()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.ShaftOpen, this.transform.position);
        SecretA.SetInteger("Open", 1);
        GameObject Key = Instantiate(PrefabKey, SpawnPoint.position, Quaternion.identity);
    }
}
