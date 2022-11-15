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
            Rectangle[] aquementusFrames = new[] { new Rectangle(1, 11, 24, 32), new Rectangle(26, 11, 24, 32), new Rectangle(51, 11, 24, 32), new Rectangle(76, 11, 24, 32) };

            if (enemyState == 0)
            {
                anim = aquementusFrames[(int)(gameTime.TotalGameTime.TotalMilliseconds / (aquementusFrames.Length * 50)) % aquementusFrames.Length];
                currSheet = Game1.BOSSES_SPRITESHEET;
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
