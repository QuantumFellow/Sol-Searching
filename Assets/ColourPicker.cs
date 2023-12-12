using UnityEngine;

public class ColourPicker : MonoBehaviour
{
    public Camera captureCamera;

    void Update()
    {
        // Get the mouse position
        Vector3 mousePosition = Input.mousePosition;

        // Create a ray from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        // Perform a raycast
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Get the UV coordinate of the hit point
            Vector2 uv = hit.textureCoord;

            // Read the color from the Shader Graph using a Render Texture
            Color pickedColor = GetShaderGraphColor(uv);

            // Output the color information
            Debug.Log("Hovered color: " + pickedColor);
        }
    }

    // Helper method to get the color from the Shader Graph using a Render Texture
    private Color GetShaderGraphColor(Vector2 uv)
    {
        // Set up the camera for rendering to a Render Texture
        captureCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        RenderTexture renderTexture = captureCamera.targetTexture;
        captureCamera.Render();

        // Read the color from the Render Texture
        RenderTexture.active = renderTexture;
        Texture2D tex = new Texture2D(Screen.width, Screen.height);
        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        tex.Apply();

        // Clean up
        RenderTexture.active = null;
        captureCamera.targetTexture = null;

        // Return the picked color
        return tex.GetPixel((int)(uv.x * Screen.width), (int)(uv.y * Screen.height));
    }
}





