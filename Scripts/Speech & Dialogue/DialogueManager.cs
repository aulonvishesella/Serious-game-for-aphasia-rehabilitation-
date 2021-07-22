using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
	<summary>
		
        There are NPCs (Non Player Characters) in the world that the avatar interacts with when aiming to complete an objective.
        The idea of this class is to trigger the dialogue between a particular NPC and an avatar.
    
	</summary>
*/


public class DialogueManager : MonoBehaviour
{
	//variables
	public Animator anim;
    private Queue<string> sentences;
    private string objectName;
    private string npcName;
    private int sentenceCount=0;
    private int audioCount=0;
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Button skipButton;
    [SerializeField]
	private DialogueModel[] dialogue;
    [SerializeField]
	private Text sentenceText;

     
    void Start()
    {	
    	sentenceText.text = " ";
        sentences = new Queue<string>();   
        
    }

    //function to start the dialogue with the appropiate NPC. 
    public void StartDialogue(string objectName,string npcName){
        this.objectName=objectName;
        this.npcName=npcName;
        sentences.Clear();
    	for(int i=0;i<dialogue.Length;i++){
    		if(dialogue[i].tagOfNPC == objectName){
                //loop through each sentence in our array 'dialogue' that store all the sentences, and enqueue each of those sentence to our 'sentences' queue
                foreach(string sentence in dialogue[i].sentence){
                    sentences.Enqueue(sentence);
                }   
    		}
    	}

        continueButton.gameObject.SetActive(true);
        DisplayNPCSentence();
    }

    //function is called when the user wishes to know what the next sentence is in the dialogue
    public void DisplayNPCSentence(){
        skipButton.gameObject.SetActive(true);
        sentenceCount++;
        if(sentenceCount!=2){
            string sentence = sentences.Dequeue(); //sentence variable will be assigned to the value at front of our queue 'sentences'
            StartCoroutine(TypeSentence(sentence)); 
            anim.SetBool("IsOpen",true); //open speech dialogue
            AnimateNPC(true);
            Invoke("PlayAudio",2f);
        }
            //when sentenceCount==2, we focus on the object itself. Therefore, we do not need to display the dialogue.
        else{
            anim.SetBool("IsOpen",false); 
            FocusOnObject(objectName);
            continueButton.gameObject.SetActive(false);
            skipButton.gameObject.SetActive(false);
        }   
    }

    //function invoked to type out each letter from the sentence given
     IEnumerator TypeSentence(string sentence){
        sentenceText.text="";
        foreach (char letter in sentence.ToCharArray()){
            sentenceText.text+=letter;
            yield return null;
        }
    }

    //at some point during the dialogue, we want to fixate on the object the user will try to say.
    private void FocusOnObject(string objName){
        AnimateNPC(false);
        //FindObjectOfType<CameraFocus>().FocusOnObject(objName);
        FindObjectOfType<CameraFocus>().FocusCamera(objName,new Vector3(0, 5, -5));
        Invoke("FocusBackOnNPC",4f);
    }
    //function called to transition back to focusing on the NPC after focusing on the object the user attempts to say
    private void FocusBackOnNPC(){
        //FindObjectOfType<CameraFocus>().FocusOnNPC(npcName);
        FindObjectOfType<CameraFocus>().FocusCamera(npcName,new Vector3(2, 4, -5));
        DisplayNPCSentence();
    }

    //function to play audio to match the dialogue text presented
    private void PlayAudio(){
        if(audioCount==0){
            FindObjectOfType<AudioManager>().Play(objectName + audioCount);
            audioCount++;
        }
        else if(audioCount>0 ){
            FindObjectOfType<AudioManager>().Stop(objectName + (audioCount-1)); //mute the previous audio so both audios do not clash
            FindObjectOfType<AudioManager>().Play(objectName + audioCount);
            audioCount++;
            
        }
    }

    private void AnimateNPC(bool state){
        if(state==true){
            FindObjectOfType<CharacterAnimator>().EnableAnimation();
        }
        else{
            FindObjectOfType<CharacterAnimator>().DisableAnimation();
        }
    }
    
    //function to end the NPC dialogue. This function is called either if the user correctly names the object or the user wishes to skip.
    public void EndDialogue(){
        anim.SetBool("IsOpen",false);  
        sentenceCount=0;
        audioCount=0;
        continueButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        AnimateNPC(false);
    }

}



