using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

/*
    <summary>
        The purpose of this class is to load the score and avatar position appropriately for a chosen level.
        If the level chosen was from a saved level, it will load the position and score based on what was saved.
    </summary>

*/

public class GameLoader : MonoBehaviour
{

    [SerializeField]
    private GameObject avatar;
     
    void Start(){
        string path  = Application.persistentDataPath + "/player.json";
        //check if a file exists in the path provided
        if(File.Exists(path)){
            PlayerData data = SaveSystem.LoadPlayer();
            //PlayerData data = SaveSystem.Load();
            int savedLevel = data.currentLevel;
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            //if the current level is the level currently saved, then load the score of that level and the players last position
            if(savedLevel==currentScene){
                LoadScore(data);
                LoadPosition(data);
            }
        }
        //Ensure the game is not paused when the level is loaded
        FindObjectOfType<PauseMenu>().Resume();
        avatar.GetComponent<CharacterController>().enabled=true;


    }
   
   //update score to the last saved score 
   private void LoadScore(PlayerData data){
       int savedScore = data.currentScore;
       FindObjectOfType<ScoreSystem>().SetScore(savedScore);
   }

   //update player position to the saved player position 
   private void LoadPosition(PlayerData data){
        avatar.transform.position = new Vector3(data.position[0],data.position[1],data.position[2]);
        
   }

}
