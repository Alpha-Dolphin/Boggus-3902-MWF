using LOZ.Tools.EnvironmentObjects.Helpers;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.EnvironmentObjects
{
    internal class WalkableBlueGap : IEnvironment
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

            enviroSprite.setFrameRectangle(1018, 28, 16, 16);

            enviroSprite.setPositionRectangle(xPosition, yPosition, 16 * Constants.objectScale, 16 * Constants.objectScale);
        }
        public void load()
        {
            enviroSprite.loadSpriteSheet(Game1.ENVIRONMENT_SPRITESHEET);
        }
    }
}
