using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    <summary>
        The aim of this class is to start the objective/quest for the user to name a particular object, which involves calling relevant 
        functions from different manager classes, as well as ending the objective/quest if the user has named the object correctly or wishes to skip.
    </summary>
*/


public class ObjectiveManager : MonoBehaviour
{
    private string npcName;
    private string objName;
    [SerializeField]
    private GameObject avatar;
    
    //constructor which takes in the name of the npc the user is interacting with as well as the name of the object the user will attempt to name.
    public ObjectiveManager(string npcName, string objName){
        this.npcName=npcName;
        this.objName=objName;
    }
    

    public void StartObjective(){
        FindObjectOfType<AvatarController>().DisableAvatarMovement();
		FindObjectOfType<DialogueManager>().StartDialogue(objName,npcName);
        FindObjectOfType<AnimatorManager>().EnableAnimator(npcName);
        FindObjectOfType<CameraFocus>().FocusCamera(npcName,new Vector3(2,4,-5)); //focus on the NPC as the quest/objective is beggining
		FindObjectOfType<SpeechManager>().ListenToSpeech(objName); 
    }

    public void EndObjective(){
        FindObjectOfType<CameraFocus>().FocusCamera(avatar.name,new Vector3(0,6,-9)); //focus back on the avatar as the objective/quest is over
        FindObjectOfType<DialogueManager>().EndDialogue();
        FindObjectOfType<AvatarController>().MoveBackwards(); 
        FindObjectOfType<SpeechManager>().StopListening();
    }

}
