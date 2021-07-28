using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

/*
    <summary>
        This class deals with loading scenes in the game. This class also ensures a loading screen is presented to the user whilst Unity is loading 
        the scene asynchronously in the background.
    </summary>
*/

public class SceneLoader : MonoBehaviour
{
    public Slider slider; 
    public Text progressText;
    public GameObject loadingScreen;
  

    public void LoadScene(int sceneIndex){
        StartCoroutine(LoadAsynchronously(sceneIndex)); 
    }

    
  //function called when we wish to load a particular scene asynchronously 
  IEnumerator LoadAsynchronously(int sceneIndex){
     AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex); // retrieve information back about the progress of loading a particular scene
       
     loadingScreen.gameObject.SetActive(true);
     //while the operation of loading the scene is still running
     while(!operation.isDone){
        float progress = Mathf.Clamp01(operation.progress / .9f);
        slider.value=progress; //set the value of the slider to the value of the progress of how much of the scene has been loaded
        
        progressText.text = progress * 100f + "%"; //progress value is from 0-1 therefore multiply by 100 to set progressText as a percentage
        yield return null;
     }

  }
}
