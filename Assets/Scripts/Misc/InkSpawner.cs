using System.Collections;
using UnityEngine;

public class InkSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // Reference to the prefab you want to spawn
    public int numberOfPrefabs = 4;   // Number of prefabs to spawn
    public float spawnInterval = 1f;  // Time interval between spawns
    public Transform bulletPos;

    public LayerMask Pierce;
    private bool isPierced;
    public Transform PiercingCheck;
    public Animator animator;

    private Coroutine spawningCoroutine;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        isPierced = Physics2D.OverlapCircle(PiercingCheck.position, 0.5f, Pierce);

        if (isPierced && spawningCoroutine == null)
        {
            animator.SetBool("Piercing", true);
            Debug.Log("Collided");
            AudioManager.instance.PlayOneShot(FMODEvents.instance.PipeHit, this.transform.position);
            spawningCoroutine = StartCoroutine(SpawnPrefabsWithInterval());
        }
        //else if (!isPierced && spawningCoroutine != null)
        //{
            //Debug.Log("Not Collided");
            //StopCoroutine(spawningCoroutine);
            //spawningCoroutine = null;
        //}
    }

    IEnumerator SpawnPrefabsWithInterval()
    {
        while (numberOfPrefabs > 0)
        {
            Instantiate(prefabToSpawn, bulletPos.transform.position, Quaternion.identity);
            numberOfPrefabs--;

            // Wait for the specified interval before spawning the next prefab
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}



