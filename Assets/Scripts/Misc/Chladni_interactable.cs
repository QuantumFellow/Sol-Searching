using UnityEngine;

public class Chladni_interactable : MonoBehaviour
{
    public Sprite[] sprites;
    public PolygonCollider2D[] colliders;
    public float scrollSpeed = 0.1f;

    private SpriteRenderer spriteRenderer;
    private int currentContentIndex = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (sprites.Length > 0)
        {
            spriteRenderer.sprite = sprites[currentContentIndex];
        }
    }

    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0) // Scrolling upwards
        {
            ChangeContent(true);
        }
        else if (scrollInput < 0) // Scrolling downwards
        {
            ChangeContent(false);
        }
    }

    void ChangeContent(bool forward)
    {
        // Change the content (sprite and collider)
        if (forward)
        {
            currentContentIndex = (currentContentIndex + 1) % sprites.Length;
        }
        else
        {
            currentContentIndex = (currentContentIndex - 1 + sprites.Length) % sprites.Length;
        }

        spriteRenderer.sprite = sprites[currentContentIndex];
        ToggleCollider(currentContentIndex);
    }

    void ToggleCollider(int index)
    {
        // Disable all colliders first
        foreach (PolygonCollider2D collider in colliders)
        {
            collider.enabled = false;
        }

        // Enable the corresponding collider
        if (index >= 0 && index < colliders.Length)
        {
            colliders[index].enabled = true;
        }
    }
}


