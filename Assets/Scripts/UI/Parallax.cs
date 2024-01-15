using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam; //for virtual camera
    public float parallax;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;     
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (cam.transform.position.x * parallax); //object moves to cam's position * the parallax desired

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
        
    }
}
