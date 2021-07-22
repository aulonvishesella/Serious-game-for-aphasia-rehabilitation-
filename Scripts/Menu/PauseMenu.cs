using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
    <summary>
        This class is used to control what happens when the user pauses a game.
        When the user pauses a game by pressing the key 'p', they will be presented with a menu to:
            -> resume the game
            -> return to the main menu
            -> quit the application
    </summary>
*/


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool gameIsPaused;
  
    void Update(){
         if (Input.GetKeyDown(KeyCode.P)){
             if(gameIsPaused){
                Resume();
             }
             else{
                 Pause();
             }
         }
    }

    //function called when we pause the game
    public void Pause(){
        gameIsPaused=true;
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    //function called when we resume the game
    public void Resume(){
        gameIsPaused=false;
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    //function called when we wish to return back to the main menu
    public void GoHome(int sceneIndex){
        pauseMenu.gameObject.SetActive(false); //hide the pause menu otherwise it will interfere with the loading screen 
        FindObjectOfType<SceneLoader>().LoadScene(sceneIndex); 
    }

    
    //quit application
    public void Quit(){
        Application.Quit();
    }

}
