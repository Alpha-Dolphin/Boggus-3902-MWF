using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using LOZ.Tools.Sprites;
using LOZ.Tools.Interfaces;

namespace LOZ.Tools.EnvironmentObjects
{
    internal class WhiteBrick : IEnvironment
    {
        private Sprite enviroSprite;
        private int xPosition = Constants.enviroDefaultX;
        private int yPosition = Constants.enviroDefaultY;
        public void SetPlacement(int x, int y)
        {
            enviroSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, x, y, new List<Rectangle>() { new Rectangle(984, 45, 16, 16) });
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
