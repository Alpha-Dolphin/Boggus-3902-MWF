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
using LOZ.Tools.EnvironmentObjects;

namespace LOZ.Tools.LevelManager
{
    public class Room
    {
        private Texture2D texture = Game1.ENVIRONMENT_SPRITESHEET;

        private Sprite RoomExterior;
        private Sprite[] Doors;
        private Sprite RoomInterior;

        /*Lists of things in room*/
        public List<IEnvironment> environmentList { get; set; } = new List<IEnvironment> ();
        public List<IEnemy> enemyList { get; set; } = new List<IEnemy>();
        public List<INPC> NPCList { get; set; } = new List<INPC>();
        public List<IItem> itemList { get; set; } = new List<IItem>();
        public List<IGate> gateList { get; set; } = new List<IGate> ();
        public int northNeighbor { get; set; } = 0;
        public int southNeighbor { get; set; } = 0;
        public int westNeighbor { get; set; } = 0;
        public int eastNeighbor { get; set; } = 0;
        public int roomNumber { get; set; } = 0;
        public bool border { get; set; }
        public string template { get; set; }/*template is null if there is no template*/

        public void SetTextures()
        {
            
            if (roomNumber == 7)
            {
                this.RoomInterior = new Sprite(texture, BackgroundConstants.EXTERIOR_WIDTH,
                BackgroundConstants.EXTERIOR_WIDTH, new List<Rectangle>() { BackgroundConstants.ROOMS[7] });
            }
            else 
            {
                this.RoomInterior = new Sprite(texture, BackgroundConstants.EXTERIOR_WIDTH,
                BackgroundConstants.EXTERIOR_WIDTH, new List<Rectangle>() { new Rectangle(1, 192, 192, 112) }); 
            }
            this.RoomExterior = new Sprite(texture, 0, 0, new List<Rectangle>() { BackgroundConstants.ROOM_EXTERIOR });
            this.Doors = new Sprite[4];

            for (int i = 0; i < Doors.Length; i++)
            {
                SetDoorType(BackgroundConstants.ROOM_DOORS[roomNumber][i], i);
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
            if (roomNumber > 1)
            {
                this.RoomExterior.Draw(spriteBatch);
            }
            if (roomNumber == 1)
            {
                
                    this.RoomInterior = new Sprite(texture, BackgroundConstants.EXTERIOR_WIDTH,
                    BackgroundConstants.EXTERIOR_WIDTH, new List<Rectangle>() { BackgroundConstants.ROOMS[1] });
                
                int tempX = Sprite.xScale;
                int tempY = Sprite.yScale;
                Sprite.xScale = BackgroundConstants.SCREEN_WIDTH / this.RoomInterior.width;
                Sprite.yScale = BackgroundConstants.SCREEN_HEIGHT / this.RoomInterior.height;
                this.RoomInterior.SetPosition(0, 0);
                this.RoomInterior.Draw(spriteBatch);
                Sprite.xScale = tempX;
                Sprite.yScale = tempY;
            }
            else this.RoomInterior.Draw(spriteBatch);

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
            foreach (IGate gate in gateList)
            {
                gate.draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (IEnemy enemy in enemyList)
            {
                enemy.Update(gameTime);
            }
            foreach (INPC npc in NPCList)
            {
                npc.Update(gameTime);
            }
            foreach (IItem item in itemList)
            {
                item.Update(gameTime);
            }
        }
    }
}
