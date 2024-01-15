using JetBrains.Annotations;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    public float scrollSensitivity = 1.0f;

    //frames for speed (works on scroll input per 5 frames)
    public int framesToAverage = 5;

    private float[] scrollSpeedSamples;
    private int currentFrame = 0;
    public static float ScrollSpeed;

    private void Start()
    {
        //array for frames
        scrollSpeedSamples = new float[framesToAverage];
    }

    private void Update()
    {
        //scrll val
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        //scrolls per second
        float scrollSpeed = scrollInput / Time.deltaTime;

        //array holds that value
        scrollSpeedSamples[currentFrame % framesToAverage] = scrollSpeed;
        currentFrame++;

        //uses the scroll speed array divides by frame rate to get accurate average of scrolls
        float averageScrollSpeed = CalculateAverageScrollSpeed();

        if (scrollInput > 0f)
        {
            Debug.Log("Scrolling UP");
            Debug.Log("Scroll Speed: " + averageScrollSpeed);
        }
        else if (scrollInput < 0f)
        {
            Debug.Log("Scrolling DOWN");
            Debug.Log("Scroll Speed: " + averageScrollSpeed);
        }
        //sends to ScrollSpeed variable which can be accessed from other scripts e.g scalable platform 
        ScrollSpeed = averageScrollSpeed;


    }

    private float CalculateAverageScrollSpeed()
    {
        float sum = 0f;
        int count = Mathf.Min(currentFrame, framesToAverage);

        for (int i = 0; i < count; i++)
        {
            sum += scrollSpeedSamples[i];
        }

        return count > 0 ? sum / count : 0f;
    }
}
