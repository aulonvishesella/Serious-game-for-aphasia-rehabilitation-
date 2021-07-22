using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

/*
    <summary>
        The aim is this class is to primarily present the current score to the user, get current score
        , set new score and update/increment the current score. 
    </summary>
*/


public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    private int score;

    
    void Start()
    {         
        scoreText.text = "0";
    }

    void Update(){
        scoreText.text = "$" + score;
    }
    //getter to return the current score
    public int GetScore(){
        return score;
    }
    //setter to set a new score based on the parameter passed
    public void SetScore(int scoreToSet){
        score=scoreToSet;
    }
    //function called when the user has correctly named the object.
    public void UpdateScore(int increment){
        score+=increment;
    }

}
