using LOZ.Tools;
using LOZ;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.Tools
{
    internal class StalfosSprite : ISpriteEnemy
    {
        Rectangle anim;
        Texture2D currSheet;
        double timer;
        SpriteEffects animState;

        public StalfosSprite()
        {
            anim = new Rectangle(1, 59, 16, 16);
        }

        public void Draw(SpriteBatch _spriteBatch, Vector2 enemyPosition)
        {
            _spriteBatch.Draw(
                currSheet,
                enemyPosition * Constants.objectScale * 2,
                anim,
                Color.White,
                0f,
                new Vector2(anim.Width / 2, anim.Height / 2),
                2 * Constants.objectScale,
                animState,
                0f
            );
        }
        public void Update(GameTime gameTime, int enemyState)
        {
            if (enemyState == 0)
            {
                animState = (((int)(gameTime.TotalGameTime.TotalMilliseconds / 100) % 2) == 0) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                currSheet = Game1.REGULAR_ENEMIES_SPRITESHEET;
                anim = new Rectangle(1, 59, 16, 16);
            }
            else if (enemyState == 1)
            {
                if (gameTime.TotalGameTime.TotalMilliseconds - timer > Constants.enemyEntryExitTime) timer = gameTime.TotalGameTime.TotalMilliseconds;
                anim = IEnemy.Appear(timer);
                currSheet = Game1.LINK_SPRITESHEET;
            }
            else if (enemyState == -1)
            {
                if (gameTime.TotalGameTime.TotalMilliseconds - timer > Constants.enemyEntryExitTime) timer = gameTime.TotalGameTime.TotalMilliseconds;
                anim = IEnemy.Disappear(timer);
                currSheet = Game1.EXPLOSION;
            }
            timer += gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public Vector2 GetWidthHeight()
        {
            return new Vector2(anim.Width, anim.Height);
        }
    }
}
