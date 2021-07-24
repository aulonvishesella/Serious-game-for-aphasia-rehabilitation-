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

    
        // FileStream used for reading and writing files.
        FileStream dataStream;      
        //check if a file exists given the path.
        if (File.Exists(saveFile))
        {
            // Create FileStream for opening files.
            dataStream = new FileStream(saveFile, FileMode.Open);

            // Create new AES instance.
            Aes aes = Aes.Create();

            // Create an array of correct size based on AES IV.
            byte[] outputIV = new byte[aes.IV.Length];
            
            // Read the IV from the file.
            dataStream.Read(outputIV, 0, outputIV.Length);

            // Create CryptoStream, wrapping FileStream
            CryptoStream oStream = new CryptoStream(
                   dataStream,
                   aes.CreateDecryptor(savedKey, outputIV),
                   CryptoStreamMode.Read);

            // Create a StreamReader, wrapping CryptoStream
            StreamReader reader = new StreamReader(oStream);
            
            // Read the entire file into a String value.
            string text = reader.ReadToEnd();

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(text);
            return playerData;
            
        }
        else{
            return null;
        }
    }

    public static void SavePlayer(Player player)
    {
       string saveFile = Application.persistentDataPath + "/player.json";
       
        PlayerData playerData = new PlayerData(player);
        FileStream dataStream;

    
        // Create new AES instance.
        Aes aes = Aes.Create();
        // Update the internal key.
        savedKey = aes.Key;

        // Create a FileStream for creating files.
        dataStream = new FileStream(saveFile, FileMode.Create);

        // Save the new generated IV.
        byte[] inputIV = aes.IV;
        
        // Write the IV to the FileStream unencrypted.
        dataStream.Write(inputIV, 0, inputIV.Length);

        // Create CryptoStream, wrapping FileStream.
        CryptoStream iStream = new CryptoStream(
                dataStream,
                aes.CreateEncryptor(aes.Key, aes.IV),
                CryptoStreamMode.Write);

        // Create StreamWriter, wrapping CryptoStream.
        StreamWriter sWriter = new StreamWriter(iStream);

        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(playerData);

        // Write to the innermost stream (which will encrypt).
        sWriter.Write(jsonString);
        sWriter.Close();
        iStream.Close();
        dataStream.Close();
    }

public static void DeleteFile(){
       File.Delete(Application.persistentDataPath + "/player.json");
    }


