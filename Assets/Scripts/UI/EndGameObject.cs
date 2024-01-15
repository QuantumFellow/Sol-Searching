using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class EndGameObject : MonoBehaviour
{
    public GameObject WinScr;
    public GameObject Player;

    public void Start() {
        WinScr.SetActive(false); //panel not visible on start of game
        DontDestroyOnLoad(this.Player);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //if ending collides with the player
        {
            UnityEngine.Debug.Log("show win scn");
            WinScr.SetActive(true); //displays win panel
        }
    }

    public void menu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); //loads menu scene
    }

    public void restart() {
        SceneManager.LoadScene("Game"); //restarts game
    
    }

}