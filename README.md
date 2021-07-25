# Dissertation :mortar_board:

# About :computer:
This project is a serious game, developed in Unity with scripts written in C#, aimed at the rehabilitation of aphasia with a focus on noun therapy. The game aims to provide a free-roaming experience, handing control to the user to undetake the objective of naming a particular object. If the user wishes to do so, they can navigate the avatar to NPC's situated around the map aided with the use of waypoints. To encapsulate a realistic game, each NPC will interact with hand gestures, audio to match the dialogue and have a particular object besides that matches the theme of the level.

For each level, the user will have 5 different objects they will attempt to name with objects chosen to represent the theme of the level. Level 1 attempts to represent a park, whilst level 2 attempts to represent a town market and finally level 3 attempts to represent a town market. 

For this project, I worked closely with academics and a speech therapist that were doing this work as part of a funded research project. 


# What I learnt :rocket:
* Using `Watson IBM Speech to Text API` service to detect and convert user speech into text format; to determine if the user has said the noun correctly. 
* Follow an `Incremental Model` consistently throughout development, ensuring each increment was presented and tested alongside a speech therapist.
* Using and designing `state machines` to capture the different animation states the main avatar and NPC's can be, subquently writing scripts to transition between these animations based on the flow of the game.
* Implementing a `Save & Load` system that utilised symmetric encryption; encrypting PlayerData(current score, current level and position of avatar) when writing to a file and decrypting when reading from a file. In order to do this, I had to:
  * Utilise three streams that 'wrapped' the other
    * using `StreamReader` and `StreamWriter`, which reads or writes data from and to a CryptoStream
    * using `CryptoStream`, encrypting player data when writing or decrypting the encrypted data when reading
    * using `FileStream` to read/write data into the file
  * Create an instance of `AES` to generate the shared key and an input IV when writing PlayerData to our file and an output IV when reading from our file. Both the shared key and IV was used by the CryptoStream when encrypting/decrypting data.
  * Serialize PlayerData in a json format using `JsonUtility.ToJson`, which would be the encrypted data written to the file stream. 
  * Deserialize the json data that was read from the file, into a pattern matching the PlayerData class using `JsonUtility.FromJson`, where this decrypted data will be used to load saved data.
* Adopting the `System.Collections.Generic` namespace to make use of certain Data Structures. For example, the Queue adopted during development to become an integral part of the games dialogue system between the NPC and Avatar.
* Using Unity's particle system to simulate visual effects like fire,smoke and other effects that would otherwise be difficulty to portray.



# References :book:
Some references were presented to my speech therapist that were drawn as inspiration. As this is a serious game, all features implemented were validated with my speech therapist or backed by references to ensure the game can provide desired therapeutic effects.

 * Nouns chosen inspired from https://www.ncbi.nlm.nih.gov/pmc/articles/PMC5367780/ and https://honeycombspeechtherapy.com/think-it-through-thursday-what-do-people-with-aphasia-want-to-say/
 * Idea to include waypoints so the user can navigate to NPC's inspired from https://www.researchgate.net/publication/221297686_Serious_Games_for_Language_Learning_How_Much_Game_How_Much_AI
 * Communication tips like not informing the user that they have said the word wrong, have NPC's interact with hand gestures in the game and to not put a time limit to say the word inspired from https://www.aphasia.org/aphasia-resources/communication-tips/
 * Ensuring the game captures real world scenarios inspired from https://openaccess.city.ac.uk/id/eprint/2860/1/Computer%20delivery%20of%20gesture%20therapy%20for%20people%20with%20severe%20aphasia.pdf
 * Inspiration to use visual references like objects in the game to support their understanding and to name the word correctly from https://www.nhs.uk/conditions/aphasia/treatment/





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


