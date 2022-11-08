using LOZ.Tools.ItemObjects;
using LOZ.Tools.NPCObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Threading;
using LOZ.Tools.EnvironmentObjects.Helpers;
using LOZ.Tools.EnvironmentObjects;
using LOZ.Tools.GateObjects.Helpers;

namespace LOZ.Tools.LevelManager
{
    public class LevelManager
    {
        /*Location data for level files*/
        string levelFileLocation { get; set; }

        public List<Room> RoomList { get; set; } = new();

        /*Initialize needed object factories*/
        EnvironmentFactory environmentFactory = new EnvironmentFactory();
        EnemySpriteFactory enemySpriteFactory = new EnemySpriteFactory();
        NPCFactory npcFactory = new NPCFactory(0, Game1.NPC_SPRITESHEET);
        ItemFactory itemFactory = new ItemFactory(Game1.ITEM_SPRITESHEET);
        GateFactory gateFactory = new GateFactory();


        /*Function to initialize level data structure and fill it in*/
        public void initialize()
        {
            string path = "../../../Levels/Level_1.xml";
            levelFileLocation = path;
            /*Check for proper file location*/
            if (levelFileLocation == null) 
            {
                throw new InvalidOperationException("Level failed to load: Level file location NULL");
            }

            /*Load xml document*/
            XmlDocument xmlLevelDoc = new XmlDocument();
            xmlLevelDoc.Load(levelFileLocation);
            XmlNode xmlRoot = xmlLevelDoc.LastChild;
            XmlNode xmlLevel = xmlRoot.LastChild;

            Debug.WriteLine("Starting to document xml");


            foreach (XmlNode room in xmlLevel.ChildNodes)
            {
                if (room.NodeType != XmlNodeType.Comment)
                {
                    /*Load a new room object from the info in each room element*/
                    Room thisRoom = new Room();
                    fillRoom(thisRoom, room);

                    /*Add the new room to the room list*/
                    RoomList.Add(thisRoom);
                }
            }

        
        }
        /*Takes a room object and the xml element describing what is in a room and fills out the room object from the xml*/
        private void fillRoom(Room room, XmlNode xmlRoom)
        {
            /*Fill in room number*/
            room.roomNumber = int.Parse(xmlRoom.Attributes?["num"]?.Value);
            room.SetTextures();
            
            /*Fill in border*/
            room.border = bool.Parse(xmlRoom.SelectSingleNode("border").InnerText);

            /*Fill in template*/
            if (bool.Parse(xmlRoom.SelectSingleNode("background").Attributes?["draw"]?.Value))
            {
                room.template = xmlRoom.SelectSingleNode("background").Attributes?["template"]?.Value;
            }
            /*Fill in barrier list*/
            foreach(XmlNode barrier in xmlRoom.SelectSingleNode("barriers").ChildNodes)
            {
                if (barrier.NodeType != XmlNodeType.Comment)
                {
                    /*get rectangles from barrier elements*/
                    room.environmentList.Add(getBarrierObject(barrier));
                }
            }
            /*Fill in environment object list*/
            foreach (XmlNode tile in xmlRoom.SelectSingleNode("environment").ChildNodes)
            {
                if (tile.NodeType != XmlNodeType.Comment)
                {
                    /*get environment objects from tile elements*/
                    room.environmentList.Add(getEnvironmentObject(tile));
                }
            }
            /*Fill in enemy object list*/
            foreach (XmlNode enemy in xmlRoom.SelectSingleNode("enemies").ChildNodes)
            {
                if (enemy.NodeType != XmlNodeType.Comment)
                {
                    /*get enemy objects from enemy elements*/
                    room.enemyList.Add(getEnemyObject(enemy));
                }
            }

            /*Fill in NPC object list*/
            foreach (XmlNode NPC in xmlRoom.SelectSingleNode("NPCs").ChildNodes)
            {
                if (NPC.NodeType != XmlNodeType.Comment)
                {
                    /*get NPC objects from NPC elements*/
                    room.NPCList.Add(getNPCObject(NPC));
                }
            }

            /*Fill in item object list*/
            foreach (XmlNode item in xmlRoom.SelectSingleNode("items").ChildNodes)
            {
                if (item.NodeType != XmlNodeType.Comment)
                {
                    /*get item objects from item elements*/
                    room.itemList.Add(getItemObject(item));
                }
            }

            /*Fill in gate list*/
            foreach (XmlNode gate in xmlRoom.SelectSingleNode("gates").ChildNodes)
            {
                if (gate.NodeType != XmlNodeType.Comment)
                {
                    /*get gate objects from gate elements*/
                    room.gateList.Add(getGateObject(gate));
                }
            }

            /*Assign neighbors*/
            getNeighbors(room,xmlRoom.SelectSingleNode("neighbors"));
            
        }


