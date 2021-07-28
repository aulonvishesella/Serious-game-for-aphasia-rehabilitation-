# Dissertation :mortar_board:

# Before you get started ⏸️

1. Download Unity
2. You need an IBM Cloud account to generate service credentials, url and API Key, in order to authenticate to the API.
3. This project uses Unity SDK file in order to use IBM watsons speech to text API. Download the unity SDK file from:https://github.com/watson-developer-cloud/unity-sdk and add this inside the game asset.
4. Take the script 'ExampleStreaming.cs' from the SDK file and add this into a game component.
5. Paste the service credentials you generated into the empty fields that are required by ExampleStreaming script.

# About :computer:
This project is a serious game, developed in Unity with scripts written in C#, aimed at the rehabilitation of aphasia with a focus on noun therapy. The game aims to provide a free-roaming experience, handing all control to the user to undertake any objective of naming a particular object.

For this project, I worked closely with academics and a speech therapist that were doing this work as part of a funded research project. It was pivital this project was worked alongside a speech therapist to have all requirements validated and refined to achieve the desired therapeutic effects. 

# Features 📜
* Three levels each representing a realistic theme (a park, a market, and a town).
* Five different themed objects within each level that the user can attempt to name.
* Option for the user to skip the attempt if they wish so.
* The user interacts with the NPC dedicated to that object if they wish to attempt to name the object.
* Use of waypoints to guide the user to various NPCs
* Dialogue system between the avatar and NPC when attempting to name an object. The communication will involve:
  * Text
  * Audio to match the text
  * Hand gestures from the NPC to represent a realistic interaction
* The user is congratulated when they have correctly named an object by incrementing their score and playing an 'applause' sound effect.
* Encrypted Save & Load system inplace for the game. The saved data will include:
  * The current level
  * The current score achieved for that level
  * The current position of the avatar in that level
* Option to overwrite saved data.
 
# What I learnt :rocket:
* Using `IBM Watson Speech to Text API` to produce transcripts of the users verbal input which will be used to determine if the user has named the object correctly.
* Followed an `Incremental Model` consistently throughout development, ensuring each increment was presented and tested alongside a speech therapist.
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


# References :book:
Some references were presented to my speech therapist that were drawn as inspiration. As this is a serious game, all features implemented were validated with my speech therapist or backed by references to ensure the game can provide desired therapeutic effects.

 * Noun selection inspired from https://www.ncbi.nlm.nih.gov/pmc/articles/PMC5367780/ and https://honeycombspeechtherapy.com/think-it-through-thursday-what-do-people-with-aphasia-want-to-say/
 * Idea to include waypoints so the user can navigate to NPC's inspired from https://www.researchgate.net/publication/221297686_Serious_Games_for_Language_Learning_How_Much_Game_How_Much_AI
 * Communication tips like not informing the user that they have said the word wrong, have NPC's interact with hand gestures in the game and to not put a time limit to say the word inspired from https://www.aphasia.org/aphasia-resources/communication-tips/
 * Ensuring the game captures real world scenarios inspired from https://openaccess.city.ac.uk/id/eprint/2860/1/Computer%20delivery%20of%20gesture%20therapy%20for%20people%20with%20severe%20aphasia.pdf
 * Inspiration to use visual references like objects in the game to support their understanding and to name the word correctly from https://www.nhs.uk/conditions/aphasia/treatment/

# Screenshots 📷

<h1> Menu </h1>
 <p align="center">
  <p> Pause menu</p>
  <img src="Game%20Screenshots/Menus/menup1.png" width="350" >
  <p> Dialogue outputted warning user saved progress will be overwritten if they continue. This is presented if user wishes to start a new game when saved progress exists </p>
  <img src="Game%20Screenshots/Menus/menup2.png" width="350" >
  <p> If user attempts to load a non existing save file</p>
  <img src="Game%20Screenshots/Menus/menup3.png" width="350" >
  <p> Loading screen implemented so the user has something to look at whilst a particular scene is being loaded in the background</p>
  <img src="Game%20Screenshots/Menus/loadp1.png" width="350" >
  <img src="Game%20Screenshots/Menus/loadp2.png" width="350" >

</p>

<h2> Saved Player Data </h2>
<p align="center">
  <p> json file showing the current saved player progress(level,score for that level,avatar position in that level) encrypted.</p>
  <img src="Game%20Screenshots/encrypted%20save%20data/dataencrypt.png" width="450" >
</p>


<h2> Level 1 </h2>

  * Dialogue System
<p align="center">
  <img src="Game%20Screenshots/Level%201/l1p1.png" width="350" >
  <img src="Game%20Screenshots/Level%201/l1p2.png" width="350" >
 <img src="Game%20Screenshots/Level%201/l1p3.png" width="350" >
</p>

 * Image below showing the user has named the object correctly, hence incrementing the score.
![](Game%20Screenshots/Level%201/l1p4.png)


<h2> Level 2 </h2>
  
   <p align="center">
  <img src="Game%20Screenshots/Level%202/l2p1.png" width="350" >
  <img src="Game%20Screenshots/Level%202/l2p6.png" width="350" >
  </p>
  

  * Dialogue System
<p align="center">
  <img src="Game%20Screenshots/Level%202/l2p2.png" width="350" >
  <img src="Game%20Screenshots/Level%202/l2p3.png" width="350" >
 <img src="Game%20Screenshots/Level%202/l2p4.png" width="350" >
</p>

 * Image below showing the user has named the object correctly, hence incrementing the score.
![](Game%20Screenshots/Level%202/l2p5.png)

<h2> Level 3 </h2>

   <p align="center">
  <img src="Game%20Screenshots/Level%203/l3p1.png" width="350" >
  </p>
  

  * Dialogue System
<p align="center">
  <img src="Game%20Screenshots/Level%203/l3p2.png" width="350" >
  <img src="Game%20Screenshots/Level%203/l3p3.png" width="350" >
 <img src="Game%20Screenshots/Level%203/l3p4.png" width="350" >
</p>

 * Image below showing the user has named the object correctly., hence incrementing score counter.
![](Game%20Screenshots/Level%203/l3p5.png)






