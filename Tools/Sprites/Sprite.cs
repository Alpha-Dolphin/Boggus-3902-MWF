using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using LOZ.Tools.Interfaces;

namespace LOZ.Tools.Sprites
{
    public class Sprite : ISprite
    {
        public Texture2D picture;

        public Rectangle frame;

        public static int xScale { get; set; }
        public static int yScale { get; set; }

        public int x;
        public int y;
        public int width;
        public int height;

        private Color color = Color.White;

        /*private int currentFrame = 0;*/

        public Sprite(Texture2D picture, int x, int y, List<Rectangle> frames)
        {
            this.picture = picture;
            this.x = x;
            this.y = y;
            this.width = frames[0].Width;
            this.height = frames[0].Height;
            this.frame = frames[0];
        }
        public Sprite(Texture2D picture, Rectangle destinationRectangle, List<Rectangle> frames)
        {
            this.picture = picture;
            this.x = destinationRectangle.X;
            this.y = destinationRectangle.Y;
            this.width = destinationRectangle.Width;
            this.height = destinationRectangle.Height;
            this.frame = frames[0];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(picture, new Rectangle(x*xScale, y*yScale, width*xScale, height*yScale), frame, color);
        }

        public void Update(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Sprite SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            return this;
        }

        public bool Finished()
        {
            return true;
        }
        public Rectangle GetDestinationRectangle()
        {
            return new Rectangle(x, y, width, height);
        }
        public Rectangle GetSourceRectangle()
        {
            return this.frame;
        }
        public void SetColor(Color color)
        {
            this.color = color;
        }
    }
}
