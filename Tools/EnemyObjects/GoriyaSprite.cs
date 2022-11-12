using LOZ.Tools;
using LOZ;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.Tools
{
    internal class GoriyaSprite : ISpriteEnemy
    {
        Rectangle anim;

        SpriteEffects enemySpriteEffect;
        public void Draw(SpriteBatch _spriteBatch, Vector2 enemyPosition)
        {
            _spriteBatch.Draw(
                Game1.REGULAR_ENEMIES,
                enemyPosition,
                anim,
                Color.White,
                0f,
                new Vector2(anim.Width / 2, anim.Height / 2),
                2,
                enemySpriteEffect,
                0f
            );
        }
        public void Update(GameTime gameTime, int enemyState)
        {
            //Nothing
        }

        public void Update(GameTime gameTime, Vector2 enemyDirection)
        {
            Rectangle[] GoriyaFrames = new[] { new Rectangle(222, 11, 16, 16), new Rectangle(239, 11, 16, 16), new Rectangle(256, 11, 16, 16), new Rectangle(273, 11, 16, 16) };

            //Currently this method does not know about nor care about if the enemy is attacking, which is a good thing, but probably hard to maintain
            if (enemyDirection.Y == 0) anim = GoriyaFrames[(int)(gameTime.TotalGameTime.TotalMilliseconds / 100) % 2 + 2];
            else if (enemyDirection.Y > 0) anim = GoriyaFrames[0];
            else if (enemyDirection.Y < 0) anim = GoriyaFrames[1];

            enemySpriteEffect = enemyDirection.Y != 0 ? (((int)(gameTime.TotalGameTime.TotalMilliseconds / 100) % 2 == 1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None) : (enemyDirection.X < 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None);
        }

        public Vector2 GetWidthHeight()
        {
            return new Vector2(anim.Width, anim.Height);
        }
    }
}
