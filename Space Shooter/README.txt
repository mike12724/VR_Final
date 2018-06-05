**VR Space Shooter**

**Description**
VR Space shooter implements a first person shooting game located in outer space where the player 
flys around shooting enemy asteroids to get points. The game was developed in Unity and uses the VRDUINO
to track head motion. 

**System Requirements**
Windows 10, 64 bit
Unity version 2018 1.1
Baud rate 115200

**VRDUINO Usage**
Orientation tracking is implemented for the VRduino in the vrduino/vrduino.ino and accompanying scripts. 
Instructions are included within that file on how to implement orientation tracking. 

**Unity Usage**
In the Assets folder, go to the Scenes folder and open the Sample Scene to see the environment build. 
All of the game and player scripting is contained in the Scripts folder (also in Assets). Everything 
needed to run this game in Unity is provided. 

Scripts:
-ReadUSB2.cs : reads orientation for headset
-Mover.cs, Mover_bolt.cs : moves the asteroid/bullets
-DestroyByBound.cs, DestroyByContact.cs : destroys game objects
-PlayerController.cs : handles player/camera control
-GameController.cs : handles game play