using UnityEngine;

public class ScalablePlatform : MonoBehaviour
{
    // Adjust this value to set the sensitivity of the scroll input
    public float scrollSensitivity = 1.0f;
    public float ForceVal = 1f;

    // Set the minimum and maximum scale values for the platform
    public Vector3 minScale = new Vector3(1f, 1f, 1f);
    public Vector3 maxScale = new Vector3(5f, 5f, 5f);

    // Adjust this value to control the smoothness of the scaling
    public float smoothness = 0.1f;

    // Reference to the player's Rigidbody
    public Rigidbody2D playerRigidbody;

    private void Update()
    {
        // Get the scroll input value
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Calculate the target scale change based on the scroll input
        Vector3 targetScaleChange = new Vector3(1f, 1f, 1f) + scrollInput * scrollSensitivity * Vector3.one;

        // Smoothly interpolate towards the target scale change
        Vector3 scaleChange = Vector3.Lerp(Vector3.one, targetScaleChange, smoothness);

        // Apply the scale change within the specified limits
        Vector3 newScale = Vector3.Scale(transform.localScale, scaleChange);
        newScale = ClampScale(newScale, minScale, maxScale);

        // Apply the new scale to the platform
        transform.localScale = newScale;

        // Calculate the vertical force to launch the player up
        float verticalForce = Mathf.Max(0f, scrollInput) * scrollSensitivity * ForceVal;

        // Apply the force to the player's Rigidbody
        if (playerRigidbody != null)
        {
            playerRigidbody.AddForce(Vector2.up * verticalForce, ForceMode2D.Impulse);
        }
    }

    private Vector3 ClampScale(Vector3 scale, Vector3 min, Vector3 max)
    {
        scale.x = Mathf.Clamp(scale.x, min.x, max.x);
        scale.y = Mathf.Clamp(scale.y, min.y, max.y);
        scale.z = Mathf.Clamp(scale.z, min.z, max.z);
        return scale;
    }
}

