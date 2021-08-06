using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    /*
        <summary>
            This class is aimed at ensuring all NPCs in the map have an arrow above their head, in order for the user to easily locate
            the NPCs on the map
        </summary>

    */
 

public class WaypointController : MonoBehaviour
{
    
    public WaypointModel[] pointers;
    
    void Update()
    
    {
        for(int i=0;i<pointers.Length;i++){
                
            Vector3 offset = new Vector3(0,4,0);  
            Image img = pointers[i].img;
            Transform target = pointers[i].target;
            img.enabled=true;

            
            //We do not want the marker (the arrow) to go offscreen. Therefore,we create limitation variables:
            float minX = img.GetPixelAdjustedRect().width/2;
            float maxX = Screen.width - minX;
            float minY = img.GetPixelAdjustedRect().height/2;
            float maxY = Screen.height - minX;

        
            Vector2 pos  = Camera.main.WorldToScreenPoint(target.position + offset);
            
            if(Vector3.Dot((target.position-transform.position),transform.forward) <0){ //ensure camera looks at player when we rotate 
            
                if(pos.x<Screen.width/2){ //if the waypoint arrow is in the left side of the screen, we reverse it and place it on the right side
                    pos.x=maxX;
                }
    
                else{ //else if right side of the screen, we reverse it and stick it on the left side
                    pos.x=minX;
                }
            }

            //limit the position so that the waypoint marker does not go offscreen using the limitation varaiables(calculated above)
            pos.x = Mathf.Clamp(pos.x,minX,maxX);
            pos.y = Mathf.Clamp(pos.y,minY,maxY);
            img.transform.position=pos;
        }        
    }

}
