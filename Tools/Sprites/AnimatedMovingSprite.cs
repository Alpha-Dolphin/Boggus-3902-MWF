using LOZ.Tools.PlayerObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902_Sprint0.Sprites
{
    public class AnimatedMovingSprite : ISprite
    {
        public Texture2D picture;

        public List<Rectangle> frames;

        public int x;
        public int y;

        private static int currentFrame = 0;

        public AnimatedMovingSprite(Texture2D picture, int x, int y, List<Rectangle> frames)
        {
            this.picture = picture;
            this.x = x;
            this.y = y;
            this.frames = frames;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle currentRectangle = frames[currentFrame / 10];
            spriteBatch.Draw(picture, new Rectangle(x, y, currentRectangle.Width*3, currentRectangle.Height*3), currentRectangle, Link_Constants.DEFAULT_PICTURE_COLOR);
        }

        public void Update(int x, int y)
        {
            //Animate the sprite
            currentFrame++;
            if (currentFrame >= frames.Count * 10) currentFrame -= frames.Count * 10;

            //Move the sprite
            this.x = x;
            this.y = y;
        }
    }
}
