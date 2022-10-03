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
        private List<Vector2> locationShift;

        private int x;
        private int y;

        private int scale = 3;

        private int frameRate = 10;

        private bool finish = false;

        private int currentFrame = 0;
        public AnimatedMovingSprite(Texture2D picture, int x, int y, List<Rectangle> frames)
        {
            this.picture = picture;
            this.x = x;
            this.y = y;
            this.frames = frames;

            if (frames.Count <= 1) finish = true;

            this.locationShift = new List<Vector2>();

            for(int i = 0; i < frames.Count; i++)
            {
                locationShift.Add(LinkConstants.DEFAULT_LOCATIONSHIFT);
            }
        }
        public AnimatedMovingSprite(Texture2D picture, int x, int y, List<Rectangle> frames, int frameRate)
        {
            this.picture = picture;
            this.x = x;
            this.y = y;
            this.frames = frames;
            this.frameRate = frameRate;

            if (frames.Count <= 1) finish = true;

            this.locationShift = new List<Vector2>();

            for (int i = 0; i < frames.Count; i++)
            {
                locationShift.Add(LinkConstants.DEFAULT_LOCATIONSHIFT);
            }
        }
        public AnimatedMovingSprite(Texture2D picture, int x, int y, List<Rectangle> frames, List<Vector2> locationShift)
        {
            this.picture = picture;
            this.x = x;
            this.y = y;
            this.frames = frames;

            if (frames.Count <= 1) finish = true;
            this.locationShift = locationShift;

            while (locationShift.Count < frames.Count)
            {
                locationShift.Add(locationShift[0]);
            }
        }
        public AnimatedMovingSprite(Texture2D picture, int x, int y, List<Rectangle> frames, List<Vector2> locationShift, int frameRate)
        {
            this.picture = picture;
            this.x = x;
            this.y = y;
            this.frames = frames;
            this.frameRate = frameRate;

            if (frames.Count <= 1) finish = true;
            this.locationShift = locationShift;

            while(locationShift.Count < frames.Count)
            {
                locationShift.Add(locationShift[0]);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle currentRectangle = frames[currentFrame / frameRate];
            Vector2 currentLocationShift = locationShift[currentFrame / frameRate];
            int currentX = x + (int)currentLocationShift.X * scale;
            int currentY = y + (int)currentLocationShift.Y * scale;
            spriteBatch.Draw(picture, new Rectangle(currentX, currentY, currentRectangle.Width*scale, currentRectangle.Height*scale), currentRectangle, LinkConstants.DEFAULT_PICTURE_COLOR);
        }

        public void Update(int x, int y)
        {
            //Animate the sprite
            currentFrame++;
            if (currentFrame >= frames.Count * frameRate)
            {
                currentFrame -= frames.Count * frameRate;
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
