using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneInteract : MonoBehaviour
{
    public GameObject Player;
    private SaveManager saveManager;

    // Start is called before the first frame update
    void Start()
    {
       saveManager = Player.GetComponent<SaveManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(saveManager.score);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (saveManager.score != 0)
            {
                SceneManager.LoadScene("SecretRoute_A");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
