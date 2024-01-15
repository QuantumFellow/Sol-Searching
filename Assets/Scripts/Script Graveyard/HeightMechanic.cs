using UnityEngine;

public class HeightMechanic : MonoBehaviour
{
    // Adjust these values based on your game's requirements
    public float minHeight = 1.0f;
    public float maxHeight = 5.0f;
    public float movementSpeed = 5.0f;
    public float tiltSpeed = 2.0f;
    public float maxTiltAngle = 30.0f; // Maximum tilt angle

    private float currentHeight = 1.0f;

    void Update()
    {
        HandleMouseInput();
        HandleBalance();
    }

    public void CollectItemAndGrow(float heightContribution)
    {
        // Increase the player's height
        currentHeight += heightContribution;

        // Clamp the height within the specified limits
        currentHeight = Mathf.Clamp(currentHeight, minHeight, maxHeight);

        // Update the player's scale based on the new height
        transform.localScale = new Vector3(1.0f, currentHeight, 1.0f);
    }

    private void HandleMouseInput()
    {
        // Handle mouse button input for forward and backward movement
        if (Input.GetMouseButton(0)) // Left mouse button
        {
            MoveForward();
        }
        else if (Input.GetMouseButton(1)) // Right mouse button
        {
            MoveBackward();
        }
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
    }

    private void MoveBackward()
    {
        transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
    }

    private void HandleBalance()
    {
        // Handle A and D keys for balancing
        float horizontalInput = Input.GetAxis("Horizontal");
        float tiltAngle = horizontalInput * tiltSpeed;

        // Clamp the tilt angle to avoid excessive tilting
        tiltAngle = Mathf.Clamp(tiltAngle, -maxTiltAngle, maxTiltAngle);

        // Apply tilt rotation
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, tiltAngle);
    }
}
