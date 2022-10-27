using LOZ.Tools.EnvironmentObjects.Helpers;
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
    internal class InvisibleBarrier : IEnvironment
    {
        
        private int xPosition = Constants.enviroDefaultX;
        private int yPosition = Constants.enviroDefaultY;
        private int width;
        private int height;
        public void SetPlacement(int x, int y)
        {
            xPosition = x;
            yPosition = y;
        }
        public Rectangle GetHurtbox()
        {
            return new Rectangle(xPosition, yPosition, width, height );
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            ;
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
        }
    }
}