        /*Helper functions*/
        private IEnvironment getBarrierObject(XmlNode xmlBarrier)
        {
            int x = int.Parse(xmlBarrier.SelectSingleNode("xPlacement").InnerText);
            int y = int.Parse(xmlBarrier.SelectSingleNode("yPlacement").InnerText);
            int width = int.Parse(xmlBarrier.SelectSingleNode("width").InnerText);
            int height = int.Parse(xmlBarrier.SelectSingleNode("height").InnerText);

            IEnvironment thisBarrier = environmentFactory.getEnvironment(Environment.InvisibleBarrier);
            thisBarrier.SetPlacement(x, y);
            Rectangle hurtBox = new Rectangle(x, y, width, height);
            thisBarrier.SetHurtbox(hurtBox);

            return thisBarrier;
        }
        private IEnvironment getEnvironmentObject(XmlNode xmlTile)
        {
            int xPlacement = int.Parse(xmlTile.SelectSingleNode("xPlacement").InnerText);
            int yPlacement = int.Parse(xmlTile.SelectSingleNode("yPlacement").InnerText);
            string type = xmlTile.Attributes?["type"]?.Value;

            IEnvironment thisTile = environmentFactory.getEnvironment((Environment)Enum.Parse(typeof(Environment), type));

            thisTile.SetPlacement(xPlacement, yPlacement);
            return thisTile;
        }
        private IEnemy getEnemyObject(XmlNode xmlEnemy)
        {
            int xPlacement = int.Parse(xmlEnemy.SelectSingleNode("xPlacement").InnerText);
            int yPlacement = int.Parse(xmlEnemy.SelectSingleNode("yPlacement").InnerText);
            string type = xmlEnemy.Attributes?["type"]?.Value;
            enemySpriteFactory.curr = (int)Enum.Parse(typeof(Enemy), type);

            IEnemy thisEnemy = enemySpriteFactory.NewEnemy();

            thisEnemy.SetHurtbox(new Rectangle(xPlacement,yPlacement, -1, -1));
            return thisEnemy;
        }
        private INPC getNPCObject(XmlNode xmlNPC)
        {
            int xPlacement = int.Parse(xmlNPC.SelectSingleNode("xPlacement").InnerText);
            int yPlacement = int.Parse(xmlNPC.SelectSingleNode("yPlacement").InnerText);
            string type = xmlNPC.Attributes?["type"]?.Value;

            INPC thisNPC = npcFactory.CreateNPC((NPC)Enum.Parse(typeof(NPC), type));

            thisNPC.SetPlacement(xPlacement, yPlacement);

            return thisNPC;
        }
        private IItem getItemObject(XmlNode xmlItem)
        {
            int xPlacement = int.Parse(xmlItem.SelectSingleNode("xPlacement").InnerText);
            int yPlacement = int.Parse(xmlItem.SelectSingleNode("yPlacement").InnerText);
            string type = xmlItem.Attributes?["type"]?.Value;

            return itemFactory.CreateItem((Item)Enum.Parse(typeof(Item), type), xPlacement, yPlacement);
        }
        private IGate getGateObject(XmlNode xmlGate)
        {
            string type = xmlGate.Attributes?["type"]?.Value;

            return gateFactory.getGate((Gate)Enum.Parse(typeof(Gate), type));
        }

        private void getNeighbors(Room room, XmlNode xmlNeigbors)
        {
            int parseHolder;
            if (int.TryParse(xmlNeigbors.SelectSingleNode("north").Attributes["id"].Value,out parseHolder))
            {
                room.northNeighbor = parseHolder;
            }
            if (int.TryParse(xmlNeigbors.SelectSingleNode("south").Attributes["id"].Value, out parseHolder))
            {
                room.southNeighbor = parseHolder;
            }
            if (int.TryParse(xmlNeigbors.SelectSingleNode("east").Attributes["id"].Value, out parseHolder))
            {
                room.eastNeighbor = parseHolder;
            }
            if (int.TryParse(xmlNeigbors.SelectSingleNode("west").Attributes["id"].Value, out parseHolder))
            {
                room.westNeighbor = parseHolder;
            }
        }

    }
}
