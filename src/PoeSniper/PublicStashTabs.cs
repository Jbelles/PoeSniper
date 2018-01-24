using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoESniper
{
    #region Public Stash Tabs
    public class PublicStashTabs
    {
        public string next_change_id { get; set; }
        public List<StashTab> stashes { get; set; }
    }
    #endregion
    #region StashTab
    public class StashTab
    {
        public string accountName { get; set; }     //account name the stash linked to 
        public string lastCharacterName { get; set; }  //last character name of the player   
        public string id { get; set; } //unique stash id
        public string stash { get; set; }  //stash name 
        public string stashType { get; set; }  //NormalStash/PremiumStash/QuadStash/EssenceStash/CurrencyStash(DivinationStash?)  
        public List<Items> items { get; set; }   //See below, items included in this stash 
        public bool Public { get; set; }//public or not  
    }
    #endregion
    #region Items
    public class Items
    {
        public bool verified { get; set; } //boolean value of whether item has been verified
        public int w { get; set; } //slot width
        public int h { get; set; } //slot height
        public int ilvl { get; set; } //item level
        public string icon { get; set; } //item picture art
        public string league { get; set; } //Standard/Hardcore/Legacy/Hardcore Legacy
        public string id { get; set; } //item id, will change if you use currency on it
        public List<Sockets> sockets { get; set; } //See below, array of sockets
        public string name { get; set; } //unique name
        public string typeLine { get; set; } //item base type, mixed with affix name for magic/rare
        public bool identified { get; set; } // boolean value of whether the item is identified
        public bool corrupted { get; set; } //boolean value of whether the item is corrupted
        public bool lockedToCharacter { get; set; } //boolean, non tradeable
        public string note { get; set; } 
        public List<Properties> properties { get; set; } //see below
        public List<Requirements> requirements { get; set; } //see below
        public List<string> explicitMods { get; set; } //list of explicit mods
        public List<string> implicitMods { get; set; } //list of implicit mods
        public List<string> enchantMods { get; set; } //list of enchanted mods
        public List<string> craftedMods { get; set; } //list of crafted mods (master)
        public List<string> flavourText { get; set; } 
        public FrameType frameType { get; set; } //see frameType enum below
        public int x { get; set; } //stash position x
        public int y { get; set; } //stash position y
        public string inventoryId { get; set; } 
        public List<Items> socketedItems { get; set; } //list of socketed items
        public List<Properties> additionalProperties { get; set; } //see properties
        public string secDescrText { get; set; } //second description text
        public string descrText { get; set; } //description text
        public string artFilename { get; set; } //div card art
        public bool duplicated { get; set; } 
        public int maxStackSize { get; set; }
        public List<Requirements> nextLevelRequirements { get; set; } //see requirements
        public int talismanTier { get; set; }
        public List<string> utilityMods { get; set; } //flask utility mods
        public bool support { get; set; }
        public List<string> cosmeticMods { get; set; }
        public List<string> prophecyDiffText { get; set; }//prophecy difficulty text
        public bool isRelic { get; set; }
    }
    #endregion
    #region Sockets
    public class Sockets
    {
        public int group { get; set; }
        public string attr { get; set; }
    }
    #endregion
    #region Properties
    public class Properties
    {
        public string name { get; set; }
        public List<string> values { get; set; }
        public int displayMode { get; set; }
        public int progress { get; set; }
    }
    #endregion
    #region Requirements
    public class Requirements
    {
        public string name { get; set; }
        public List<string> values { get; set; }
        public int displayMode { get; set; }
        public int progress { get; set; }
    }
    #endregion

    #region FrameType
    public enum FrameType
    {
        normal,
        magic,
        rare,
        unique,
        gem,
        currency,
        divinationCard,
        questItem,
        prophecy,
        relic
    }
    #endregion
}
