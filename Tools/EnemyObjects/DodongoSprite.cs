using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.EnemyObjects
{
    internal class DodongoSprite : ISpriteEnemy
    {
        Rectangle anim;

        SpriteEffects enemySpriteEffect;
        public void Draw(SpriteBatch _spriteBatch, Vector2 enemyPosition)
        {
            _spriteBatch.Draw(
                Game1.BOSSES_SPRITESHEET,
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
        public Vector2 GetWidthHeight()
        {
            return new Vector2(anim.Width, anim.Height);
        }
        public void Update(GameTime gameTime, int enemyState)
        {
            //Nothing
        }

        public void Update(GameTime gameTime, Vector2 enemyDirection)
        {
            Rectangle[] DodongoFrames1 = new[] { new Rectangle(1, 58, 16, 16), new Rectangle(35, 58, 16, 16) };
            

            //Currently this method does not know about nor care about if the enemy is attacking, which is a good thing, but probably hard to maintain
            
            if (enemyDirection.Y > 0) anim = DodongoFrames1[0];
            else if (enemyDirection.Y < 0) anim = DodongoFrames1[1];

            Rectangle[] DodongoFrames2 = new[] { new Rectangle(69, 58, 32, 16), new Rectangle(69, 58, 32, 16),new Rectangle(102, 58, 32, 16), new Rectangle(69, 58, 32, 16) };
            if (enemyDirection.Y == 0) anim = DodongoFrames2[(int)(gameTime.TotalGameTime.TotalMilliseconds / 100) % 2 + 2];
            else if (enemyDirection.X > 0) anim = DodongoFrames2[0];
            else if (enemyDirection.X < 0) anim = DodongoFrames2[1];

            enemySpriteEffect = enemyDirection.Y != 0 ? (((int)(gameTime.TotalGameTime.TotalMilliseconds / 100) % 2 == 1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None) : (enemyDirection.X < 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None);


        }
    }
}
