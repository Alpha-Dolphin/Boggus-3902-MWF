using LOZ.Tools.PlayerObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902_Sprint0.Sprites
{
    public class AnimatedMovingSprite : ISprite
    {
        private Texture2D picture;

        private List<Rectangle> frames;

        private int x;
        private int y;

        private int scale = 3;

        private int framerate = 10;

        private bool finish = false;

        private int currentFrame = 0;

        public AnimatedMovingSprite(Texture2D picture, int x, int y, List<Rectangle> frames)
        {
            this.picture = picture;
            this.x = x;
            this.y = y;
            this.frames = frames;

            if (frames.Count <= 1) finish = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle currentRectangle = frames[currentFrame / framerate];
            spriteBatch.Draw(picture, new Rectangle(x, y, currentRectangle.Width*scale, currentRectangle.Height*scale), currentRectangle, Link_Constants.DEFAULT_PICTURE_COLOR);
        }

        public void Update(int x, int y)
        {
            //Animate the sprite
            currentFrame++;
            if (currentFrame >= frames.Count * framerate)
            {
                currentFrame -= frames.Count * framerate;
                finish = true;
            }

            //Move the sprite
            this.x = x;
            this.y = y;
        }

        public bool finished()
        {
            return finish;
        }
    }
}
