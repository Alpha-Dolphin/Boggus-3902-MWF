﻿using LOZ.Tools.EnvironmentObjects.Helpers;
using Microsoft.Xna.Framework.Graphics;using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.EnvironmentObjects
{
    internal class KeyholeLockedDoor:IEnvironment
    {
        private EnviroSprite enviroSprite = new EnviroSprite();
        private int xPosition = Constants.enviroDefaultX;
        private int yPosition = Constants.enviroDefaultY;
        public void setPlacement(int x, int y)
        {
            xPosition = x;
            yPosition = y;
        }

        /*Update must be called at least once before drawing*/
        public void draw(SpriteBatch spriteBatch)
        {
            enviroSprite.Draw(spriteBatch);
        }
        /*Sets the source and location rectangles*/
        public void update()
        {

            enviroSprite.setFrameRectangle(881, 11, 32, 32);

            enviroSprite.setPositionRectangle(xPosition, yPosition, 32 * Constants.objectScale, 32 * Constants.objectScale);
        }
        public void load()
        {
            enviroSprite.loadSpriteSheet(Game1.ENVIRONMENT_SPRITESHEET);
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(enviroSprite.positionX, enviroSprite.positionY, enviroSprite.width, enviroSprite.height);
        }
    }
}
