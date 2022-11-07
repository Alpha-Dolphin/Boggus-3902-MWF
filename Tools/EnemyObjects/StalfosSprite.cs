using LOZ.Tools;
using LOZ;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.Tools
{
    internal class StalfosSprite : ISpriteEnemy
    {
        Rectangle anim;

        SpriteEffects animState;

        public StalfosSprite()
        {
            anim = new Rectangle(1, 59, 16, 16);
        }

        public void Draw(SpriteBatch _spriteBatch, Vector2 enemyPosition)
        {
            _spriteBatch.Draw(
                Game1.REGULAR_ENEMIES_SPRITESHEET,
                enemyPosition,
                anim,
                Color.White,
                0f,
                new Vector2(anim.Width / 2, anim.Height / 2),
                2,
                animState,
                0f
            );
        }
        public void Update(GameTime gameTime)
        {
            animState = (((int)(gameTime.TotalGameTime.TotalMilliseconds / 100) % 2) == 0) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
        }

        public Vector2 GetWidthHeight()
        {
            return new Vector2(anim.Width, anim.Height);
        }
    }
}
