using LOZ.Tools;
using Microsoft.Xna.Framework;
using System;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using LOZ.Tools.EnemyObjects;

namespace LOZ.Tools
{
    internal class Keese : IEnemy, ICollidable
    {
        readonly Random rand = new();

        Vector2 enemyDirection; Vector2 enemyPosition;readonly ISpriteEnemy keeseSprite;

        double moveCounter;
        double timeToMove;
        double moveCheck;
        public void SetHurtbox(int x, int y)
        {
            enemyPosition.X = x;
            enemyPosition.Y = y;
        }
        public Keese(int X, int Y)
        {
            enemyDirection.X = rand.Next() % 400 / 100 - 2;
            enemyDirection.Y = rand.Next() % 400 / 100 - 2;

            enemyPosition.X = X;
            enemyPosition.Y = Y;

            keeseSprite = new KeeseSprite();

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
            lm.enemyList.Remove(this);
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
