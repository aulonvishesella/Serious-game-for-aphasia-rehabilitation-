# Dissertation :mortar_board:

# About :computer:
This project is a serious game, developed in Unity with scripts written in C#, aimed at the rehabilitation of aphasia with a focus on noun therapy.
This project was a funded research project at my university and was validated by a speech therapist to ensure it can provide desired therapeutic effects

# What I learnt :rocket:
* Using Watson IBM speech to text API to detect normal sounding audio and convert into text.
* Incremental process model - applying this model consistently throughout development, ensuring each increment was checked and tested alongside a
  speech therapist.
* Applying a design pattern - primarly focused on the `State Pattern` to manage the different animation states an avatar can have.
* Designing relevant state machines to control animation states for the avatar and NPCs(Non Player Characters).
* Creating a saving and loading system that applied symmetric encryption, encrypting PlayerData(score,level,position) when writing to a file and decrypting when reading from a file. This involved:
  * Creating an instance of `AES` to generate the shared key(used for both encryption/decryption) and an input IV when writing PlayerData to our file and an output IV when reading from our file. This is used by the CryptoStream when encrypting/decrypting data.
  * Utilised three streams that 'wrapped' the other
    * using `StreamReader` and `StreamWriter`, which reads or writes data from and to a CryptoStream
    * using `CryptoStream`, encrypting player data when writing or decrypting the encrypted data when reading
    * using `FileStream` to read/write data into the file
  * Serializing PlayerData in a JSON format using `JsonUtility.ToJson`, which would be the encrypted data written to the file stream. 
  * Deserializing the JSON data that was read from the file, into a pattern matching the PlayerData class using `JsonUtility.FromJson` (the decrypted data) 



# References :book:
The following references were presented to my speech therapist that were drawn as inspiration, to which I would feature into my game in order to achieve the desired therapeutic effects
 * Some nouns selected based on this article https://www.ncbi.nlm.nih.gov/pmc/articles/PMC5367780/
 * Some nouns selected based on this article https://honeycombspeechtherapy.com/think-it-through-thursday-what-do-people-with-aphasia-want-to-say/
 * Level design inspiration from https://openaccess.city.ac.uk/id/eprint/18025/1/Experiencing_EVA_Park_Galliers_TACCESS_FINAL.pdf




# Screenshots 📷
![image]![Uploading Screenshot 2021-07-23 at 16.15.42.png…]()




# Before you get started ⏸️
This project uses the game engine Unity and uses Unity SDK file in order to use IBM watsons speech to text API 

So:

1. Download Unity
2. You need an IBM Cloud account to generate service credentials; url and apikey.
3. Download the unity SDK file from:https://github.com/watson-developer-cloud/unity-sdk and add this inside the game asset
4. Take the script 'ExampleStreaming.cs' from the SDK file, and add this into game component.
5. Paste the service credentials you generated into the empty fields inside the inspector.


