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
using LOZ.Tools.Interfaces;


namespace LOZ.Tools.LevelManager
{
    internal class LevelManager
    {
        /*Location data for level files*/
        string levelFileLocation { get; set; }

        List<Room> roomList { get; set; }

        /*Initialize needed object factories*/
        EnvironmentFactory environmentFactory = new EnvironmentFactory();
        EnemySpriteFactory enemySpriteFactory = new EnemySpriteFactory();
        NPCFactory npcFactory = new NPCFactory(0, Game1.NPC_SPRITESHEET);
        ItemFactory itemFactory = new ItemFactory(Game1.ITEM_SPRITESHEET);


        /*Function to initialize level data structure and fill it in*/
        public void initialize()
        {
            /*Check for proper file location*/
            if (levelFileLocation == null) 
            {
                throw new InvalidOperationException("Level failed to load: Level file location NULL");
            }

            /*Load xml document*/
            XmlDocument xmlLevel = new XmlDocument();
            xmlLevel.LoadXml(levelFileLocation);
            
            foreach(XmlNode room in xmlLevel.DocumentElement.ChildNodes)
            {
                /*Load a new room object from the info in each room element*/
                Room thisRoom = new Room();
                fillRoom(thisRoom, room);

                /*Add the new room to the room list*/
                roomList.Add(thisRoom);
            }

        
        }
        /*Takes a room object and the xml element describing what is in a room and fills out the room object from the xml*/
        private void fillRoom(Room room, XmlNode xmlRoom)
        {
           

            /*Fill in room number*/
            room.roomNumber = int.Parse(xmlRoom.Attributes?["num"]?.Value);
            /*Fill in border*/
            room.border = bool.Parse(xmlRoom.SelectSingleNode("/border").InnerText);

            /*Fill in template*/
            if (bool.Parse(xmlRoom.SelectSingleNode("/background").Attributes?["draw"]?.Value))
            {
                room.template = xmlRoom.SelectSingleNode("/background").Attributes?["template"]?.Value;
            }
            /*Fill in barrier list*/
            foreach(XmlNode barrier in xmlRoom.SelectSingleNode("/barriers").ChildNodes)
            {
                /*get rectangles from barrier elements*/
                room.barrierList.Add(getBarrierRectangle(barrier));
            }
            /*Fill in environment object list*/
            foreach (XmlNode tile in xmlRoom.SelectSingleNode("/environment").ChildNodes)
            {
                /*get environment objects from tile elements*/
                room.environmentList.Add(getEnvironmentObject(tile));
            }
            /*Fill in enemy object list*/
            foreach (XmlNode enemy in xmlRoom.SelectSingleNode("/enemies").ChildNodes)
            {
                /*get enemy objects from enemy elements*/
                room.enemyList.Add(getEnemyObject(enemy));
            }

            /*Fill in NPC object list*/
            foreach (XmlNode NPC in xmlRoom.SelectSingleNode("/NPCs").ChildNodes)
            {
                /*get enemy objects from enemy elements*/
                room.NPCList.Add(getNPCObject(NPC));
            }

            /*Fill in item object list*/
            foreach (XmlNode item in xmlRoom.SelectSingleNode("/items").ChildNodes)
            {
                /*get enemy objects from enemy elements*/
                room.itemList.Add(getItemObject(item));
            }

            /*Assign neighbors*/
            room.northNeighbor = int.Parse(xmlRoom.SelectSingleNode("/neighbors/north").Attributes["id"].Value);
            room.southNeighbor = int.Parse(xmlRoom.SelectSingleNode("/neighbors/south").Attributes["id"].Value);
            room.eastNeighbor = int.Parse(xmlRoom.SelectSingleNode("/neighbors/east").Attributes["id"].Value);
            room.westNeighbor = int.Parse(xmlRoom.SelectSingleNode("/neighbors/west").Attributes["id"].Value);
        }


        /*Helper functions*/
        private Rectangle getBarrierRectangle(XmlNode xmlBarrier)
        {
            int x = int.Parse(xmlBarrier.SelectSingleNode("/xPlacement").InnerText);
            int y = int.Parse(xmlBarrier.SelectSingleNode("/yPlacement").InnerText);
            int width = int.Parse(xmlBarrier.SelectSingleNode("/width").InnerText);
            int height = int.Parse(xmlBarrier.SelectSingleNode("/height").InnerText);

            return new Rectangle(x, y, width, height);
        }
        private IEnvironment getEnvironmentObject(XmlNode xmlTile)
        {
            int xPlacement = int.Parse(xmlTile.SelectSingleNode("/xPlacement").InnerText);
            int yPlacement = int.Parse(xmlTile.SelectSingleNode("/yPlacement").InnerText);
            string type = xmlTile.Attributes?["type"]?.Value;

            IEnvironment thisTile = environmentFactory.getEnvironment((Environment)Enum.Parse(typeof(Environment), type);

            thisTile.setPlacement(xPlacement, yPlacement);

            return thisTile;
        }
        private IEnemy getEnemyObject(XmlNode xmlEnemy)
        {
            int xPlacement = int.Parse(xmlEnemy.SelectSingleNode("/xPlacement").InnerText);
            int yPlacement = int.Parse(xmlEnemy.SelectSingleNode("/yPlacement").InnerText);
            string type = xmlEnemy.Attributes?["type"]?.Value;
            enemySpriteFactory.curr = (int)Enum.Parse(typeof(Enemy), type);

            IEnemy thisEnemy = enemySpriteFactory.NewEnemy();

            thisEnemy.setPosition(xPlacement,yPlacement);

            return thisEnemy;
        }
        private INPC getNPCObject(XmlNode xmlNPC)
        {
            int xPlacement = int.Parse(xmlNPC.SelectSingleNode("/xPlacement").InnerText);
            int yPlacement = int.Parse(xmlNPC.SelectSingleNode("/yPlacement").InnerText);
            string type = xmlNPC.Attributes?["type"]?.Value;

            INPC thisNPC = npcFactory.CreateNPC((NPC)Enum.Parse(typeof(NPC), type));

            thisNPC.setPlacement(xPlacement, yPlacement);

            return thisNPC;
        }
        private IItem getItemObject(XmlNode xmlItem)
        {
            int xPlacement = int.Parse(xmlItem.SelectSingleNode("/xPlacement").InnerText);
            int yPlacement = int.Parse(xmlItem.SelectSingleNode("/yPlacement").InnerText);
            string type = xmlItem.Attributes?["type"]?.Value;

            return itemFactory.CreateItem((Item)Enum.Parse(typeof(NPC), type),xPlacement,yPlacement);
        }

    }
}
