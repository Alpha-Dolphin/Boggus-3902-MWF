using LOZ.Tools.EnvironmentObjects.Helpers;
using Microsoft.Xna.Framework.Graphics;using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.Sprites;

namespace LOZ.Tools.EnvironmentObjects
{
    internal class PushBlock : IEnvironment
    {
        private Sprite enviroSprite;
        private int xPosition = Constants.enviroDefaultX;
        private int yPosition = Constants.enviroDefaultY;
        public void SetPlacement(int x, int y)
        {
            enviroSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, x, y, new List<Rectangle>() { new Rectangle(1001, 11, 16, 16) });
            xPosition = x;
            yPosition = y;
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            enviroSprite.Draw(spriteBatch);
        }
        public Rectangle GetHurtbox()
        {
            return new Rectangle(enviroSprite.x, enviroSprite.y, enviroSprite.width, enviroSprite.height);
        }
        public void SetHurtbox(Rectangle rect)
        {
            this.xPosition = rect.X;
            this.yPosition = rect.Y;
            enviroSprite.Update(rect.X, rect.Y);
        }
    }
}
