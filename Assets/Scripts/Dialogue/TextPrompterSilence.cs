using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextPrompterSilence : MonoBehaviour
{
    public GameObject DialoguePanel;
    public TMP_Text DialogueText;
    public string[] dialogue;
    private int Index;
    public GameObject PlayerKeyPrompt;
    public Image PlayerImage1;
    public Image PlayerImage2;


    public float WordSpeed;
    public bool PlayerInRange;
    public bool CanStartAgain = true;

    private bool isPlayerImage1Active = true;

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
        foreach (char letter in dialogue[Index].ToCharArray())
        {
            DialogueText.text += letter;

            // Toggle between two images while typing
            TogglePlayerImage();

            AudioManager.instance.PlayOneShot(FMODEvents.instance.SilenceInteract, this.transform.position);
            yield return new WaitForSeconds(WordSpeed);
        }
    }

    void TogglePlayerImage()
    {
        if (isPlayerImage1Active)
        {
            PlayerImage1.gameObject.SetActive(true);
            PlayerImage2.gameObject.SetActive(false);
        }
        else
        {
            PlayerImage1.gameObject.SetActive(false);
            PlayerImage2.gameObject.SetActive(true);
        }

        // Toggle the flag for the next iteration
        isPlayerImage1Active = !isPlayerImage1Active;
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
