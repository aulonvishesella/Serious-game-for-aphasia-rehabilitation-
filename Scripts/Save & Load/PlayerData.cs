using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int currentScore;
    public int currentLevel;
    public float[] position;
   
    //constructor which denotes the player data; current score, current level and current position of the avatar
    public PlayerData(Player player){
        currentScore = player.currentScore;
        currentLevel = player.currentLevel;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        
    }
}
