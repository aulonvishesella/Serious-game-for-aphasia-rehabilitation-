using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
	<summary>
		There are NPCs (Non Player Characters) in the world that the avatar in the game collides with in order to practice naming an object. 
		
		The tag of a particular NPC denotes the name of the object the user has to try say

		In order to start the objective of naming a particular object, first have to check if there exists an object when given the tag of the NPC. If so,
		we start the objective(like starting a quest) with the name of the NPC and tag of NPC passed on as parameters.

		For example, if an NPC in the map is named Character1 and has a tag called 'bench', then it will check to see if there exists 
		a bench on the map. If so, then the objective starts where the user will attempt to name the object (in this case bench).
	</summary>
*/


public class CollisionDetection : MonoBehaviour
{

	private string collidingNPCTag;
	private string collidingNPCName;

     void OnControllerColliderHit(ControllerColliderHit hit)
    {	
    	if(hit.collider.name!="Terrain"){ 
			collidingNPCTag = hit.collider.tag;
			collidingNPCName = hit.collider.name;
			if(GameObject.Find(collidingNPCTag)){
				ObjectiveManager objectiveManager = new ObjectiveManager(collidingNPCName,collidingNPCTag);
				objectiveManager.StartObjective();
			}																
		}
    }
}

