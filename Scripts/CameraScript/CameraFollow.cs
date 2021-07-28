using UnityEngine;
using UnityEngine.UI;

/*
   <summary>
      The main functionality of this class is to set the main camera to focus on the avatar and follow the avatar moves and rotates
   </summary>

*/

public class CameraFollow : MonoBehaviour
{
   //variables
   public Transform target;
   [SerializeField]
   private float smoothSpeed = 0.125f;
 	public Vector3 offset;

   void LateUpdate(){
   
      Rotate();
   	transform.position = target.position + offset;
   	transform.LookAt(target.position); //ensures camera looks at player when we rotate

   }


   // function to rotate the camera relative to the player rotation
   void Rotate(){
        offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal") *2.5f,Vector3.up) * offset;   
   }

   
   
   
   

  
}
