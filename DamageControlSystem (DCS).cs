// Damage Control System (DCS) - copyright Alexandre Prevost 2015
//
// Add [DCS] to Text Panel name for see information.

const string DCS_TEXTPANEL = "DCS";

List<IMyTerminalBlock> blocks;
List<IMyTerminalBlock> virtualMass;
List<IMyTerminalBlock> batteryBlocks;
List<IMyTerminalBlock> beacons;
List<IMyTerminalBlock> doors;
List<IMyTerminalBlock> largeGatlingTurrets;
List<IMyTerminalBlock> gravityGenerators;
List<IMyTerminalBlock> gyroscopes;
List<IMyTerminalBlock> interiorLights;
List<IMyTerminalBlock> largeInteriorTurrets;
List<IMyTerminalBlock> reactors;
List<IMyTerminalBlock> thrusters;
List<IMyTerminalBlock> largeMissileTurrets;
List<IMyTerminalBlock> smallMissileLaunchers;
List<IMyTerminalBlock> smallMissileLauncherReloads;
List<IMyTerminalBlock> solarPanels;
List<IMyTerminalBlock> soundBlocks;
List<IMyTerminalBlock> gravityGeneratorSpheres;
List<IMyTerminalBlock> warheads;
List<IMyTerminalBlock> textPanels;


void Main()
{
   initBlockList();
   censusBlocks();
   displayResult();
}

void initBlockList()
{
   blocks = GridTerminalSystem.Blocks;
   virtualMass = new List<IMyTerminalBlock>();
   batteryBlocks = new List<IMyTerminalBlock>();
   beacons = new List<IMyTerminalBlock>();
   doors = new List<IMyTerminalBlock>();
   largeGatlingTurrets = new List<IMyTerminalBlock>();
   gravityGenerators = new List<IMyTerminalBlock>();
   gyroscopes = new List<IMyTerminalBlock>();
   interiorLights = new List<IMyTerminalBlock>();
   largeInteriorTurrets = new List<IMyTerminalBlock>();
   reactors = new List<IMyTerminalBlock>();
   thrusters = new List<IMyTerminalBlock>();
   largeMissileTurrets = new List<IMyTerminalBlock>();
   smallMissileLaunchers = new List<IMyTerminalBlock>();
   smallMissileLauncherReloads = new List<IMyTerminalBlock>();
   solarPanels = new List<IMyTerminalBlock>();
   soundBlocks = new List<IMyTerminalBlock>();
   gravityGeneratorSpheres = new List<IMyTerminalBlock>();
   warheads = new List<IMyTerminalBlock>();
   textPanels = new List<IMyTerminalBlock>();
}

void censusBlocks()
{
   GridTerminalSystem.GetBlocksOfType<IMyVirtualMass>(virtualMass);
   GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock>(batteryBlocks);
   GridTerminalSystem.GetBlocksOfType<IMyBeacon>(beacons);
   GridTerminalSystem.GetBlocksOfType<IMyDoor>(doors);
   GridTerminalSystem.GetBlocksOfType<IMyLargeGatlingTurret>(largeGatlingTurrets);
   GridTerminalSystem.GetBlocksOfType<IMyGravityGenerator>(gravityGenerators);
   GridTerminalSystem.GetBlocksOfType<IMyGyro>(gyroscopes);
   GridTerminalSystem.GetBlocksOfType<IMyInteriorLight>(interiorLights);
   GridTerminalSystem.GetBlocksOfType<IMyLargeInteriorTurret>(largeInteriorTurrets);
   GridTerminalSystem.GetBlocksOfType<IMyReactor>(reactors);
   GridTerminalSystem.GetBlocksOfType<IMyThrust>(thrusters);
   GridTerminalSystem.GetBlocksOfType<IMyLargeMissileTurret>(largeMissileTurrets);
   GridTerminalSystem.GetBlocksOfType<IMySmallMissileLauncher>(smallMissileLaunchers);
   GridTerminalSystem.GetBlocksOfType<IMySmallMissileLauncherReload>(smallMissileLauncherReloads);
   GridTerminalSystem.GetBlocksOfType<IMySolarPanel>(solarPanels);
   GridTerminalSystem.GetBlocksOfType<IMySoundBlock>(soundBlocks);
   GridTerminalSystem.GetBlocksOfType<IMyGravityGeneratorSphere>(gravityGeneratorSpheres);
   GridTerminalSystem.GetBlocksOfType<IMyWarhead>(warheads);
   GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(textPanels);
}

void displayResult()
{
   print("Damage Control System \n", false);
   print("-------------------------------\n");
   print("XXXXXXXXXX\n"); // Offline
   
   print("tttttttttt\n"); // Thruster

   print("RRRRRRRRRR\n"); // Reactor
   print("BBBBBBBBBB\n"); // Battery
   print("SSSSSSSSSS\n"); // Solar
   
   print("MMMMMMMMMM\n"); // Missile
   print("GGGGGGGGGG\n"); // Gatling
   print("WWWWWWWWWW\n"); // WarHead
  
   print("DDDDDDDDDD\n"); // Defence matrix
   print("@@@@@@@@@@\n"); // Gravity
   print("##########\n"); // Mass
   print("                    |\n"); // Mass
}

void print(string msg, bool append = true)
{
   for (int inxScreen = 0; inxScreen < textPanels.Count; ++inxScreen)
   {
      if (textPanels[inxScreen].CustomName.Contains(DCS_TEXTPANEL))
      {
         IMyTextPanel screen = textPanels[inxScreen] as IMyTextPanel;
         screen.WritePublicText(msg, append);
         screen.ShowTextureOnScreen();
         screen.ShowPublicTextOnScreen();
      }
   }
}