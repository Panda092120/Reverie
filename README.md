Instructions: The game should work fine from the start but it'll start right away. 

General instructions
-------------------------------
  - Up: [up button] or W
  - Down: [down button] or S
  - Left: [left button] or A
  - Right: [right button] or D
  - Interact/Talk: Z
  - (some dialogues will involve using the mouse to select options for the player's response, so 

In-Battle
------------------------------- 
  - Use your mouse to click on the icons in battle and select the move you would like to perform.
  - For minigames, use UP, DOWN, LEFT and RIGHT to move around or SPACE to time accuracy moves.

Bugs
--------------------------------
- Gym would not load properly upon building the project due to a dialogue manager not being attached to its respective teleportation object. (If you would like it to work, find "BattleSwitcher" object and under Battle Interaction Script Component, where the serializable field is for Dialogue Manager, fill that in with "Dialogue Manager". It helps load battles through interactions).
- Teleporters teleport player to the (0,0) coordinate of the scene, so the player may appear in unexpected places as the scene loads.
- Colliding with a teleporter from one room to the next horizontally does not always work. For context, vertically (moving from one room to the next as the character moves from up to down or vice versa) works normally, but we seem to be horizontally challenged.
- Item button and run buttons don't do anything at the moment, as they are placeholders. Not necessarily a bug, just not fully implemented yet.
To our knowledge, there are no known bugs in this project, but there is a lot of ground to cover in a game like this one so though we have tested and found nothing ourselves, it may not be perfect. Please let us know.

3rd Party Items Used 
--------------------------------
  - Tilesets: LimeZu
  - Songs: Lucas Salinas, NiKneT_Art (free for use)
  - Sounds: DrPetter (sfxr.me)
  - Other: https://www.youtube.com/watch?v=dcPIuTS_usM&start=391


Our Repository
--------------------------------
https://github.com/Panda092120/Reverie
--------------------------------
Thank You for Playing!
--------------------------------
