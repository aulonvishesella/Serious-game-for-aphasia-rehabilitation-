using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    <summary>
    This class is used to simulate talking animation for the NPCs
    </summary>
*/


public class CharacterAnimator : MonoBehaviour
{
    //reference
	Animator characterAnimator;
    //variable
    public static bool animateNPC=false;
   // private bool animateNPC=false;
    


    void Start()
    {
        characterAnimator = GetComponent<Animator>();
  
    }
    
    
    void Update()
    {   
       if(animateNPC){
           characterAnimator.SetBool("canTalk", true);
            Debug.Log("Animating now...");
            Invoke("DisableAnimation",4f);
        }
        else{
           characterAnimator.SetBool("canTalk", false);
        }
    }
    

     public void EnableAnimation(){
        animateNPC=true;
        
    }

    public void DisableAnimation(){
        animateNPC=false;

    }    

}
