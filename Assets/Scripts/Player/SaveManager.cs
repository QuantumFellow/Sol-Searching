using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private int score = 0;

    public void IncreaseScore(int amount)
    {
        score += amount;
        // You can add save logic here if needed
        Debug.Log("Score: " + score);
    }
}
