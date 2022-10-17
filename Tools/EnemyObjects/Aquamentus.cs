using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.Interfaces;
using LOZ;

namespace LOZ.Tools
{
    internal class Aquamentus : IEnemy
    {
        Vector2 enemyDirection;
        Vector2 enemyPosition;

        readonly ISpriteEnemy aquamentusSprite;

        readonly BallSprite ballSprite;

        Vector2 ball1Position;
        Vector2 ball2Position;
        Vector2 ball3Position;

        readonly Random rand;

        double ballLife;
        const int ballDespawnMS = 3000;

        double moveCheck;
        double moveTime;
        double moveProb;

        public Aquamentus(int X, int Y)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;

            enemyPosition.X = X;
            enemyPosition.Y = Y;

            aquamentusSprite = new AquementusSprite();

            ballSprite = new BallSprite();

            ballLife = -1.0;

            rand = new();

            moveCheck = -1;
        }

        public void Attack(GameTime gameTime)
        {
            int ballSpeedRecip = 10;
            ballLife -= gameTime.ElapsedGameTime.TotalMilliseconds;
            ball1Position.X -= (float)(gameTime.ElapsedGameTime.TotalMilliseconds / ballSpeedRecip);
            ball2Position.X -= (float)(gameTime.ElapsedGameTime.TotalMilliseconds / ballSpeedRecip);
            ball2Position.Y += (float)(gameTime.ElapsedGameTime.TotalMilliseconds / ballSpeedRecip);
            ball3Position.X -= (float)(gameTime.ElapsedGameTime.TotalMilliseconds / ballSpeedRecip);
            ball3Position.Y -= (float)(gameTime.ElapsedGameTime.TotalMilliseconds / ballSpeedRecip);
        }

        public void Die(GameTime gameTime)
        {
            //Nothing
        }

        public void Move(GameTime gameTime)
        {
            enemyPosition.X += (float)(enemyDirection.X * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
            enemyPosition.Y += (float)(enemyDirection.Y * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            aquamentusSprite.Draw(_spriteBatch, enemyPosition);

            if (ballLife > 0.0)
            {
                ballSprite.Draw(_spriteBatch, ball1Position);
                ballSprite.Draw(_spriteBatch, ball2Position);
                ballSprite.Draw(_spriteBatch, ball3Position);
            }
        }

        public void Update(GameTime gameTime)
        {
            MovementUpdate(gameTime);
            aquamentusSprite.Update(gameTime);
            ballSprite.Update(gameTime, ballLife);
            AttackUpdate(gameTime);
        }

        private void AttackUpdate(GameTime gameTime)
        {
            if (ballLife > 0.0) Attack(gameTime);
            else if (rand.Next() % 4950 <= 25 && ballLife < 0.0)
            {
                ballLife = ballDespawnMS;
                ball1Position = enemyPosition;
                ball2Position = enemyPosition;
                ball3Position = enemyPosition;
            }
        }

        private void MovementUpdate(GameTime gameTime)
        {
            if (moveTime <= 0 && moveCheck <= 0)
            {
                moveCheck = 25;
                if (rand.Next() % (4950 / 2) + 50 > moveProb)
                {
                    //Please just let not zero equal true
                    int speed = 1;

                    //Movement will always be X-based
                    if (true || rand.Next() % 2 == 1)
                    {
                        if (rand.Next() % 2 == 1) enemyDirection.X = speed;
                        else enemyDirection.X = -speed;
                        enemyDirection.Y = 0;
                    }
                    //No Y-movement for this enemy
                    /*else
                    {
                        if (rand.Next() % 2 == 1) enemyDirection.Y = speed;
                        else enemyDirection.Y = -speed;
                        enemyDirection.X = 0;
                    }*/

                    moveTime = rand.Next() % 2000 + 200;
                    moveProb = 0;
                }
                moveProb -= gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else
            {
                if (moveTime > 0) moveTime -= gameTime.ElapsedGameTime.TotalMilliseconds;
                else moveCheck -= gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
    }
}
