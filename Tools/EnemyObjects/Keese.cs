using LOZ.Tools.Interfaces;
using LOZ.Tools;
using Microsoft.Xna.Framework;
using System;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace LOZ.Tools
{
    internal class Keese : IEnemy
    {
        readonly Random rand = new();

        readonly ISpriteEnemy keeseSprite;

        double moveCounter;
        double timeToMove;
        double moveCheck;

        public Keese(int X, int Y)
        {
            IEnemy.enemyDirection.X = rand.Next() % 400 / 100 - 2;
            IEnemy.enemyDirection.Y = rand.Next() % 400 / 100 - 2;

            IEnemy.enemyPosition.X = X;
            IEnemy.enemyPosition.Y = Y;

            keeseSprite = new KeeseSprite();

            moveCounter = 0.0;
            timeToMove = 0.0;
            moveCheck = 0.0;
        }

        public void Attack(GameTime gameTime)
        {
            //Nothing
        }

        public void Die(GameTime gameTime)
        {
            //Nothing
        }

        public void Move(GameTime gameTime)
        {
            if (0 < moveCounter)
            {
                IEnemy.enemyPosition.X += (float)(IEnemy.enemyDirection.X * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
                IEnemy.enemyPosition.Y += (float)(IEnemy.enemyDirection.Y * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
            }
            else
            {
                IEnemy.enemyDirection.X = rand.Next() % 400 / 100 - 2;
                IEnemy.enemyDirection.Y = rand.Next() % 400 / 100 - 2;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            keeseSprite.Draw(_spriteBatch, IEnemy.enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            MovementUpdate(gameTime);
            keeseSprite.Update(gameTime);
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
