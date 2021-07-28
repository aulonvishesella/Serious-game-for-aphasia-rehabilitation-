using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    <summary>
       This class is used to know when to listen to what the user is saying (when the objective begins)
        as well as what we should expect the user to say( based on the object name provided)
    </summary>
*/

public class SpeechManager : MonoBehaviour
{
    
    private bool canListen=false;
    private string objectName="";
    private string textFromSpeech ="";

    
    void Update(){
        if(canListen){
            ListenToSpeech(objectName);
        } 
    }

    public void ListenToSpeech(string objectName){
        this.objectName=objectName;
        textFromSpeech = FindObjectOfType<ExampleStreaming>().GetUserSpeech(); //use IBM's speech to text API to extract text from what the user has said
        canListen=true;
        if(textFromSpeech.Trim().Equals(objectName)){ //if the text matches the object name, then the user has correctly names the object.
            ObjectNamed();
            canListen=false;
        }
    }

    public void StopListening(){
        canListen=false;
    }

    //function called when the user has correctly named the object.
    private void ObjectNamed(){
        FindObjectOfType<ScoreSystem>().UpdateScore(10);
        FindObjectOfType<ObjectiveManager>().EndObjective(); //objective complete
        FindObjectOfType<AudioManager>().Play("cheering"); //congratulate the user
    }
}
