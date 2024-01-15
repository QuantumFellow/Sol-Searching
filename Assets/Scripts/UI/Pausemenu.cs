using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausemenu : MonoBehaviour
{
    public static bool IsPaused = false; //just so it pauses then unpauses
    public GameObject pauseMenuUI; 
    public GameObject savecon;

    void Start() {
        pauseMenuUI.SetActive(false); //gameobject not visible
        savecon.SetActive(false); //text to let you know youve saved (save confirmation)
    }
    


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) { //when esc. pressed
            if (IsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume () {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Pause () {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //freezes any movement in game
        IsPaused = true;
    }

    public void QuitGame() {
        Debug.Log ("QUIT"); //check
        Application.Quit(); //quits built game
    }

    public void menu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); //takes player to menu scene
    }

}
