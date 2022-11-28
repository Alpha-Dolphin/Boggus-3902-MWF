using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using LOZ.Tools.Sprites;
using LOZ.Tools.Interfaces;

namespace LOZ.Tools.EnvironmentObjects
{
    internal class InvisibleBarrier : IEnvironment
    {
        private Sprite enviroSprite;
        private int xPosition = Constants.enviroDefaultX;
        private int yPosition = Constants.enviroDefaultY;
        private int width;
        private int height;
        public void SetPlacement(int x, int y)
        {
            enviroSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, x, y, new List<Rectangle>() { new Rectangle(782, 110, 32, 32) });
            xPosition = x;
            yPosition = y;
            
        }
        public Rectangle GetHurtbox()
        {
            return new Rectangle(xPosition, yPosition, width, height );
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (Constants.DEBUG)
            {
                enviroSprite.width = width;
                enviroSprite.height = height;
                enviroSprite.Draw(spriteBatch);
            }
        }
        /*Sets the source and location rectangles*/
        public void Update()
        {
        }
        public void Load()
        {
        }

        public void SetHurtbox(Rectangle rect)
        {
            xPosition = rect.X;
            yPosition = rect.Y;
            width = rect.Width;
            height = rect.Height;
            enviroSprite.Update(xPosition, yPosition);
        }
    }
}