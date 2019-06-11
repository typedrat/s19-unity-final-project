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

The game does use the physics system in part, but the way that inputs are mapped for movement is somewhat nonstandard. It uses simple force-based movement on the ground, but more complex manual velocity control for the air control, since the default physics cannot accomodate the (physically impossible) constant-speed variable-direction movement style.

* [Gravity is toggleable](https://github.com/typedrat/s19-unity-final-project/blob/cf39afa1ea6fdfe321f9935d644f8792ed3599c0/NFRS%20Hanover/Assets/Scripts/PlayerPhysics.cs#L14)
  – 
  This part of the script handles fixing the rotation of the object, toggling gravity on and off, and storing the speed that is used for the 2D velocity-vectoring controls in the air. This doesn't directly connect to the ideas we presented in class outside of the physics manager communicating with the input system via the command pattern, but the idea came from a test I made to test different jump arcs after that particular lecture.
* [Enemies only fire when visible](https://github.com/typedrat/s19-unity-final-project/blob/7d7eda444ab202a90dfbdd8a5a206cb9b2a30d04/NFRS%20Hanover/Assets/Scripts/LaserController.cs#L23)
  – 
  Not only does this save resources, it also prevents the game from quickly turning into a cacophony of sound effects. While sound effects are an important element of game feel, as we discussed in class, it is important to not overdo these things.
* [Gravity toggle timeout and UI](https://github.com/typedrat/s19-unity-final-project/blob/19e7705e97c6a00e77ea17a7a275069c5e7129ac/NFRS%20Hanover/Assets/Scripts/GravityToggleCommand.cs#L59)
  –
  I also wrote the code that throttles the usage of the antigravity power, which is essential to game balance. It is a simple timer and bar, but is essential to the gameplay loop being successful. Powerful abilities make a game fun, but at the same time, they can also destroy the challenge of a game and make it into more of a chore than anything else.

## Animation and Visuals
* Laser flea - https://ismartal.itch.io/2d-animated-monster-character-laser-flea?download
* Asteroid - https://handsomeunicorn.itch.io/meteoroid-sprite
* Lasers and pipes- https://ollieberzs.itch.io/industrial-pack
* Stars and space - https://assetstore.unity.com/packages/2d/textures-materials/dynamic-space-background-lite-104606
* Smiling spaceship - https://opengameart.org/content/smiling-spaceship-game-character
* Escape ship - https://opengameart.org/content/spaceship-sprite-8-directions-64x64
* Yellow robot - https://www.gameart2d.com/the-robot---free-sprites.html

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

The trickiest part was finding free assets at all. Because of this, the visual style of the game isn't consistent by any means. However, I tried to keep things as consistent as possible, pixelating assets that were too HD, rendering them at lower qualities, etc. In terms of game feel, I attempted to animate everything rather than have a static image so that the world would feel more responsive and real (this of course made finding assets even harder, limiting me to only spritesheets and simple aniamtions). The master branch may not hold all the animations I did, and you mentioned a staging area to show off our part, so if you're so inclined please pull from the "va" branch on our repository and you'll see all my animations [https://github.com/typedrat/s19-unity-final-project/tree/va/NFRS%20Hanover/Assets/Animations]

* Animation of sprites - Using the first project (Pirate Captain) as a guideline, I found assets online that offered spritesheets, easing the addition of animations to the project. Using the same project, I added triggers to transtion from one animation to the next (e.g. the robot flea will randomly go from walking to idling at with a rate of 30%, done using the Animator window) [https://github.com/typedrat/s19-unity-final-project/tree/master/NFRS%20Hanover/Assets/Animations]
* Hard-coded world, procedurally generated enemies - The world itself is static, so there is an end to the level. There was talk of procedurally generating it, but with the time crunch it was too difficult. The enemies, however, are spawned randomly, and they are placed on the map in an immersive way (e.g. lasers will always be anchored on top, fleas will always be on the floor or ceiling) [https://github.com/typedrat/s19-unity-final-project/blob/123012d1fdd66c4fa1ca8928c3f42dd8e9df8627/NFRS%20Hanover/Assets/Scripts/SpawnMonsters.cs#L37]
* Camera choice - For our type of game, we have a flappy-bird-esque kind of gameplay, where we dodge monsters on the map and try to get to the end. To that end, I chose to put the camera a little ahead of the player in order to make it easier to spot enemies and give the player more time to react. As a design choice, I think it makes sense for our type of game, where reaction is key (especially since in space, everything moves a bit clunkier) [https://github.com/typedrat/s19-unity-final-project/blob/123012d1fdd66c4fa1ca8928c3f42dd8e9df8627/NFRS%20Hanover/Assets/Scripts/CameraController.cs#L19]
* Style guide - Per our storyboard person, we have a space-themed game, where a rat in trapped in space and needs to escape. I needed to find a kind of industrial, techy background to show that we were on a spaceship, but at the same time I needed to show we were in space. I chose to emphasize space more than the spaceship, so I chose a repeated metallic background with clear windows, so the player was able to see the stars and the nebula outside and get a more immersive feel. 

## Input

* *Overall Input System* - The entire input system has been abstracted using the Command Pattern as shown in project 1. This abstraction was done in order to allow for more general input mapping, so that the inputs wouldn’t have any dependencies on the attached scripts, allowing the physics / movement systems to be altered however the programmer in charge felt necessary without interfering with the Input Manager itself. In addition, this abstraction was done to make it simpler to add new input if needed, and to allow quick and easy changes to the input control scheme / overall configuration.[https://github.com/typedrat/s19-unity-final-project/blob/cf39afa1ea6fdfe321f9935d644f8792ed3599c0/NFRS%20Hanover/Assets/Scripts/InputManager.cs#L5]

* *Keyboard/Mouse Configuration* - The default input configuration is using keyboard/mouse. While all the inputs can be easily remapped using the unity controls menu when starting a unity game, the default controls are as follows:
  * wasd or arrow keys for horizontal and vertical movement (vertical movement is only possible when in antigravity mode)
  * Space to toggle antigravity mode
  * Escape to pause / unpause the game
  * Mouse for maneuvering around menus, and left click to select

* *Controller Configuration* - The game is also playable using a controller as input. Again, the inputs can be remapped using the unity controls menu, but the default controls are as follows:
  * Left joystick for movement (vertical movement only possible when in antigravity mode)
  * A or X (depending on Xbox vs Playstation controller) to toggle antigravity mode
  * Start or Options (depending on Xbox vs Playstation controller) to pause / unpause the game
  * Left joystick for maneuvering around menus, and X or Square to select a menu option (depending on Xbox vs Playstation controller)
  
In addition, the way I set up the command pattern in my Input Manager allows for horizontal and vertical axes to be given to the abstracted movement scripts to allow for more precise controls when using a controller as input  (i.e. push gently right on the left stick to move slowly right). Whether or not full precision is utilized is up to the movement system.

* *Interaction with UI* - The UI was simple to interact with using the mouse, as Unity has that set up by default, but there was a little tweaking needed for arrow key / controller input. Specifically I had to manually change the event system for the canvas and the navigation for the buttons to work properly with a controller. Without the change, the controller wasn’t able to select any options from any menu, instead requiring the mouse as input. This was necessary since I wanted controllers to be a viable input configuration.


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

* The clearest way that the narritive is communicated is through the text at the beginning of the game, which serves as both tutorial and an introduction to the (rather barebones, fitting the 16-bit-era platformer theme) story of the game.
* The fundamental nature of a platformer in this left-to-right style lends itself to escape stories well, and the plot and gameplay were designed in tandem with each other.
* The suggestions I made for audio design were made to further the themes of the game and get the context across without using words.

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

* *Impact Visuals* - When you took damage from an enemy or obstacle, I felt like there wasn’t enough of a visual or tangible “oomph” to the hit, so I added some extra effects to give it that extra push. First, I added a screenshake. My goal was to make the shake  noticeable, so you can “feel” the impact of the hit, but not overwhelming, as many games use screenshake far too generously. Secondly, I added a small pause to the game right when you’re hit. This is very short and much less noticeable unless you are looking for it, but it still adds to the feeling of weight behind the impact.

* *Invulnerability Period* - Also when taking damage, the player could continue getting damaged, which made the game less enjoyable, so I added a period of invulnerability after taking damage. To give a visual aide that the player was in fact invulnerable during this period, I made the mouse flash red continuously during the period. I also increased the transparency of the mouse, which is a common way to show invulnerability in games, and should indicate the mouse’s invulnerability to players who have seen this convention before.

* *Antigravity toggle visual* - I had some trouble knowing exactly when the mouse changed to or from antigravity mode, so I added a very short and small scale screenshake, just enough to give the player some visual clue that antigravity mode had been toggled on or off.

* *Health Pickups*- The mouse could only get damaged from the objects in the game, and I felt like it was missing something visually in game, some sort of helper or something to collect, so I added in health pickups. To keep with the overall visual and narrative style of the game, I made these pickups cheese. 

