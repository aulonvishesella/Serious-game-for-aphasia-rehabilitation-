using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	<summary>
        This class is aimed at controlling avatar movement & appropiate animations (idle,walking and walking backwards) of the avatar played.
	</summary>
*/

public class AvatarController : MonoBehaviour
{
    //variables
    private float rotatePlayer = 0;
    private Vector3 directionMoved = Vector3.zero;
    public bool canMove = true;

    //references
    CharacterController characterController;
    Animator animationPlayer;
    Rigidbody characterBody;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animationPlayer = GetComponent<Animator>();
        characterBody = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(canMove){ //if the player is allowed to move
       
            if (Input.GetKey(KeyCode.W))
            {
                animationPlayer.SetBool("isWalking", true); //animation of player changes from idle to walking
                directionMoved = new Vector3(0, 0, 1);
                directionMoved *= 5;
                directionMoved = transform.TransformDirection(directionMoved);
            }
            else
            {
                animationPlayer.SetBool("isWalking", false); //animation of player changes to idle
                directionMoved = new Vector3(0, 0, 0);
            }
        

            directionMoved.y -= 2 * Time.deltaTime; //every frame we will move our player on the Y-Axis by 2
            characterController.Move(directionMoved * Time.deltaTime);
            PermitRotation();

        }
        
    }
    //function called when the user aims to rotate avatar
    private void PermitRotation()
    {
        rotatePlayer += Input.GetAxis("Horizontal") * 80 * Time.deltaTime; //rotate the player each time we press the horizontal keys (A and D OR left and right arrow)
        transform.eulerAngles = new Vector3(0, rotatePlayer, 0); //apply the rotation change to our player
    }

    public void DisableAvatarMovement(){
        canMove=false;
        characterBody.freezeRotation = true;
        animationPlayer.SetBool("isWalking", false); 
    }
   
   public void MoveBackwards(){
        animationPlayer.SetBool("isWalkingBackwards", true); //animation of player changes from idle to walking backwards
        Invoke("StopBackwards",1f);
   }

   private void StopBackwards(){
     animationPlayer.SetBool("isWalkingBackwards", false);
     canMove=true;
    }

}
