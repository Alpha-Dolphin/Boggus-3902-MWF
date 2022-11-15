using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.EnemyObjects
{
    internal class RopeSprite : ISpriteEnemy
    {
        Rectangle anim;

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
                SpriteEffects.None,
                0f
            );
        }
        public void Update(GameTime gameTime, int enemyState)
        {
            Rectangle[] SlimeFrames = new[] { new Rectangle(126, 59, 16, 16), new Rectangle(143, 59, 16, 16) };
            anim = SlimeFrames[(int)(gameTime.TotalGameTime.TotalMilliseconds / 100) % 2];
        }

        public Vector2 GetWidthHeight()
        {
            return new Vector2(anim.Width, anim.Height);
        }
    }
}
