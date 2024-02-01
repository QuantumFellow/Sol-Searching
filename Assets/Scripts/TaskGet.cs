using System.Collections;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;

public class TaskGet : MonoBehaviour
{
    public GameObject ObjectivePanel;
    public TMP_Text ObjText;
    public string[] dialogue;
    private int Index;
    private bool canInteract = true;

    public float WordSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the ObjectivePanel and ObjText references if not assigned in the inspector
        if (ObjectivePanel == null)
            ObjectivePanel = GameObject.Find("Objective Panel"); // Replace "YourObjectivePanelName" with the actual name of your objective panel game object

        if (ObjText == null)
            ObjText = ObjectivePanel.GetComponentInChildren<TMP_Text>();

        // Hide the ObjectivePanel initially
        ObjectivePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any additional logic here if needed
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[Index].ToCharArray())
        {
            ObjText.text += letter;
            yield return new WaitForSeconds(WordSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canInteract == true)
        {
            ClearText();
            StartCoroutine(Typing());
            ObjectivePanel.SetActive(true); // Show the ObjectivePanel
            canInteract = false;
        }
    }

    public void ClearText()
    {
        if (ObjText != null)
        {
            ObjText.text = string.Empty;
        }
    }
}
