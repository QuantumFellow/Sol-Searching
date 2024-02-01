using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ViewClue : MonoBehaviour
{
    public bool PlayerInRange;
    public GameObject PlayerKeyPrompt;
    public GameObject Clue;
    private bool IsClueActive;

    // Start is called before the first frame update
    void Start()
    {
        PlayerKeyPrompt.SetActive(false);
        Clue.SetActive(false);
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
            if (!IsClueActive)
            {
                Clue.SetActive(true);
            }
            else if (IsClueActive)
            {
                Clue.SetActive(false);
            }
            PlayerKeyPrompt.SetActive(false);
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
            Clue.SetActive(false);
        }
    }
}
