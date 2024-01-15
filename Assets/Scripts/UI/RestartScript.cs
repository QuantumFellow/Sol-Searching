using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public void Restart() {
        SceneManager.LoadScene("Game");
    }
//this one is reasonably self explanatory
    public void ExitButton() {
        SceneManager.LoadScene("Menu");
    }

}
