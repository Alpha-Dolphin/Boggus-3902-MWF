﻿using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LOZ.Tools.GateObjects
{
    internal class EastWall : IGate
    {
        private static int xPosition = 224;
        private static int yPosition = 72;
        private Direction direction = Direction.East;
        private bool doorOpen = false;
        private Sprite closedSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, xPosition, yPosition, new List<Rectangle>() { new Rectangle(815, 77, 32, 32) });
        private Sprite openSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, xPosition, yPosition, new List<Rectangle>() { new Rectangle(815, 77, 32, 32) });
        public void Open()
        {

        }
        public void Close()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (doorOpen)
            {
                openSprite.Draw(spriteBatch);
            }
            else
            {
                closedSprite.Draw(spriteBatch);
            }

        }

        public Rectangle GetHurtbox()
        {
            return new Rectangle(xPosition, yPosition, 32, 32);
        }

        public void SetHurtbox(Rectangle rect)
        {
            EastWall.xPosition = rect.X;
            EastWall.yPosition = rect.Y;
            closedSprite.Update(rect.X, rect.Y);
            openSprite.Update(rect.X, rect.Y);
        }
        public Direction GetDirection()
        {
            return direction;
        }
        public bool IsGateOpen()
        {
            return doorOpen;
        }
    }
}