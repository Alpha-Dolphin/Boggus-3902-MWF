﻿using Microsoft.Xna.Framework;
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
using LOZ.Tools.HUDObjects;

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
        public int northNeighbor { get; set; } = 0;
        public int southNeighbor { get; set; } = 0;
        public int westNeighbor { get; set; } = 0;
        public int eastNeighbor { get; set; } = 0;
        public int roomNumber { get; set; } = 0;
        public bool border { get; set; }
        public string template { get; set; }/*template is null if there is no template*/

        public void SetTextures()
        {
            this.RoomInterior = new Sprite(texture, EnvironmentConstants.EXTERIOR_WIDTH,
            EnvironmentConstants.EXTERIOR_WIDTH + HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale, new List<Rectangle>() { EnvironmentConstants.ROOM_EMPTY_BACKGROUND });
            if(this.roomNumber == 7)
            {
                this.RoomInterior = new Sprite(texture, EnvironmentConstants.EXTERIOR_WIDTH,
                EnvironmentConstants.EXTERIOR_WIDTH + HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale, new List<Rectangle>() { EnvironmentConstants.ROOMS[7] });
            }
            this.RoomExterior = new Sprite(texture, 0, HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale, new List<Rectangle>() { EnvironmentConstants.ROOM_EXTERIOR });
            this.Doors = new Sprite[4];

            for (int i = 0; i < Doors.Length; i++)
            {
                SetDoorType(EnvironmentConstants.ROOM_DOORS[roomNumber][i], i);
            }

            FixCoordinates();
        }

        private void SetDoorType(EnvironmentConstants.DoorType doorType, int side)
        {
            switch (doorType)
            {
                case EnvironmentConstants.DoorType.Wall: SetDoorLocation(new Sprite(texture, 0, HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale, new List<Rectangle>() { EnvironmentConstants.DOOR_WALL[side] }), side); break;
                case EnvironmentConstants.DoorType.Open: SetDoorLocation(new Sprite(texture, 0, HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale, new List<Rectangle>() { EnvironmentConstants.DOOR_OPEN[side] }), side); break;
                case EnvironmentConstants.DoorType.Locked: SetDoorLocation(new Sprite(texture, 0, HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale, new List<Rectangle>() { EnvironmentConstants.DOOR_LOCKED[side] }), side); break;
                case EnvironmentConstants.DoorType.Closed: SetDoorLocation(new Sprite(texture, 0, HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale, new List<Rectangle>() { EnvironmentConstants.DOOR_CLOSED[side] }), side); break;
                case EnvironmentConstants.DoorType.Hole: SetDoorLocation(new Sprite(texture, 0, HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale, new List<Rectangle>() { EnvironmentConstants.DOOR_HOLE[side] }), side); break;
            }
        }

        private void SetDoorLocation(Sprite doorSprite, int side)
        {
            switch (side)
            {
                case 0: this.Doors[side] = doorSprite.SetPosition(EnvironmentConstants.ROOM_EXTERIOR.Width / 2 - EnvironmentConstants.DOOR_WIDTH / 2, HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale); break;
                case 1: this.Doors[side] = doorSprite.SetPosition(0, EnvironmentConstants.ROOM_EXTERIOR.Height / 2 - EnvironmentConstants.DOOR_WIDTH / 2 + HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale); break;
                case 2: this.Doors[side] = doorSprite.SetPosition(EnvironmentConstants.ROOM_EXTERIOR.Width - EnvironmentConstants.DOOR_WIDTH,
                    EnvironmentConstants.ROOM_EXTERIOR.Height / 2 - EnvironmentConstants.DOOR_WIDTH / 2 + HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale); break;
                case 3: this.Doors[side] = doorSprite.SetPosition(EnvironmentConstants.ROOM_EXTERIOR.Width / 2 - EnvironmentConstants.DOOR_WIDTH / 2, 
                    EnvironmentConstants.ROOM_EXTERIOR.Height - EnvironmentConstants.DOOR_WIDTH + HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale); break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (roomNumber > 1)
            {
                this.RoomExterior.Draw(spriteBatch);
                foreach (Sprite door in Doors)
                {
                    door.Draw(spriteBatch);
                }
            }
            if (roomNumber == 1)
            {
                int tempX = Sprite.xScale;
                int tempY = Sprite.yScale;
                Sprite.xScale = EnvironmentConstants.SCREEN_WIDTH / this.RoomInterior.width;
                Sprite.yScale = EnvironmentConstants.SCREEN_HEIGHT / this.RoomInterior.height;
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

        private void FixCoordinates()
        {
            foreach (IEnemy enemy in enemyList)
            {
                Rectangle currentPlacement = enemy.GetHurtbox();
                enemy.SetHurtbox(new Rectangle(currentPlacement.X, currentPlacement.Y + HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale, currentPlacement.Width, currentPlacement.Height));
            }
            foreach (INPC npc in NPCList)
            {
                Vector2 currentPosition = npc.GetPosition();
                npc.SetPlacement((int)currentPosition.X, (int)currentPosition.Y + HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale);
            }
            foreach (IItem item in itemList)
            {
                Vector2 currentPosition = item.GetPosition();
                item.SetPlacement((int)currentPosition.X, (int)currentPosition.Y + HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale);
            }
            foreach (IEnvironment environment in environmentList)
            {
                Rectangle currentPlacement = environment.GetHurtbox();
                environment.SetHurtbox(new Rectangle(currentPlacement.X, currentPlacement.Y + HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale, currentPlacement.Width, currentPlacement.Height));
            }
            foreach (Rectangle barrier in barrierList)
            {
                barrier.Offset(0, HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale);
            }
        }
    }
}
