using UnityEngine;

public class ScrollWheelAnimation : MonoBehaviour
{
    public Animator animator;
    int maxFrames = 60;
    float sensitivity = 1.0f;

    void Update()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        animator.SetFloat("ScrollWheel", scrollWheel);

        // Calculate the new frame index based on scroll wheel input
        int currentFrameIndex = animator.GetInteger("FrameIndex");
        int newFrameIndex = Mathf.Clamp(currentFrameIndex + Mathf.RoundToInt(scrollWheel * sensitivity), 0, maxFrames - 1);
        animator.SetInteger("FrameIndex", newFrameIndex);
    }
}


