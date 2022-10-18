using LOZ.Tools.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools
{
    internal class Ball : IEnemy
    {
        Vector2 enemyDirection;
        Vector2 enemyPosition;

        double ballLife;
        const int ballDespawnMS = 3000;

        readonly BallSprite ballSprite;

        readonly int m;
        public Ball(int mode)
        {
            ballLife = -1;

            ballSprite = new BallSprite();
            m = mode % 3;
        }
        public Rectangle GetRectangle()
        {
            Vector2 wH = ballSprite.GetWidthHeight();
            return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)wH.X, (int)wH.Y);
        }

        public void Move(GameTime gameTime)
        {
            int ballSpeedRecip = 10;
            ballLife -= gameTime.ElapsedGameTime.TotalMilliseconds;
            if (m == 0)
            {
                enemyPosition.X -= (float)(gameTime.ElapsedGameTime.TotalMilliseconds / ballSpeedRecip);
            } else if (m == 1) { 
                enemyPosition.X -= (float)(gameTime.ElapsedGameTime.TotalMilliseconds / ballSpeedRecip);
                enemyPosition.Y += (float)(gameTime.ElapsedGameTime.TotalMilliseconds / ballSpeedRecip);
            } else {
                enemyPosition.X -= (float) (gameTime.ElapsedGameTime.TotalMilliseconds / ballSpeedRecip);
                enemyPosition.Y -= (float) (gameTime.ElapsedGameTime.TotalMilliseconds / ballSpeedRecip);
            }
        }

        public void Die(GameTime gameTime)
        {
            //Nothing
        }

        public void Attack(GameTime gameTime)
        {
            //Nothing
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            ballSprite.Draw(_spriteBatch, enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            Move(gameTime);
            ballLife -= gameTime.ElapsedGameTime.TotalMilliseconds;
            ballSprite.Update(gameTime, ballLife);
        }

        public double GetBallLife()
        {
            return ballLife;
        }

        public void Activate(float X, float Y)
        {
            enemyPosition.X = X;
            enemyPosition.Y = Y;
            ballLife = ballDespawnMS;
        }
    }
}
