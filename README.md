# Dissertation project

# About the project
This project is a serious game, developed in Unity with scripts written in C#, aimed at the rehabilitation of aphasia with a focus on noun therapy.
This project was a funded research project at my university and was validated by a speech therapist to ensure it can provide desired therapeutic effects

# References
The following references were presented to my speech therapist that were drawn as inspiration, to which I would feature into my game in order to achieve the desired therapeutic effects
 * Chosen words inspired from https://www.ncbi.nlm.nih.gov/pmc/articles/PMC5367780/
 * Level design inspiration from https://openaccess.city.ac.uk/id/eprint/18025/1/Experiencing_EVA_Park_Galliers_TACCESS_FINAL.pdf
 * 


# What I learnt :rocket:
* Using Watson IBM speech to text API to detect normal sounding audio and convert into text.
* Incremental process model - applying this model consistently throughout development, ensuring each increment was checked and tested alongside a
  speech therapist.
* Design pattern - primarly focused on the state pattern for state animations like player movement.
* Designing relevant state machines to control animation states for the avatar and NPCs(Non Player Characters).
* Using BinaryFormatter in C# to save the players data(score,position,level) as well as load this data. It will serialize data structures when user wishes to save, and deserializes it when the user wishes to load the saved file.
* Using CryptoStream to encrypt and save after serialization and decrypt and load data after deserialization.
* Using FileStream to read/write/open/close to a file, given the correct path, that contains the saved player data.


# Links 


# Game Screenshots




# Before you get started
This project uses the game engine Unity and uses Unity SDK file in order to use IBM watsons speech to text API 

So:

1. Download Unity
2. You need an IBM Cloud account to generate service credentials; url and apikey.
3. Download the unity SDK file from:https://github.com/watson-developer-cloud/unity-sdk and add this inside the game asset
4. Take the script 'ExampleStreaming.cs' from the SDK file, and add this into game component.
5. Paste the service credentials you generated into the empty fields inside the inspector.


