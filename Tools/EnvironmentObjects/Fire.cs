﻿using LOZ.Tools.EnvironmentObjects.Helpers;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.EnvironmentObjects
{
    internal class Fire : IEnvironment
    {
        private EnviroSprite enviroSprite = new EnviroSprite();

        /*Update must be called at least once before drawing*/
        public void draw(SpriteBatch spriteBatch)
        {
            enviroSprite.Draw(spriteBatch);
        }
        /*Sets the source and location rectangles*/
        public void update()
        {

            enviroSprite.setFrameRectangle(52, 11, 16, 16);

            enviroSprite.setPositionRectangle(Constants.enviroDefaultX, Constants.enviroDefaultY, 16 * Constants.objectScale, 16 * Constants.objectScale);
        }
        public void load()
        {
            enviroSprite.loadSpriteSheet(Game1.NPC_SPRITESHEET);
        }
    }
}