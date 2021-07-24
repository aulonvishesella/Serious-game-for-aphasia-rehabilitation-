using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; 
using System.Security.Cryptography;

/*
    <summary>
        This class is used when we wish to save player current progress as well as load a players saved progress.
    </summary>

*/

public static class SaveSystem
{
    
    //this key will be used for both encrypting data being written and decrypting data being read.
    public static byte[] savedKey;

    public static PlayerData LoadPlayer()
    {
        string saveFile = Application.persistentDataPath + "/player.json";

    
       
        FileStream dataStream;  // FileStream used for reading file.      
        //check if a file exists given the path.
        if (File.Exists(saveFile))
        {
            
            dataStream = new FileStream(saveFile, FileMode.Open); // Create FileStream for opening files.

            
            Aes aes = Aes.Create();

            byte[] outputIV = new byte[aes.IV.Length];
            
            dataStream.Read(outputIV, 0, outputIV.Length);

            // Create CryptoStream in read mode, wrapping FileStream
            CryptoStream cryptoStream = new CryptoStream(
                   dataStream,
                   aes.CreateDecryptor(savedKey, outputIV),
                   CryptoStreamMode.Read);

            // Create a StreamReader, wrapping CryptoStream, which will be used to read encrypted data
            StreamReader reader = new StreamReader(cryptoStream);
            
           
            string text = reader.ReadToEnd();
            
            // Deserialize the JSON data into a pattern matching the PlayerData class and return this.
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(text); 
            return playerData;
            
        }
        else{
            Debug.LogError("Save not found");
            return null;
        }
    }

    public static void SavePlayer(Player player)
    {
       string saveFile = Application.persistentDataPath + "/player.json";
       
        PlayerData playerData = new PlayerData(player);
        
        FileStream dataStream; // FileStream used for writing file. 

        Aes aes = Aes.Create();
        
        savedKey = aes.Key; // Update the internal key. This will be used also for decryption.
        
        dataStream = new FileStream(saveFile, FileMode.Create);  // Create a FileStream for creating files.
        
        byte[] inputIV = aes.IV; //generate an IV
        
        dataStream.Write(inputIV, 0, inputIV.Length); // Write generated IV to the filestream

        // create a CryptoStream in write mode, wrapping FileStream.
        CryptoStream cryptoStream = new CryptoStream(
                dataStream,
                aes.CreateEncryptor(aes.Key, aes.IV),
                CryptoStreamMode.Write);

       
        StreamWriter sWriter = new StreamWriter(cryptoStream);  // Create StreamWriter to write contents into our cryptostream


        string jsonString = JsonUtility.ToJson(playerData);  // Serialize the object into JSON format, save as a string.
        
        sWriter.Write(jsonString); // write string into stream, which will be encrypted. 

        sWriter.Close();
        cryptoStream.Close();
        dataStream.Close();
    }

public static void DeleteFile(){
       File.Delete(Application.persistentDataPath + "/player.json");
    }


