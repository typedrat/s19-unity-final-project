# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**

## Gameplay explanation ##

**In this section, explain how the game should be played. Treat this like a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**




# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based off the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your own relevant information. Liberally use the template when necessary and appropriate.

## User Interface

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your own movement scripts that do not use the phyics system?**

## Animation and Visuals
* Laser flea - https://ismartal.itch.io/2d-animated-monster-character-laser-flea?download
* Asteroid - https://handsomeunicorn.itch.io/meteoroid-sprite
* Lasers - https://ollieberzs.itch.io/industrial-pack
* Stars and space - https://assetstore.unity.com/packages/2d/textures-materials/dynamic-space-background-lite-104606
* Smiling spaceship - https://opengameart.org/content/smiling-spaceship-game-character
* Escape ship - https://opengameart.org/content/spaceship-sprite-8-directions-64x64

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

The trickiest part was finding free assets at all. Because of this, the visual style of the game isn't consistent by any means. However, I tried to keep things as consistent as possible, pixelating assets that were too HD, rendering them at lower qualities, etc. In terms of game feel, I attempted to animate everything rather than have a static image so that the world would feel more responsive and real (this of course made finding assets even harder, limiting me to only spritesheets and simple aniamtions). The master branch may not hold all the animations I did, and you mentioned a staging area to show off our part, so if you're so inclined please pull from the "va" branch on our repository and you'll see all my animations [https://github.com/typedrat/s19-unity-final-project/tree/va/NFRS%20Hanover/Assets/Animations]

* Animation of sprites - Using the first project (Pirate Captain) as a guideline, I found assets online that offered spritesheets, easing the addition of animations to the project. Using the same project, I added triggers to transtion from one animation to the next (e.g. the robot flea will randomly go from walking to idling at with a rate of 30%, done using the Animator window) [https://github.com/typedrat/s19-unity-final-project/tree/master/NFRS%20Hanover/Assets/Animations]
* Hard-coded world, procedurally generated enemies - The world itself is static, so there is an end to the level. There was talk of procedurally generating it, but with the time crunch it was too difficult. The enemies, however, are spawned randomly, and they are placed on the map in an immersive way (e.g. lasers will always be anchored on top, fleas will always be on the floor or ceiling) [https://github.com/typedrat/s19-unity-final-project/blob/123012d1fdd66c4fa1ca8928c3f42dd8e9df8627/NFRS%20Hanover/Assets/Scripts/SpawnMonsters.cs#L37]
* Camera choice - For our type of game, we have a flappy-bird-esque kind of gameplay, where we dodge monsters on the map and try to get to the end. To that end, I chose to put the camera a little ahead of the player in order to make it easier to spot enemies and give the player more time to react. As a design choice, I think it makes sense for our type of game, where reaction is key (especially since in space, everything moves a bit clunkier) [https://github.com/typedrat/s19-unity-final-project/blob/123012d1fdd66c4fa1ca8928c3f42dd8e9df8627/NFRS%20Hanover/Assets/Scripts/CameraController.cs#L19]
* Style guide - Per our storyboard person, we have a space-themed game, where a rat in trapped in space and needs to escape. I needed to find a kind of industrial, techy background to show that we were on a spaceship, but at the same time I needed to show we were in space. I chose to emphasize space more than the spaceship, so I chose a repeated metallic background with clear windows, so the player was able to see the stars and the nebula outside and get a more immersive feel. 


## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio

* Main Menu - https://opengameart.org/content/endgame-singularity (awakening.ogg)
* Main Scene - https://opengameart.org/content/endgame-singularity (inevitable.ogg)
* Win Scene - https://opengameart.org/content/endgame-singularity (win.ogg)
* Lose Scene - https://opengameart.org/content/endgame-singularity (lose.ogg)
* Flea Sound - https://opengameart.org/content/monster-1
* Button Sound - https://opengameart.org/content/select-1
* Rat Walking - https://www.youtube.com/watch?v=ubrwgRni3Ro (used for non-profit and sound is very subtle)

* Implementing the audio system was not the hardest part of this subrole. The hardest part was finding good audio sources that were free and open source that fit our needs. The reason being is that we were going for a retro game feel and finding specific retro sounds such as the ones we were looking for were rather hard. That being said, there was more research in my part than anything.
* As for implementation, there was no crazy scripts that I needed to write as our game was rather simple and we had multiple scenes. The way the game was designed allowed me to add the audio sources onto the scene's camera by simply adding an audio source to it. This is not to say there wasn't any code for the audio but if there was it was rather simple. I personally did not know a lot about audio within C# scripts, but my group members helped me out to add sound to the rat's footsteps. 
* https://github.com/typedrat/s19-unity-final-project/blob/2374eb09a00f028b9b8142668ad2714c786abffa/NFRS%20Hanover/Assets/Scripts/PlayerPhysics.cs#L9
* https://github.com/typedrat/s19-unity-final-project/blob/2374eb09a00f028b9b8142668ad2714c786abffa/NFRS%20Hanover/Assets/Scripts/PlayerPhysics.cs#L70

* As for sound style I believe I was able to achieve the 8/16bit feel that we were going for. I originally had different audio files but got feedback from my group members to see what they thought. They felt that it was lacking so they gave me some suggestions. With these suggestions I came across endgame-singularity and we agreed that it was a good fit to what we were looking for. 

## Gameplay Testing

[https://github.com/typedrat/s19-unity-final-project/blob/master/Player%20Observations%20-%20Sheet1.pdf]

* The number one problem we had was our lack of story. Players didn't understand what was happening, we just threw them into the game at the start. I think the game trailer will help with that, but a little intro scene would have made it much better. 
* The second biggest problem people had was the controls, saying it felt clunky and slow to repsond, but that was a characteristic of the game, so I would say acceptable. 
* The third most mentioned thing was the lasers. Everybody had something to say about the lasers. Some people loved how random they were, while others hated that they couldn't 100% predict their behavior.

## Narrative Design

**oDocument how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
