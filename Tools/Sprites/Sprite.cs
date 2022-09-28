using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LOZ.Tools.PlayerObjects;

namespace CSE3902_Sprint0.Sprites
{
    public class Sprite : ISprite
    {
        public Texture2D picture;

        public Rectangle frame;

        public int x;
        public int y;

        private int currentFrame = 0;

        public Sprite(Texture2D picture, int x, int y, List<Rectangle> frames)
        {
            this.picture = picture;
            this.x = x;
            this.y = y;
            this.frame = frames[0];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(picture, new Rectangle(x, y, frame.Width * 3, frame.Height * 3), frame, Link_Constants.DEFAULT_PICTURE_COLOR);
        }

        public void Update(int x, int y)
        {
            //Do nothing
        }

        public bool finished()
        {
            return true;
        }
    }
}
