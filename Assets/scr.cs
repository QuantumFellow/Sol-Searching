using UnityEngine;

public class scr : MonoBehaviour
{
    public Material checkerboardMaterial; // Set the checkerboard material in the inspector

    void Start()
    {
        CreateEdgeCollider();
    }

    void CreateEdgeCollider()
    {
        // Assuming the background is represented by a SpriteRenderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            // Get the material of the sprite renderer
            Material currentMaterial = spriteRenderer.material;

            // Compare the current material with the specified checkerboard material
            if (currentMaterial == checkerboardMaterial)
            {
                // Create a simple white texture
                Texture2D whiteTexture = new Texture2D(1, 1);
                whiteTexture.SetPixel(0, 0, Color.white);
                whiteTexture.Apply();

                // Assign the white texture to the material's main texture
                checkerboardMaterial.SetTexture("_MainTex", whiteTexture);

                // Add an EdgeCollider2D component to create an edge collider
                EdgeCollider2D edgeCollider = gameObject.AddComponent<EdgeCollider2D>();

                // Customize the edge collider points based on your requirements
                // For example, you might want to use the vertices of the sprite

                // edgeCollider.points = ...;
            }
        }
    }
}

