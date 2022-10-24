﻿using LOZ.Tools.EnvironmentObjects.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.Sprites;

namespace LOZ.Tools.EnvironmentObjects
{
    internal class BlueFloor : IEnvironment
    {
        private Sprite enviroSprite;
        private int xPosition= Constants.enviroDefaultX;
        private int yPosition= Constants.enviroDefaultY;
        public void SetPlacement(int x, int y)
        {
            enviroSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, x, y, new List<Rectangle>() { new Rectangle(984, 11, 16, 16) });
            xPosition = x;
            yPosition = y;
        }
        public Rectangle GetHurtbox()
        {
            return new Rectangle(xPosition, yPosition, 16 * Constants.objectScale, 16 * Constants.objectScale);
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            enviroSprite.Draw(spriteBatch);
        }
        /*Sets the source and location rectangles*/
        public void Update()
        {
        }
        public void Load()
        {
        }

        public void SetHurtbox(int x, int y)
        {
        }
    }
}
