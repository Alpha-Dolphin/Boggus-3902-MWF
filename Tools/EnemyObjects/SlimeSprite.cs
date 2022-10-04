using LOZ.Tools;
using LOZ;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.Tools
{
    internal class SlimeSprite : ISpriteEnemy
    {
        Rectangle anim;

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
                SpriteEffects.None,
                0f
            );
        }
        public void Update(GameTime gameTime)
        {
            Rectangle[] SlimeFrames = new[] { new Rectangle(1, 11, 8, 16), new Rectangle(10, 11, 8, 16) };
            anim = SlimeFrames[(int)(gameTime.TotalGameTime.TotalMilliseconds / 100) % 2];
        }
    }
}
