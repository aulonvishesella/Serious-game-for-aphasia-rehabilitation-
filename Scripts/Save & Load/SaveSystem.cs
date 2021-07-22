using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; 

/*
    <summary>
        This class is used when we wish to save player current progress as well as load a players saved progress.
    </summary>

*/


public static class SaveSystem
{

    //function to save the players current progress (their current score & level)
    public static void SavePlayer(Player player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path  = Application.persistentDataPath + "/player.data"; //path to where our file will be saved
        FileStream stream = new FileStream(path,FileMode.Create); //created our file in our system and ready to write to it
        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream,data); //write the player data to our file
        stream.Close();
    }

    //function to load the players saved progress
    public static PlayerData LoadPlayer(){
         string path  = Application.persistentDataPath + "/player.data";
         if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open); //provide a stream to our saved file and open that existing saved file
            PlayerData data = formatter.Deserialize(stream) as PlayerData; // turn the data from binary to readable format and store it in our PlayerData instance 
            stream.Close();
            return data;

         }
         else{
             Debug.LogError("Save not found");
             return null;
         }
    }
    //function to the delete a file saved in that path
    public static void DeleteFile(){
       File.Delete(Application.persistentDataPath + "/player.data");
    }
}
