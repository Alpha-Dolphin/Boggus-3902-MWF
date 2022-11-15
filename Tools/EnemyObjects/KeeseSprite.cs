using LOZ.Tools;
using LOZ;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.Tools
{
    internal class KeeseSprite : ISpriteEnemy
    {
        Rectangle anim;
        Texture2D currSheet;
        double timer;

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
                SpriteEffects.None,
                0f
            );
        }

        public Vector2 GetWidthHeight()
        {
            return new Vector2(anim.Width, anim.Height);
        }

        public void Update(GameTime gameTime, int enemyState)
        {
            Rectangle[] KeeseFrames = new[] { new Rectangle(183, 11, 16, 16), new Rectangle(200, 11, 16, 16) };

            if (enemyState == 0)
            {
                anim = KeeseFrames[(int)(gameTime.TotalGameTime.TotalMilliseconds / (50 * KeeseFrames.Length)) % KeeseFrames.Length];
                currSheet = Game1.REGULAR_ENEMIES_SPRITESHEET;
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
    }
}
