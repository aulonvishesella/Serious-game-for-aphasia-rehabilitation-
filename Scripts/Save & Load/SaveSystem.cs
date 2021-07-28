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






    /*
   


    //function to save the players current progress (their current score & level)
    public static void SavePlayer(Player player){
         using (Aes aes = Aes.Create())
        {
            byte[] key =
            {
                0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
            };
            aes.Key = key;

        byte[] iv = aes.IV;
        BinaryFormatter formatter = new BinaryFormatter();
        string path  = Application.persistentDataPath + "/player.data"; //path to where our file will be saved
        FileStream stream = new FileStream(path,FileMode.Create); //created our file in our system and ready to write to it
        PlayerData data = new PlayerData(player);
        byte[] encryptedData = EncryptData(data,key,iv);
        formatter.Serialize(stream,data); //write the player data to our file
        stream.Close();
        }
    }

    public static byte[] EncryptData(PlayerData data,byte[] Key,byte[] IV){
       
            byte[] encrypted = null;
            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(data);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
    }

    public static string DecryptData(byte[] cipherText, byte[] Key, byte[] IV)
        {
            
           

            // Declare the string used to hold
            // the decrypted text.
            string pData;

            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            
                            pData= srDecrypt.ReadToEnd();
                           
                        }
                    }
                }
            }

            return pData;
        }

    public static void Save(Player player){
        using (Aes aes = Aes.Create())
        {
            byte[] key =
            {
                0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
            };
            aes.Key = key;

            byte[] iv = aes.IV;
            
            ICryptoTransform encryptor = aes.CreateEncryptor(key, iv); 

        BinaryFormatter formatter = new BinaryFormatter();
        string path  = Application.persistentDataPath + "/player.data";
        using(Stream innerStream = File.Create(path))
        // 2. create a CryptoStream in write mode
        using(Stream cryptoStream = new CryptoStream(innerStream, encryptor, CryptoStreamMode.Write))
        {
             PlayerData data = new PlayerData(player);
            // 3. write to the cryptoStream
            formatter.Serialize(cryptoStream, data);
        }
        }
    }
    

    public static PlayerData Load(){
        string path  = Application.persistentDataPath + "/player.data";
        if(File.Exists(path)){
         using (Aes aes = Aes.Create())
        {
            byte[] key =
            {
                0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
            };
            aes.Key = key;

        byte[] iv = aes.IV;
        ICryptoTransform decryptor = aes.CreateDecryptor(key, iv); 
         
      
            BinaryFormatter formatter = new BinaryFormatter();
            using(Stream innerStream = File.Open(path, FileMode.Open))
            // 2. create a CryptoStream in read mode
            using(Stream cryptoStream = new CryptoStream(innerStream, decryptor, CryptoStreamMode.Read))
            {
                PlayerData data = formatter.Deserialize(cryptoStream) as PlayerData;
                // 3. read from the cryptoStream
                cryptoStream.Close();
                return data;
            }
        }
        }
        else{
             Debug.LogError("Save not found");
             return null;
        }
        
    }


    //function to load the players saved progress
    public static PlayerData LoadPlayer(){
        
         string path  = Application.persistentDataPath + "/player.data";
         if(File.Exists(path)){
             using (Aes aes = Aes.Create())
            {
                byte[] key =
                {
                    0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                    0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
                };
                aes.Key = key;
                byte[] iv = aes.IV;
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path,FileMode.Open); //provide a stream to our saved file and open that existing saved file
                byte[] encryptedData = formatter.Deserialize(stream) as byte[]; // turn the data from binary to readable format and store it in our PlayerData instance 
                string data = DecryptData(encryptedData,key,iv); 
                stream.Close();
                return data;
            }

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
    */
}
