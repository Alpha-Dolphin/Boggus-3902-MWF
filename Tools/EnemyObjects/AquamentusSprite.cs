using LOZ;
using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools
{
    //deprecated
    internal class AquementusSprite : ISpriteEnemy
    {
        Rectangle anim;

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
                SpriteEffects.None,
                0f
            );
        }

        public Vector2 GetWidthHeight()
        {
            return new Vector2(anim.Width, anim.Height);
        }

        public void Update(GameTime gameTime)
        {
            Rectangle[] aquementusFrames = new[] { new Rectangle(1, 11, 24, 32), new Rectangle(26, 11, 24, 32), new Rectangle(51, 11, 24, 32), new Rectangle(76, 11, 24, 32) };

            //Currently this method does not know about nor care about if the enemy is attacking, which is a good thing, but probably hard to maintain

            anim = aquementusFrames[(int)(gameTime.TotalGameTime.TotalMilliseconds / 200) % 4];
        }
    }
}
