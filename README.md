# SpaceEngineers-InGameScripts
A multitude of ingame scripts for managing ship and station.

## Inventory Control System (ICS).cs
### What does it do?
Managing inventory can take an uge part of your gaming time. This script is for people who want to have a fully automatic system. You no longer have to worry about moving item arround the conveyor systems of your ship. 

So I created this script which does the entire inventory management process for you. All you have to do is add a couple of tag on your cargo and refinery and the managing will start automatically. 

The script manage items inside every ship compenent such as Cargo, Refinery, Assembler & connector. It's also give you a fast overview of your inventory via various TextPanel. WaterMark can be configurate to optimize ore refinery and compenent assembly. A priority list of ore to mine are also automatically created and showed in TextPanel.

### How does it work?
The script can be call repeatedly by a timer or manually directly on the Programming Block, by a button panel or by hotkey. It will make a complete round of all the blocks with inventory in the ship/station and sort every item where it should be. You have to put the appropriate tag on the name of every cargo that you want to be use has a specific storage. Ex: Large Cargo Container [Component] will receive all the "component" of the conveyor system.

In the same order of idea, a refinery with the tag [Uranium] will process only "Uranium" and a cargo with the tag [Ingot] will receive all the ingot produce in the system. The same process can be done with Assembler and Connector and with every type of item or specific name (Ammo Gun Nickel Grinder Ore ...). 

The name of the item or group of item must be in the name of the Container and surrend by square brace "[" and "]". A special name [Sealed] can be use to prevent the system to sort in/out any item in that specific Container.

A census of all item is generated in order to give you a fast overview of your inventory. WaterMark level for each item can be configurate in other to give you a fast feedback and warning system.

## Quick Install Guide:
1. Build a Programming Block and compile the code into it.
2. Add tags to every container/refinery/assembler/connector you want to control.
3. Build a TextPanel with the tag [ICS] in the name.
4. Run the script manually or by a timer that call itself and "Run" the Programming Block every X sec.
5. Voila!

If you don't want to fight agains the program when you move manually some items, you can turn off the timer or set the loop to more than 10 second.

## What is it good for? 
Manage and display your inventory automaticaly. Establish the next ore you need to mine. Manage the ore and component processing to ensure every item amount stay on the WaterMark configurated.

MADE BY: Alexandre Prevost / prevosta. 

Enjoy 
And do not forget to RATE! 

## FAQ.
Q: None.
A: None.

## Damage Control System (DCS).cs
### What does it do?

### How does it work?

## Quick Install Guide:
1. Build a Programming Block and compile the code into it.
2. Build a TextPanel with the tag [DCS] in the name.
3. Run the script manually or by a timer that call itself and "Run" the Programming Block every X sec.
4. Voila!

## What is it good for? 

MADE BY: Alexandre Prevost / prevosta. 

Enjoy 
And do not forget to RATE! 

## FAQ.
Q: None.
A: None.
