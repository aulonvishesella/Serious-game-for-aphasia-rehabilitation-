using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
    <summary>
        This class is aimed at controlling all the audio that occurs when the game is being played, for instance, playing the audio clips that match
        the dialogue conversation between a particular NPC and the avatar. 
    </summary>
*/

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioModel[] audios;
    
    void Awake()
    {
        for (int i = 0; i < audios.Length; i++)
        {
            AudioModel a = audios[i];
            a.audioS = gameObject.AddComponent<AudioSource>();
            a.audioS.clip = a.audioC;
        }
    }

    //function to play a particular audio from an array of stored audios
    public void Play(string audioName)
    {
        for (int i = 0; i < audios.Length; i++)
        {

            //if a stored audio name is equal to the argument provided, we play that particular audio.
            if (audios[i].nameOfAudio == audioName)
            {
                AudioModel a = audios[i];
                a.audioS.Play();
            }
        }
    }

    //function to stop a particular audio from an array of audios
    public void Stop(string audioName)
    {
        //search through the list of audios stored.
        for (int i = 0; i < audios.Length; i++)
        {
           //if a stored audio name is equal to the argument provided, we mute that particular audio.
            if (audios[i].nameOfAudio == audioName)
            {
                AudioModel s = audios[i];
                s.audioS.Stop();
            }

        }

    }
}
