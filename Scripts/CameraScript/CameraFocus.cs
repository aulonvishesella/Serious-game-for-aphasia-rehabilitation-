using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    <summary>
        This class is aimed at changing what the camera is focusing on (based on the target set) as well as the offset coordinates between 
        target and camera.
    </summary>
*/

public class CameraFocus : MonoBehaviour
{
  
    [SerializeField]
    private GameObject mainCamera;
   

    public void FocusCamera(string focusName,Vector3 offsetCoord){
        mainCamera.GetComponent<CameraFollow>().target = GameObject.Find(focusName).transform; 
        mainCamera.GetComponent<CameraFollow>().offset = new Vector3(offsetCoord.x,offsetCoord.y,offsetCoord.z);
    }
    

}
