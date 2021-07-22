using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
/*
    <summary>
        This class is used to handle functionalities that make up a main menu.
        When the user loads up the application and enters the main menu, they can:
            -> Start a new game from a particular level
            -> Load saved progress
            -> Visit the Controls menu
            -> Quit the application
    </summary>
*/



public class MainMenu : MonoBehaviour
{
   
   public GameObject mainMenu;
   public GameObject warningPrompt;
   public GameObject overridePrompt;
   private bool saveExist=false;
   private bool overridePressed=false;

   void Start(){
      CheckIfSaveExists();
   }

   private void CheckIfSaveExists(){
      string path  = Application.persistentDataPath + "/player.data";
      if(File.Exists(path)){
         saveExist=true;
         Debug.Log(saveExist);
      }
      else{
         saveExist=false;
         Debug.Log(saveExist);
      }

   }


   public void NewGame(int chosenLevel){
      if(saveExist){
         overridePressed = EditorUtility.DisplayDialog("Warning ", "You are starting a new game which will override your last progress. Do you want to continue?"
            , "YES","NO");
         if(overridePressed){
            mainMenu.gameObject.SetActive(false);
            FindObjectOfType<SceneLoader>().LoadScene(chosenLevel);
            SaveSystem.DeleteFile();
         }
      }
      else{
         mainMenu.gameObject.SetActive(false);
         FindObjectOfType<SceneLoader>().LoadScene(chosenLevel);
      }
   }
   
   public void LoadGame(){
      if(saveExist){
         PlayerData data = SaveSystem.LoadPlayer();
         int savedLevel = data.currentLevel;
         mainMenu.gameObject.SetActive(false);
         FindObjectOfType<SceneLoader>().LoadScene(savedLevel);
      }
      else{
         EditorUtility.DisplayDialog("Error ", "No Save File Exists", "OK");  
      }
   }  

   public void GoControls(int sceneIndex){
      mainMenu.gameObject.SetActive(false);
      FindObjectOfType<SceneLoader>().LoadScene(sceneIndex);
   }
 
  public void QuitGame(){
     Application.Quit();
  }
  
 

}