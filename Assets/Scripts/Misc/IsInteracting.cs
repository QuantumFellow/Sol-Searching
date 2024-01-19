using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInteracting : MonoBehaviour
{
    public LayerMask Pierce;
    public bool isPierced;
    public Transform PiercingCheck;

    private SpriteRenderer spriteRenderer;
    public Sprite piercedSprite;  // Assign the pierced sprite in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        // Get the SpriteRenderer component attached to the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isPierced = Physics2D.OverlapCircle(PiercingCheck.position, 0.5f, Pierce);
        Debug.Log(isPierced);

        // Check if the object is pierced
        if (isPierced)
        {
            // Change the sprite to the pierced sprite
            if (piercedSprite != null)
            {
                spriteRenderer.sprite = piercedSprite;
            }

            // You can add additional logic or actions here when the object is pierced
        }
    }
}
