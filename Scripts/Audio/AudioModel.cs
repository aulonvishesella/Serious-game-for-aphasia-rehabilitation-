using UnityEngine.Audio;
using UnityEngine;

//allows these attributes to be seen in the inspector
[System.Serializable] 

//attributes of an audio
public class AudioModel{

    public string nameOfAudio;
    public AudioClip audioC;

    [HideInInspector]
    public AudioSource audioS; 
    
}
