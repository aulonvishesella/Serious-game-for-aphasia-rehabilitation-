using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    <summary>
       As each NPC share the same animation script called CharacterAnimator, this class will disable and enable that script based on the NPC name provided.
       This class,AnimatorManager, is called when the objective/quest of the user naming an object begins. As the NPC will interact with the avatar 
       once an objective begins,we have to enable the animation class for the specific NPC that is interacting with the avatar.
    </summary>
*/

public class AnimatorManager : MonoBehaviour
{
    
    private string previousNPCName;
    private GameObject currentNPC;
    private GameObject previousNPC;
    

    public void EnableAnimator(string name){
        if(previousNPCName==null){
            previousNPCName=name;
            currentNPC = GameObject.Find(name);
            currentNPC.GetComponent<CharacterAnimator>().enabled=true;
        }
        else{
            previousNPC= GameObject.Find(previousNPCName);
            currentNPC.GetComponent<CharacterAnimator>().enabled=false;
            currentNPC = GameObject.Find(name);
            currentNPC.GetComponent<CharacterAnimator>().enabled=true;
            previousNPCName=name;
        }         
    }

   
}
