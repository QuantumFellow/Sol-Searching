using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSaveManager : MonoBehaviour
{
    //SAVINGGAME
    public int health = 3;
    public int level = 1;


    public void SavePLayer()
    {
        SaveSystem.SavePLayer(this); //writes vector to the file on savesystem
        Debug.Log("Saved"); //test
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer(); //loads player back to save point
        level = data.level;
        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        Debug.Log("Loaded");
        transform.position = position; //transforms player to saved vector
    }
}
