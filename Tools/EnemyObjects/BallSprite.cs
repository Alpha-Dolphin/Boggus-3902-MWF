using LOZ.Tools;
using LOZ;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.Tools
{
    internal class BallSprite : ISpriteEnemy
    {
        Rectangle ball;

        public void Draw(SpriteBatch _spriteBatch, Vector2 ballPosition)
        {
            _spriteBatch.Draw(
                Game1.BOSSES,
                ballPosition,
                ball,
                Color.White,
                0f,
                new Vector2(ball.Width / 2, ball.Height / 2),
                2,
                SpriteEffects.None,
                0f
            );
        }
        public void Update(GameTime gameTime)
        {
            //Nothing
        }
        public void Update(GameTime gameTime, double ballLife)
        {
            Rectangle[] ballFrames = new[] { new Rectangle(101, 11, 8, 16), new Rectangle(110, 11, 8, 16), new Rectangle(119, 11, 8, 16), new Rectangle(128, 11, 8, 16) };
            ball = ballFrames[((int)(3000 - ballLife) / 200) % 4];
        }
    }
}
