using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is passed into our dialogue controller when we want to start a new dialogue
//it will host all the information we need for a single dialogue

//mark it as serializable so we can edit it in the inspector
 [System.Serializable]
public class DialogueModel
{
  //our dialogue will have the name of the objective the user is attempting as well as an array of sentences
  public string tagOfNPC; 

  [TextArea(3,10)]
  public string[] sentence;

}
