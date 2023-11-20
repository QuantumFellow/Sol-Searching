using UnityEngine;

public class MouseManager : MonoBehaviour
{
    // Adjust this value to set the sensitivity of the scroll input
    public float scrollSensitivity = 1.0f;

    // Number of frames to consider for calculating speed
    public int framesToAverage = 5;

    private float[] scrollSpeedSamples;
    private int currentFrame = 0;

    private void Start()
    {
        scrollSpeedSamples = new float[framesToAverage];
    }

    private void Update()
    {
        // Get the scroll input value
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Calculate scroll speed
        float scrollSpeed = scrollInput / Time.deltaTime;

        // Store the scroll speed in the array
        scrollSpeedSamples[currentFrame % framesToAverage] = scrollSpeed;
        currentFrame++;

        // Calculate the average scroll speed
        float averageScrollSpeed = CalculateAverageScrollSpeed();

        if (scrollInput > 0f)
        {
            Debug.Log("Scrolling UP");
            // Output the scroll speed
            Debug.Log("Scroll Speed: " + averageScrollSpeed);
        }
        else if (scrollInput < 0f)
        {
            Debug.Log("Scrolling DOWN");
            // Output the scroll speed
            Debug.Log("Scroll Speed: " + averageScrollSpeed);
        }


        // Use the averageScrollSpeed for your specific application (e.g., adjust camera zoom speed)
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
