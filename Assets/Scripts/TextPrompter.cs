using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class TextPrompter : MonoBehaviour
{
    public GameObject DialoguePanel;
    public TMP_Text DialogueText;
    public string[] dialogue;
    private int Index;
    public GameObject PlayerKeyPrompt;

    public float WordSpeed;
    public bool PlayerInRange;
    public bool CanStartAgain = true;

    // Start is called before the first frame update
    void Start()
    {
        PlayerKeyPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange)
        {
            PlayerKeyPrompt.SetActive(true);
        }
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && CanStartAgain == true)
        {
            CanStartAgain = false;
            PlayerKeyPrompt.SetActive(false);
            if (DialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                DialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }


        if (DialogueText.text == dialogue[Index])
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                NextLine();
            }
        }
    }

    public void zeroText()
    {
        DialogueText.text = "";
        Index = 0;
        DialoguePanel.SetActive(false);
        CanStartAgain = true;
    }

    IEnumerator Typing()
    {
        foreach(char letter  in dialogue[Index].ToCharArray())
        {
            DialogueText.text += letter;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.WellInteract, this.transform.position);
            yield return new WaitForSeconds(WordSpeed);

        }
    }

    public void NextLine()
    {

        if (Index < dialogue.Length - 1)
        {
            Index++;
            DialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
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
            zeroText();
        }
    }

    
}
