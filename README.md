# SpaceEngineers-InGameScripts
A multitude of ingame scripts for managing ship and station.

##asd
--
### What does it do?
A lot of people are frustrated when the oxygen is sucked out of their ships once they open their doors. 
This script is for people who want to have a fully automatic system. You no longer have to worry about air traveling outside your ship. 
So I created this script which does the entire depressurization process for you. All you have to do is press a single button. The system is completely secure. Even if you accidently press the door button you do not have to worry about losing air. 
The script was made to be completely idiot proof. No random mashing and button spamming will break it. 

### How does it work?
The system starts by looking for blocks that have Exit, Entrance and chamber in their name. Exit stands for the exit doors, entrance for the entrance doors and chamber for the ventilation located in the depressurization chamber. You can have as many of them as you like. Just ensure they have the provided words in their names. 

First the system locks all the doors in the depressurization chamber and secures them by turning them off. This will prevent any interraction with them and any unathorized attempt to open them. 
Once done, the depressurization feature of the chamber's ventilation is turned on. 
Then the system scans if the depressurization process was done corretly and there is no air left in the chamber. If everything is done correctly, the exit doors open and turn off again to prevent unauthorized interraction, otherwise the process reverts and opens the entrance doors again. 

The process of entering is entirely the same. Instead of depressurization there is pressurization. 



## Quick Install Guide:

1. Create 2 Timer blocks and name them "PTimer 1" and "PTimer 2" and make them 
RUN the code from the computer hosting it by adding it to the hotbar. 
2. Create 1 Interior light and name it "FunctionLight". Set all values to 1. 
3. Create ventilations for depressurizing and name them/it "ChamberVent". Just make sure there is 
word "Chamber" in it. (ChamberVent 1, 2, 3.. etc) 
4. Make doors. The entrance doors named "Entrance" and the exit doors named "Exit". Again, make as many as you like. 
Just make sure it has the words provided in their names. (ExitDoor 1, 2, 3.. etc) 
5. Make a computer and upload this code (Duh). 
6. Create button panels that run the code for opening and closing. (Another duh). 


You can also change the time the depressurization takes. Default is 7 seconds. 
to do this change YourCustomTimer = 7; to YourCustomTimer = "Seconds". 
DO NOT SET IT LOWER THAN 3 SECONDS. 
example: You want the process to take 10 seconds then simply change the it to: 
YourCustomTimer = 10; 

## What is it good for? 
Some larger rooms with small amount of ventilations take longer to depresurize and the system will 
not allow you to exit while there is still air in the chamber. 

MAKE SURE THERE IS ENOUGH SPACE IN THE TANKS TO STORE THE OXYGEN IN THE CHAMBER. 
OTHERWISE THE VENT WILL NOT BE ABLE TO SUCK OUT THE AIR AND THE EXIT DOOR WILL NOT OPEN. 

MADE BY: Alexandre Prevost / prevosta. 

Enjoy 
And do not forget to RATE! 

## FAQ.
Q: Help! Only the entrance doors are opening and closing. 
A: The oxygen tanks are probably full and the air in the chamber does not get sucked out. Make another tank or remove some air from the tanks. Also turn off your oxygen generators. 

Q: I have set up the code by following the instructions but the code is giving me Exception errors and it is not working. 
A: There might be another block with the name Chamber/Entrance/Exit/ that is not an Air Vent or a door. Please remove it or change its name.
