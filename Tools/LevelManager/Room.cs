using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.NPCObjects;
using LOZ.Tools.ItemObjects;
using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.Tools.LevelManager
{
    internal class Room
    {
        private Texture2D texture = Game1.ENVIRONMENT_SPRITESHEET;

        private Sprite RoomExterior;
        private Sprite[] Doors;
        private Sprite RoomInterior;

        /*Lists of things in room*/
        public List<Rectangle> barrierList { get; set; } = new List<Rectangle>();
        public List<IEnvironment> environmentList { get; set; } = new List<IEnvironment> ();
        public List<IEnemy> enemyList { get; set; } = new List<IEnemy>();
        public List<INPC> NPCList { get; set; } = new List<INPC>();
        public List<IItem> itemList { get; set; } = new List<IItem>();
        public int northNeighbor { get; set; } = 0;
        public int southNeighbor { get; set; } = 0;
        public int westNeighbor { get; set; } = 0;
        public int eastNeighbor { get; set; } = 0;
        public int roomNumber { get; set; } = 0;
        public bool border { get; set; }
        public string template { get; set; }/*template is null if there is no template*/

        public void SetTextures(BackgroundConstants.DoorType[] DoorTypes)
        {
            this.RoomExterior = new Sprite(texture, 0, 0, new List<Rectangle>() { BackgroundConstants.ROOM_EXTERIOR });
            this.RoomInterior = new Sprite(texture, BackgroundConstants.EXTERIOR_WIDTH, 
                BackgroundConstants.EXTERIOR_WIDTH, new List<Rectangle>() { BackgroundConstants.ROOMS[roomNumber - 1] });
            this.Doors = new Sprite[4];

            for(int i = 0; i < Doors.Length; i++)
            {
                SetDoorType(DoorTypes[i], i);
            }
        }

        private void SetDoorType(BackgroundConstants.DoorType doorType, int side)
        {
            switch (doorType)
            {
                case BackgroundConstants.DoorType.Wall: SetDoorLocation(new Sprite(texture, 0, 0, new List<Rectangle>() { BackgroundConstants.DOOR_WALL[side] }), side); break;
                case BackgroundConstants.DoorType.Open: SetDoorLocation(new Sprite(texture, 0, 0, new List<Rectangle>() { BackgroundConstants.DOOR_OPEN[side] }), side); break;
                case BackgroundConstants.DoorType.Locked: SetDoorLocation(new Sprite(texture, 0, 0, new List<Rectangle>() { BackgroundConstants.DOOR_LOCKED[side] }), side); break;
                case BackgroundConstants.DoorType.Closed: SetDoorLocation(new Sprite(texture, 0, 0, new List<Rectangle>() { BackgroundConstants.DOOR_CLOSED[side] }), side); break;
                case BackgroundConstants.DoorType.Hole: SetDoorLocation(new Sprite(texture, 0, 0, new List<Rectangle>() { BackgroundConstants.DOOR_HOLE[side] }), side); break;
            }
        }

        private void SetDoorLocation(Sprite doorSprite, int side)
        {
            switch (side)
            {
                case 0: this.Doors[side] = doorSprite.SetPosition(BackgroundConstants.ROOM_EXTERIOR.Width / 2 - BackgroundConstants.DOOR_WIDTH / 2, 0); break;
                case 1: this.Doors[side] = doorSprite.SetPosition(0, BackgroundConstants.ROOM_EXTERIOR.Height / 2 - BackgroundConstants.DOOR_WIDTH / 2); break;
                case 2: this.Doors[side] = doorSprite.SetPosition(BackgroundConstants.ROOM_EXTERIOR.Width - BackgroundConstants.DOOR_WIDTH,
                    BackgroundConstants.ROOM_EXTERIOR.Height / 2 - BackgroundConstants.DOOR_WIDTH / 2); break;
                case 3: this.Doors[side] = doorSprite.SetPosition(BackgroundConstants.ROOM_EXTERIOR.Width / 2 - BackgroundConstants.DOOR_WIDTH / 2, 
                    BackgroundConstants.ROOM_EXTERIOR.Height - BackgroundConstants.DOOR_WIDTH); break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.RoomExterior.Draw(spriteBatch);
            this.RoomInterior.Draw(spriteBatch);
            foreach (Sprite door in Doors)
            {
                door.Draw(spriteBatch);
            }
            foreach (IEnvironment environment in environmentList)
            {
                environment.Draw(spriteBatch);
            }
            foreach (IEnemy enemy in enemyList)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (INPC npc in NPCList)
            {
                npc.Draw(spriteBatch);
            }
            foreach (IItem item in itemList)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
