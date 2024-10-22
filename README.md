# GameEngineFinalProject
 
Conor MacCarthy - 100876374

This Unity project was created by me in its entirety

This game is a small, first person shooting range. The player can walk around a small playable area. There are some buttons that the player can shoot to change the difficulty and a start button. Shooting the start button causes a number of targets to appear one after another. The goal for the player is to shoot the targets as many times as possible to get a high score. 5 targets will spawn, at which point the player must shoot the start button again to try again, which resets their score.

Controls:
- WASD - Move
- M1 (Left click) - Shoot

This project demonstrates use of the following design patterns: Singleton, Observer, Command, Factory. Below is a brief description of where in the project each pattern has been implemented:
- Singleton: The UI Manager is a singleton. It controls the score displayed, as well as the current difficulty.
- Observer: The UI Manager observes the Player Controller. When the player shoots a target, the UI Manager is notified and increases the score by 10.
- Command: When the difficulty is raised or lowered, the requests are passed as command objects to an invoker. The invoker executes the command to increase the difficulty, and undoes the command to lower the difficulty.
- Factory: There are 3 concrete factories corresponding the the 3 target types (small, medium and large). When the start button is shot, the factory corresponding with the current difficulty spawns targets one at a time. Targets are spawned in random locations by the factory, and the factory also tells the targets to start moving. The specific logic for movement is unique for each target type.

Scene Preview:
![GameEngineScene](https://github.com/user-attachments/assets/d211063e-6ee5-4112-805c-69e8e552d6da)

