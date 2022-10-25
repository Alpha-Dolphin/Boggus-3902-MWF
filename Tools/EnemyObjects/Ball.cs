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
    internal class Ball : IEnemy, ICollidable
    {
        Vector2 enemyDirection;
        Vector2 enemyPosition;

        double ballLife;
        const int ballDespawnMS = 3000;

        //readonly BallSprite ballSprite;
        AnimatedMovingSprite ballSprite;

        readonly int m;
        public void SetHurtbox(Rectangle rect)
        {
            enemyPosition.Y = rect.Y;
            enemyPosition.X = rect.X;
        }
        public Ball(int mode)
        {
            ballLife = -1;

            ballSprite = new AnimatedMovingSprite(Game1.REGULAR_ENEMIES, (int)enemyPosition.X, (int)enemyPosition.Y,
                new List<Rectangle> { new Rectangle(101, 11, 8, 16), new Rectangle(110, 11, 8, 16), new Rectangle(119, 11, 8, 16), new Rectangle(128, 11, 8, 16) });
            m = mode % 3;
        }
        public Rectangle GetHurtbox()
        {
            Vector2 wH = new Vector2(ballSprite.GetDestinationRectangle().Width, ballSprite.GetDestinationRectangle().Height);
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

        public void Die()
        {
            Game1.enemyDieList.Add(this);
        }

        public void Attack(GameTime gameTime)
        {
            //Nothing
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            ballSprite.Draw(_spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            Move(gameTime);
            ballLife -= gameTime.ElapsedGameTime.TotalMilliseconds;
            ballSprite.Update((int)enemyPosition.X, (int)enemyPosition.Y);
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
