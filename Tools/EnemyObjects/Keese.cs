using LOZ.Tools;
using Microsoft.Xna.Framework;
using System;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using LOZ.Tools.EnemyObjects;
using LOZ.Tools.Sprites;
using System.Collections.Generic;

namespace LOZ.Tools
{
    internal class Keese : IEnemy, ICollidable
    {
        readonly Random rand = new();

        Vector2 enemyDirection; Vector2 enemyPosition;
        readonly ISpriteEnemy keeseSprite;
        //AnimatedMovingSprite keeseSprite;

        double moveCounter;
        double timeToMove;
        double moveCheck;

        int enemyState;
        double stateTime;
        public void SetHurtbox(Rectangle rect)
        {
            enemyPosition.Y = rect.Y;
            enemyPosition.X = rect.X;
        }
        public Keese(int X, int Y)
        {
            enemyDirection.X = rand.Next() % 400 / 100 - 2;
            enemyDirection.Y = rand.Next() % 400 / 100 - 2;

            enemyPosition.Y = Y;
            enemyPosition.X = X;

            keeseSprite = new KeeseSprite();

            stateTime = 0.0;
            enemyState = 1;

            moveCounter = 0.0;
            timeToMove = 0.0;
            moveCheck = 0.0;
        }

        public Rectangle GetHurtbox()
        {
            Vector2 wH = keeseSprite.GetWidthHeight();
            return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)wH.X, (int)wH.Y);
        }

        public void Attack(GameTime gameTime)
        {
            //Nothing
        }

        public void Die()
        {
            enemyState = -1;
        }

        private void DeleteEnemy()
        {
            Game1.enemyDieList.Add(this);
        }

        public void Move(GameTime gameTime)
        {
            if (0 < moveCounter)
            {
                enemyPosition.X += (float)(enemyDirection.X * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
                enemyPosition.Y += (float)(enemyDirection.Y * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
            }
            else
            {
                enemyDirection.X = rand.Next() % 400 / 100 - 2;
                enemyDirection.Y = rand.Next() % 400 / 100 - 2;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            keeseSprite.Draw(_spriteBatch, enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            stateHandler(gameTime);
            if (enemyState == 0) MovementUpdate(gameTime);
            keeseSprite.Update(gameTime, enemyState);
        }

        private void stateHandler(GameTime gameTime)
        {
            if (enemyState == 1)
            {
                stateTime += gameTime.ElapsedGameTime.TotalMilliseconds;
                if (stateTime > Constants.enemyEntryExitTime)
                {
                    stateTime = 0;
                    enemyState = 0;
                }
            }
            else if (enemyState == -1)
            {
                stateTime += gameTime.ElapsedGameTime.TotalMilliseconds;
                if (stateTime > Constants.enemyEntryExitTime)
                {
                    DeleteEnemy();
                }
            }
        }
        private void MovementUpdate(GameTime gameTime)
        {
            if (moveCheck <= 0)
            {
                if (moveCounter < 0 && rand.Next() % 4950 + 50 < timeToMove)
                {
                    moveCounter = rand.Next() % 400 + 100;
                    timeToMove = 0;
                }
                else if (moveCounter < 0)
                {
                    moveCheck = 5;
                    timeToMove += moveCheck;
                }
            }
            else
            {
                moveCheck -= gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            moveCounter -= gameTime.ElapsedGameTime.TotalMilliseconds;
        }
    }
}
