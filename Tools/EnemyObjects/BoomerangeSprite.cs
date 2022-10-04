using LOZ.Tools;
using LOZ;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LOZ.Tools
{
    internal class BoomerangeSprite : ISpriteEnemy
    {
        Rectangle boomerang;
        float boomerangRotation;
        public void Draw(SpriteBatch _spriteBatch, Vector2 boomerangPosition)
        {
            _spriteBatch.Draw(
                Game1.REGULAR_ENEMIES,
                boomerangPosition,
                boomerang,
                Color.White,
                boomerangRotation,
                new Vector2(boomerang.Width / 2, boomerang.Height / 2),
                2,
                SpriteEffects.None,
                0f
            );
        }

        public void Update(GameTime gameTime)
        {
            //Nothing
        }
        public void Update(GameTime gameTime, double attackLength, double attackTime)
        {
            //Leaving this in just in case the mathematical rotation/motion causes problems
            //Goodnight sweet prince
            //(int, SpriteEffects)[] boomerangFrame = new[] { (0, SpriteEffects.None), (1, SpriteEffects.None), (2, SpriteEffects.None), (1, SpriteEffects.FlipHorizontally), (0, SpriteEffects.FlipHorizontally), (1, SpriteEffects.None), (2, SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically), (1, SpriteEffects.FlipVertically) };
            Rectangle[] boomerangFrames = new[] { new Rectangle(290, 11, 8, 16), new Rectangle(299, 11, 8, 16), new Rectangle(308, 11, 8, 16) };

            boomerang = boomerangFrames[1];
            boomerangRotation = (float)((attackLength - attackTime) / 50 % 8 * Math.PI / 4);
        }
    }
}
