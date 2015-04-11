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

public struct Pos
{
   public double x, y;
   public string mark;
};

List<Pos> asd;

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
   
   asd = new List<Pos>();
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
  
   
   var blocks1 = new List<IMyTerminalBlock>();
	GridTerminalSystem.SearchBlocksOfName( "[DCS-Center]", blocks1 );
   if (blocks1.Count == 0) { print("NOPE!"); return;}
   IMyTerminalBlock centerBlock = blocks1[0];
    
   var blocks2 = new List<IMyTerminalBlock>();
   GridTerminalSystem.SearchBlocksOfName( "[DCS-Front]", blocks2 );
   if (blocks2.Count <= 0) {print("2?"); return;}
   IMyTerminalBlock frontBlock = blocks2[0];

   var blocks3 = new List<IMyTerminalBlock>();
   GridTerminalSystem.SearchBlocksOfName( "[DCS-Right]", blocks3 );
   if (blocks3.Count <= 0) {print("3?"); return;}
   IMyTerminalBlock rightBlock = blocks3[0];
   
   Vector3D rightVector = (rightBlock.GetPosition() - centerBlock.GetPosition());
   Vector3D frontVector = (frontBlock.GetPosition() - centerBlock.GetPosition());
   
   for(int i = 0; i < blocks.Count; ++i)
   {
      Vector3D blockVector = (blocks[i].GetPosition() - centerBlock.GetPosition());
      
      // Offset.
      blockVector = (blockVector + (22 * rightVector));
      blockVector = (blockVector + (22 * frontVector));
      
      projection2D(rightVector.GetDim(0), rightVector.GetDim(1), rightVector.GetDim(2), frontVector.GetDim(0), frontVector.GetDim(1), frontVector.GetDim(2), blockVector.GetDim(0), blockVector.GetDim(1), blockVector.GetDim(2), "!!!!");
   }
   
   for(int i = 0; i < largeGatlingTurrets.Count; ++i)
   {
      Vector3D blockVector = (largeGatlingTurrets[i].GetPosition() - centerBlock.GetPosition());
      
      // Offset.
      blockVector = (blockVector + (22 * rightVector));
      blockVector = (blockVector + (22 * frontVector));
      
      projection2D(rightVector.GetDim(0), rightVector.GetDim(1), rightVector.GetDim(2), frontVector.GetDim(0), frontVector.GetDim(1), frontVector.GetDim(2), blockVector.GetDim(0), blockVector.GetDim(1), blockVector.GetDim(2), "KK");
   }
   
   for(int i = 0; i < largeMissileTurrets.Count; ++i)
   {
      Vector3D blockVector = (largeMissileTurrets[i].GetPosition() - centerBlock.GetPosition());
      
      // Offset.
      blockVector = (blockVector + (22 * rightVector));
      blockVector = (blockVector + (22 * frontVector));
      
      projection2D(rightVector.GetDim(0), rightVector.GetDim(1), rightVector.GetDim(2), frontVector.GetDim(0), frontVector.GetDim(1), frontVector.GetDim(2), blockVector.GetDim(0), blockVector.GetDim(1), blockVector.GetDim(2), "KK");
   }
   
   // 50x50
   {
      string[] map = new string[50 * 50];
      string msg = "";
      
      for (int inx = 0; inx < map.Length; ++inx)
      {
         map[inx] = "    ";
      }
      
      for (int inx = 0; inx < asd.Count; ++inx)
      {
         int x = Convert.ToInt32(Math.Round(asd[inx].x / 2.5));
         int y = Convert.ToInt32(Math.Round(asd[inx].y / 2.5));
         
         if(x < 50 && y < 50)
         {
            map[((49-y) * 50) + x] = asd[inx].mark;
         }
      }
      
      for (int inx = 350; inx < map.Length; ++inx)
      {
         msg += map[inx];
         if ((inx % 50) == 49)
         {
            msg += "\n";
         }
      }
      
      print(msg, false);
   }
}

void projection2D(double ix, double iy, double iz, double jx, double jy, double jz, double vx, double vy, double vz, string mark)
{
   Pos pos;
   pos.mark = mark;
   double x, y; // Result.

   {
      double scalar = (ix * vx) + (iy * vy) + (iz * vz);
      double normsquare = (ix * ix) + (iy * iy) + (iz * iz);
      double dist = scalar / normsquare;
      double hx = (dist * ix), hy = (dist * iy), hz = (dist * iz);
      
      pos.x = Math.Sqrt((hx * hx) + (hy * hy) + (hz * hz));
   }
   
   {
      double scalar = (jx * vx) + (jy * vy) + (jz * vz);
      double normsquare = (jx * jx) + (jy * jy) + (jz * jz);
      double dist = scalar / normsquare;
      double hx = (dist * jx), hy = (dist * jy), hz = (dist * jz);
      
      pos.y = Math.Sqrt((hx * hx) + (hy * hy) + (hz * hz));
   }

   asd.Add(pos);
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

// Turret(T) Thruster(o) Power(p) Storage(s) Antenna(a)
// !! II ii jj T F K a b d e g h k n o p s u y 