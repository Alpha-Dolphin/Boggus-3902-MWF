using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LOZ.Tools.Interfaces;

namespace LOZ.Tools
{
    internal class EnemySprite : ISpriteEnemy
    {
        readonly Rectangle[] enemyFrames;

        Rectangle anim;

        Texture2D currSheet;
        readonly Texture2D enemySheet;
        SpriteEffects enemySpriteEffect;
        bool red;

        double timer;

        readonly int mode;
        public EnemySprite(Texture2D sheet, Rectangle[] frames)
        {
            enemyFrames = frames;
            enemySheet = sheet;
            red = false;
        }
        public EnemySprite(Texture2D sheet, Rectangle[] frames, int special)
        {
            enemyFrames = frames;
            enemySheet = sheet;
            red = false;

            mode = special;
        }

        public void Draw(SpriteBatch _spriteBatch, Vector2 enemyPosition)
        {
            //Bug fix with draw being called before update has ever been called
            if (!anim.IsEmpty)
            {
                _spriteBatch.Draw(
                    currSheet,
                    enemyPosition * Constants.objectScale * 2,
                    anim,
                    red ? Color.Red : Color.White,
                    (mode == 2) ? (float)(timer / 50 % 8 * Math.PI / 4) : 0f,
                    new Vector2(anim.Width / 2, anim.Height / 2),
                    2 * Constants.objectScale,
                    (mode == 1 && (((int)timer / 250) % 2) == 0) ? SpriteEffects.FlipHorizontally : (mode == 3) ? enemySpriteEffect : SpriteEffects.None,
                    0f
                );
            }
        }

        public Vector2 GetWidthHeight()
        {
            return new Vector2(anim.Width, anim.Height);
        }

        public void Update(GameTime gameTime, int enemyState, bool damaged)
        {
            if (enemyState == 0)
            {
                this.red = damaged;
                anim = enemyFrames[(int)(gameTime.TotalGameTime.TotalMilliseconds / (50 * enemyFrames.Length)) % enemyFrames.Length];
                currSheet = enemySheet;
            }
            else if (enemyState == 1)
            {
                this.red = false;
                if (gameTime.TotalGameTime.TotalMilliseconds - timer > Constants.enemyEntryExitTime) timer = gameTime.TotalGameTime.TotalMilliseconds;
                anim = IEnemy.Appear(timer);
                currSheet = Game1.LINK_SPRITESHEET;
            }
            else if (enemyState == -1)
            {
                this.red = false;
                if (gameTime.TotalGameTime.TotalMilliseconds - timer > Constants.enemyEntryExitTime) timer = gameTime.TotalGameTime.TotalMilliseconds;
                anim = IEnemy.Disappear(timer);
                currSheet = Game1.EXPLOSION;
            }
            timer += gameTime.ElapsedGameTime.TotalMilliseconds;
        }
        public void Update(GameTime gameTime, int enemyState, bool damaged, Vector2 enemyDirection)
        {
            if (enemyState == 0)
            {
                this.red = damaged;
                if (enemyDirection.Y == 0) anim = enemyFrames[(int)(gameTime.TotalGameTime.TotalMilliseconds / 100) % 2 + 2];
                else if (enemyDirection.Y > 0) anim = enemyFrames[0];
                else if (enemyDirection.Y < 0) anim = enemyFrames[1];

                enemySpriteEffect = enemyDirection.Y != 0 ? (((int)(gameTime.TotalGameTime.TotalMilliseconds / 100) % 2 == 1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None) : (enemyDirection.X < 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None);
                currSheet = Game1.REGULAR_ENEMIES_SPRITESHEET;
            }
            else if (enemyState == 1)
            {
                this.red = false;
                if (gameTime.TotalGameTime.TotalMilliseconds - timer > Constants.enemyEntryExitTime) timer = gameTime.TotalGameTime.TotalMilliseconds;
                anim = IEnemy.Appear(timer);
                currSheet = Game1.LINK_SPRITESHEET;
            }
            else if (enemyState == -1)
            {
                this.red = false;
                if (gameTime.TotalGameTime.TotalMilliseconds - timer > Constants.enemyEntryExitTime) timer = gameTime.TotalGameTime.TotalMilliseconds;
                anim = IEnemy.Disappear(timer);
                currSheet = Game1.EXPLOSION;
            }
            timer += gameTime.ElapsedGameTime.TotalMilliseconds;
        }
    }
}
