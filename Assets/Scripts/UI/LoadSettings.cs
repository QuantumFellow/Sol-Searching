using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSettings : MonoBehaviour
{
    public GameObject OPTIONS = GameObject.FindWithTag("OPTIONS");
    public GameObject MAINMENU = GameObject.FindWithTag("MAINMENU");

    public void LoadOptions() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
