using LOZ.Tools.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.EnemyObjects
{
    internal class Rope : IEnemy
    {
        readonly ISpriteEnemy RopeSprite;

        readonly Random rand;

        double moveCheck;
        double moveTime;
        double moveProb;

        const double moveDelay = 1000;

        public Rope(int X, int Y)
        {
            IEnemy.enemyDirection.X = 0;
            IEnemy.enemyDirection.Y = 0;

            RopeSprite = new RopeSprite();

            rand = new();

            IEnemy.enemyPosition.X = X;
            IEnemy.enemyPosition.Y = Y;

            moveCheck = -1;
        }

        public void Attack(GameTime gameTime)
        {
            //Nothing
        }

        public void Die(GameTime gameTime)
        {
            //Nothing
        }

        public Rectangle GetRectangle()
        {
            Vector2 wH = RopeSprite.GetWidthHeight();
            return new Rectangle((int)IEnemy.enemyPosition.X, (int)IEnemy.enemyPosition.Y, (int)wH.X, (int)wH.Y);
        }
        public void Move(GameTime gameTime)
        {
            IEnemy.enemyPosition.X += IEnemy.enemyDirection.X;
            IEnemy.enemyPosition.Y += IEnemy.enemyDirection.Y;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            RopeSprite.Draw(_spriteBatch, IEnemy.enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            MovementUpdate(gameTime);
            RopeSprite.Update(gameTime);
        }

        private void MovementUpdate(GameTime gameTime)
        {
            if (moveTime <= 0 && moveCheck <= 0)
            {
                moveCheck = 25;
                if (rand.Next() % 4950 + 50 > moveProb)
                {
                    //Please just let not zero equal true
                    int speed = 1;

                    if (rand.Next() % 2 == 1)
                    {
                        if (rand.Next() % 2 == 1) IEnemy.enemyDirection.X = speed;
                        else IEnemy.enemyDirection.X = -speed;
                        IEnemy.enemyDirection.Y = 0;
                    }
                    else
                    {
                        if (rand.Next() % 2 == 1) IEnemy.enemyDirection.Y = speed;
                        else IEnemy.enemyDirection.Y = -speed;
                        IEnemy.enemyDirection.X = 0;
                    }

                    moveTime = rand.Next() % 2000 + 200;
                    moveCheck = moveDelay;
                    moveProb = 0;
                }
                moveProb -= gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else
            {
                if (moveTime > 0) moveTime -= gameTime.ElapsedGameTime.TotalMilliseconds;
                else
                {
                    moveCheck -= gameTime.ElapsedGameTime.TotalMilliseconds;
                    IEnemy.enemyDirection.X = 0;
                    IEnemy.enemyDirection.Y = 0;
                }
            }
        }
    }
}
