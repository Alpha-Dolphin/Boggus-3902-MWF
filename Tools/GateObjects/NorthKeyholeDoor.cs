﻿using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.GateObjects
{
    internal class NorthKeyholeDoor : IGate
    {
        private static int xPosition = 112;
        private static int yPosition = 0;
        private Direction direction = Direction.North;
        private bool doorOpen = false;
        private Sprite closedSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, xPosition, yPosition, new List<Rectangle>() { new Rectangle(881, 11, 32, 32) });
        private Sprite openSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, xPosition, yPosition, new List<Rectangle>() { new Rectangle(848, 11, 32, 32) });
        public void Open()
        {
            doorOpen = true;
        }
        public void Close()
        {
            doorOpen = false;
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
            NorthKeyholeDoor.xPosition = rect.X;
            NorthKeyholeDoor.yPosition = rect.Y;
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
