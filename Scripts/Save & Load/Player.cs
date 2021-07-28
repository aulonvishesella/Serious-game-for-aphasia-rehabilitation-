using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
   

   public int currentScore;
   public int currentLevel;
   

   //function called to save the current score and the level
   public void SavePlayer(){   
       
      currentScore = FindObjectOfType<ScoreSystem>().GetScore();
      currentLevel = SceneManager.GetActiveScene().buildIndex;
      SaveSystem.SavePlayer(this);
      //SaveSystem.Save(this);

   }

}