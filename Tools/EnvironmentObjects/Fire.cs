using LOZ.Tools.EnvironmentObjects.Helpers;
using Microsoft.Xna.Framework.Graphics;using Microsoft.Xna.Framework;
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
        private int xPosition = Constants.enviroDefaultX;
        private int yPosition = Constants.enviroDefaultY;
        public void SetPlacement(int x, int y)
        {
            xPosition = x;
            yPosition = y;
        }

        /*Update must be called at least once before drawing*/
        public void Draw(SpriteBatch spriteBatch)
        {
            enviroSprite.Draw(spriteBatch);
        }
        /*Sets the source and location rectangles*/
        public void Update()
        {

            enviroSprite.setFrameRectangle(52, 11, 16, 16);

            enviroSprite.setPositionRectangle(xPosition, yPosition, 16 * Constants.objectScale, 16 * Constants.objectScale);
        }
        public void Load()
        {
            enviroSprite.loadSpriteSheet(Game1.NPC_SPRITESHEET);
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(enviroSprite.positionX, enviroSprite.positionY, enviroSprite.width, enviroSprite.height);
        }
    }
}
