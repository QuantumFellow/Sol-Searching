using UnityEngine;

public class PlatformSpawnPoint : MonoBehaviour
{
    public GameObject scalablePlatformPrefab;
    public GameObject anotherPlatformPrefab; // Add another platform prefab reference
    public GameObject player;
    public float spawnRange = 10f;
    public float despawnDelay = 5f;

    private GameObject spawnedPlatform;
    private bool isPlayerInRange;


    void Update()
    {
        //Checks for player in range and exists
        if (player != null && Vector3.Distance(transform.position, player.transform.position) <= spawnRange)
        {
            //LMB held
            bool isLeftMouseButtonDown = Input.GetMouseButton(0);

            //is scrolling
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");

            //checks for pattern 1 (Held Platform)
            if (isLeftMouseButtonDown && scrollInput < 0f)
            {
                SpawnPlatform(scalablePlatformPrefab);
            }
            //Checks for pattern 2 (Boost platform)
            else if (!isLeftMouseButtonDown && scrollInput < 0f)
            {
                SpawnPlatform(anotherPlatformPrefab);
            }

            //Reset timer
            isPlayerInRange = true;
        }
        else
        {
            //Player out of range
            if (isPlayerInRange)
            {
                //If player is out of range for long enough platform despawns
                StartCoroutine(CheckDelayedDespawn());
                isPlayerInRange = false;
            }
        }
    }

    void SpawnPlatform(GameObject platformPrefab)
    {
        //1st prefab despawned before spawning another
        DespawnPlatform();

        //spawns platform @ spawnpoint
        spawnedPlatform = Instantiate(platformPrefab, transform.position, transform.rotation);

        //finds player again
        spawnedPlatform.GetComponent<ScalablePlatform>().FindPlayer();
    }

    System.Collections.IEnumerator CheckDelayedDespawn()
    {
        float timer = 0f;

        while (timer < despawnDelay)
        {
            //Player in range
            if (Vector3.Distance(transform.position, player.transform.position) <= spawnRange)
            {
                yield break; // Player is back in range, stop the coroutine
            }

            timer += Time.deltaTime;
            yield return null;
        }

        //If player has gone out of range and platform is original size
        DespawnPlatform();
    }

    void DespawnPlatform()
    {
        // Despawns platform
        if (spawnedPlatform != null)
        {
            Destroy(spawnedPlatform);
        }
    }
}






