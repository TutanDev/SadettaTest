# SadettaTest

## Instructions for Sadetta's game developer job test assignment
· This assignment should be done by the applicant without invoking external help
· Available time for completing the assignment is by the end of day (hour is not important)
· Use Unity version 2019 or 2020 LTS
· Use of online documentation and external graphics assets is allowed
· C# code and especially design of modules should be self made (no game templates)
· Do not bloat the project with external assets
· Focus on Quality
· When something is not clearly specified, you are free to make design decisions

##The Task
Implement an endless left-to-right "flyer" with Windows Standalone as the target platform. The player controls a flying ship at the
left side of the screen while obstacles come in from right to left. Reference: Geometry Dash Lite trailer 00:29 - 00:37.

## Details
· When the game is started, it loads top scores list from disk
· A start screen with top scores and "START" option is shown after launch and between games
· ESC while flying aborts to start screen and ESC at start screen exits game
· One-button flying mechanic; when button is down, the ship rotates counter clockwise
 until heading too high and when button is up, the ship rotates clockwise until
 heading too low (see the reference)

· Left mouse button, space and up arrow should all work as the flight control button
· You can choose what kind of obstacles there are; only one kind is required
· Obstacles should be placed automatically; no level design
· If the ship hits an obstacle, it is destroyed and the game is over
· If the ship passes an obstacle, score is increased by one
· When the game is over, a game over screen is shown
· If player made it to the top scores, the game asks name for the top score list
 and updated top scores list is saved to disk
· Sounds and background music are not required

## Feedback
### Veredict
Verdict is that it is nicely presented, achieves all the functional goals, the code is clearly written with concise class structure 
and your ways of coupling systems together contain patterns that facilitate achieving a high quality modular design. 
Even mechanics have been tuned so well that it is nice to play with [it was the best game actually]. 
You have demonstrated use of techniques such as Prefabs, Linq and ScriptableObjects in a concise way to achieve the goals of the project.
### Improvement points
While you have demonstrated loose coupling of many systems (such as Input and Player via BoolReferences), 
some systems within the game are directly interconnected with each other for no good obvious reason. 
That kind of design starts presenting growing issues in a larger project. I would suggest using loose coupling between systems
to a larger extent. Example: Player directly calls GameManager.Instance.ChangeState if EscInput is given. 
To make Player a truly standalone system (eg for testing / using it in different environment), 
it would be preferable that the class wouldn't have any kind of reference to GameManager. 
You could use another ScriptableObject to remove the reference... or even better, maybe the EscInput should not be handled by Player at all.
### Final Rank
I ranked your project to 3rd best place of assignments that we received. 
The project contains the right building blocks and designs, and I don't have great new building blocks to give you -- just keep following the best practices to their full extent in assignments like this.
