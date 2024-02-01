using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health; //for later use to save hearts etc (not enough time to implement)
    public int level; //saves level for later use
    public float[] position;
    public PlayerData(LevelSaveManager player)
    {
        level = player.level;
        health = player.health;

        position = new float[3]; //creates the array for the position of the player
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }

}
