// Inventory Control System (ICS) - copyright Alexandre Prevost 2015
//
// Add [label] to the blocks name you want to specialize. Ex: Large Cargo Container [Component]
// labels: Ore Component Ammo Ingot Gun Iron Nickel Cobalt ... Computer Display Plate ... Sealed
// Add [ICS] to Text Panel name for see information.

const string SEALED_CONTAINER = "Sealed";
const string ICS_TEXTPANEL = "ICS";

List<IMyTerminalBlock> refineries;
List<IMyTerminalBlock> assemblers;
List<IMyTerminalBlock> connectors;
List<IMyTerminalBlock> containers;
List<IMyTerminalBlock> textPanels;

                     string msg = "";

void Main()
{
                     msg = "";
   initBlockList();
   censusBlocks();
   sortItems();
   displayResult();
}

void initBlockList()
{
   containers = new List<IMyTerminalBlock>();
   refineries = new List<IMyTerminalBlock>();
   assemblers = new List<IMyTerminalBlock>();
   connectors = new List<IMyTerminalBlock>();
   textPanels = new List<IMyTerminalBlock>();
}

void censusBlocks()
{
   GridTerminalSystem.GetBlocksOfType<IMyRefinery>(refineries);
   GridTerminalSystem.GetBlocksOfType<IMyAssembler>(assemblers);
   GridTerminalSystem.GetBlocksOfType<IMyShipConnector>(connectors);
   GridTerminalSystem.GetBlocksOfType<IMyCargoContainer>(containers);
   
   GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(textPanels);
}

void sortItems()
{
   sortItemsFrom(refineries);
   sortItemsFrom(assemblers);
   sortItemsFrom(connectors);
   sortItemsFrom(containers);
}

void sortItemsFrom(List<IMyTerminalBlock> blocks)
{
    for (int inxSource = 0; inxSource < blocks.Count; ++inxSource)
    {
      IMyTerminalBlock sourceBlock = blocks[inxSource];

      if (isNotSealed(sourceBlock))
      {
         moveItemsTo(refineries, sourceBlock);
         moveItemsTo(assemblers, sourceBlock);
         moveItemsTo(connectors, sourceBlock);
         moveItemsTo(containers, sourceBlock, true);
      }
   }
}

bool isNotSealed(IMyTerminalBlock block)
{
   return (!haveBracketInfo(block) || (haveBracketInfo(block) && !getBracketInfo(block).Equals(SEALED_CONTAINER)));
}

void moveItemsTo(List<IMyTerminalBlock> blocks, IMyTerminalBlock sourceBlock, bool force = false)
{
   bool haveItemToKeep = haveBracketInfo(sourceBlock);
   string nameItemToKeep = "";
   
   if (haveItemToKeep)
   {
      nameItemToKeep = getBracketInfo(sourceBlock);
   }

   for(int inxInventory = 0; inxInventory < 2; ++inxInventory)
   {
      var srcInventory = (sourceBlock as IMyInventoryOwner).GetInventory(inxInventory);
      var items = srcInventory.GetItems();
      
      for (int inxItem = items.Count - 1; inxItem >= 0; inxItem--)
      {
         string itemName = items[inxItem].Content.SubtypeName;
         string itemLongName = items[inxItem].Content.ToString();
         int inxBestDestination = blocks.Count;
         
         if (!haveItemToKeep || (inxInventory > 0) || (haveItemToKeep && !itemName.Contains(nameItemToKeep) && !itemLongName.Contains(nameItemToKeep)))
         {
            inxBestDestination = findBestDestination(blocks, sourceBlock, itemName);
            if (inxBestDestination == blocks.Count) 
            {
               inxBestDestination = findBestDestination(blocks, sourceBlock, itemLongName, force);
            }
         }
         
         if (inxBestDestination != blocks.Count)
         {
            msg += "Move {" + itemName + "} " + sourceBlock.CustomName + "->" + blocks[inxBestDestination].CustomName + "\n";
            var dstInventory = (blocks[inxBestDestination] as IMyInventoryOwner).GetInventory(0);
            srcInventory.TransferItemTo(dstInventory, inxItem, null, true, null);
         }
      }
   }
}

int findBestDestination(List<IMyTerminalBlock> blocks, IMyTerminalBlock sourceBlock, string itemToMove, bool force = false )
{
   int inxBestDestination = blocks.Count;
   float bestVolumePct = 99.0f;
   
   for (int inxDestination = 0; inxDestination < blocks.Count; ++inxDestination)
   {
      IMyTerminalBlock destinationBlock = blocks[inxDestination];
      float inventoryVolumePct = getVolumePct(destinationBlock);
      
      if (sourceBlock != destinationBlock)
      {
         if (isDestinationValid(destinationBlock, itemToMove))
         {
            if(inventoryVolumePct < bestVolumePct)
            {
               inxBestDestination = inxDestination;
               bestVolumePct = inventoryVolumePct;
            }
         }
         else if (force && inxBestDestination == blocks.Count && !haveBracketInfo(destinationBlock) )
         { // When force is activated, non-brace block can be assign in last resort.
           inxBestDestination = inxDestination;
         }
      }
   }

   return inxBestDestination;
}

float getVolumePct(IMyTerminalBlock block)
{
   var inventory = (block as IMyInventoryOwner).GetInventory(0);
   return ((float)inventory.CurrentVolume / (float)inventory.MaxVolume) * 100f;
}

bool isDestinationValid(IMyTerminalBlock destinationBlock, string itemToMove)
{
   return haveBracketInfo(destinationBlock) && !getBracketInfo(destinationBlock).Equals(SEALED_CONTAINER) && itemToMove.Contains(getBracketInfo(destinationBlock));
}

bool haveBracketInfo(IMyTerminalBlock typeContainers)
{
   int startIndex = typeContainers.CustomName.IndexOf( "[" ) + 1;
   if(startIndex == -1)
   {
      return false;
   }
   
   int endIndex = typeContainers.CustomName.IndexOf( ']', startIndex );
   if(endIndex == -1)
   {
      return false;
   }
   
   return true;
}

string getBracketInfo(IMyTerminalBlock typeContainers)
{
   int startIndex = typeContainers.CustomName.IndexOf( "[" ) + 1;
   int endIndex = typeContainers.CustomName.IndexOf( ']', startIndex );
   return typeContainers.CustomName.Substring( startIndex, endIndex - startIndex );
}

void setBracketInfo(IMyTerminalBlock block, string value)
{
   int startIndex = block.CustomName.IndexOf( "[" ) + 1;
   int endIndex = block.CustomName.IndexOf( ']', startIndex );
   if( startIndex < endIndex && endIndex < block.CustomName.Length )
   {
      block.SetCustomName(block.CustomName.Substring(0, startIndex) + value + "]");
   }
}

void displayResult()
{
   print(msg);
}

void print(string msg)
{
   for (int inxScreen = 0; inxScreen < textPanels.Count; ++inxScreen)
   {
      if (textPanels[inxScreen].CustomName.Contains(ICS_TEXTPANEL))
      {
         IMyTextPanel screen = textPanels[inxScreen] as IMyTextPanel;
         screen.WritePublicText(msg);
         screen.ShowTextureOnScreen();
         screen.ShowPublicTextOnScreen();
      }
   }
}