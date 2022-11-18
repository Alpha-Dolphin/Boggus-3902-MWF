using LOZ.Tools;
using LOZ;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.Tools
{
    internal class EnemySprite : ISpriteEnemy
    {
        readonly Rectangle[] enemyFrames;

        Rectangle anim;

        Texture2D currSheet;
        readonly Texture2D enemySheet;

        double timer;

        readonly int mode;
        public EnemySprite(Texture2D sheet, Rectangle[] frames)
        {
            enemyFrames = frames;
            enemySheet = sheet;
        }
        public EnemySprite(Texture2D sheet, Rectangle[] frames, int special)
        {
            enemyFrames = frames;
            enemySheet = sheet;

            mode = special;
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
                (mode == 1 && (((int)timer /250) % 2) == 0) ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0f
            );
        }

        public Vector2 GetWidthHeight()
        {
            return new Vector2(anim.Width, anim.Height);
        }

        public void Update(GameTime gameTime, int enemyState)
        {
            if (enemyState == 0)
            {
                anim = enemyFrames[(int)(gameTime.TotalGameTime.TotalMilliseconds / (50 * enemyFrames.Length)) % enemyFrames.Length];
                currSheet = enemySheet;
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
