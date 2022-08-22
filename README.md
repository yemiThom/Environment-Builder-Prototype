# Environment Builder Prototype

Inspired by City Builders and Tycoon genre games, this project gives the player the opportunity to build their own forest.

## Description

The aim of the project was to create a mobile application with the following features:
* Allow the player to navigate inside a 3D environment
* Allow the player to select different assets through a user interface, and place them inside the environment
* Allow the player to move, resize and delete the assets in the environment
* Allow for the assets to persist between sessions
* Allow the user through the use of a button to remove all assets, and revert the actions from the user 

## Getting Started
I approached this project by breaking it as a whole into smaller achievable tasks. 
I then decided to work on developing these tasks for the Unity Editor and subsequently Keyboard and Mouse controls.
This meant that I had a working baseline to build further from for mobile devices and touch controls.

For example, to "Allow the player to navigate inside a 3D environment" I decided I needed to:
* determine what keyboard commands would move the camera around the environment - WASD and the Arrow Keys
* determine the heirarchy structure of the camera gameobject - childing the camera gameobject to an empty parent gameobject, so as to apply property changes to the parent instead
* determine what speed the camera was to move around the environment comfortably
* determine what zoom mechanic worked best with the gameplay style - which was to update the child camera's local position between two points
* determine the rotation pivot point of the camera the best fit the gameplay - which was to pivot the localrotation of the camera around the parent gameobject

To achieve the effect of persisting assets between sessions, I opted for a binary formater save and load system.
I decided that serializing and deserializing the game data when saving and loading was best practice as this limits the chances of game data being tampered with externally.

I decided to implement the command pattern concept to achieve the undo/redo mechanic. The concept implements a stack tracking structure for actions taken by the user during gameplay.

On binding a large majority of the mechanics to keyboard keys, I moved on to developing the touch mechanics and User Interface.


### Executing program

How to run the program

* Press Start to open up the environment
* Select an asset category on the left panel, such as Ground Tiles; 
    * Mountains; Mossy Rocks; and Flora, like trees and flowers.
* A sub menu will pop up offering one of the many assets to choose from within a category.
* Selecting an asset will produce a 'ghostly' blueprint version of the asset the player has chosen. Tap anywhere on the screen to place the actual asset in the environment.
* The panel at the bottom of the screen gives the player a number of options to control the selected asset. This includes:
    * A button to toggle the camera controls on/off. This will allow to better control moving the asset around the environment
    * Buttons to rotate the asset right or left
    * Buttons to scale the asset up or down
* There is an Options panel to the top right corner of the screen. This will give the player the option to save or load, undo or redo their actions, or delete the seleceted or all assets in the environment 