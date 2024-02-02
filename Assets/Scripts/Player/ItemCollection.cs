using UnityEngine.SceneManagement;
using UnityEngine;


public class ItemCollection : MonoBehaviour
{
    public GameObject Collectible;
    public int ScoreValue = 10; // You can adjust the score value per collectible if needed
    private SaveManager saveManager;



    void Start()
    {
        
        // Find the ScoreManager in the scene
        saveManager = FindObjectOfType<SaveManager>();
        if (saveManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene.");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collected");
            Destroy(gameObject);
            AudioManager.instance.PlayOneShot(FMODEvents.instance.KeyPickUp, this.transform.position);

            // Update the score using the ScoreManager
            if (saveManager != null)
            {
                saveManager.IncreaseScore(ScoreValue);
            }
        }
    }


}
