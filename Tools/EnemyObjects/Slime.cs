using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using LOZ.Tools.Interfaces;
using LOZ.Tools;

namespace LOZ.Tools
{
    internal class Slime : IEnemy
    {
        readonly ISpriteEnemy slimeSprite;

        readonly Random rand;

        double moveCheck;
        double moveTime;
        double moveProb;

        const double moveDelay = 1000;

        public Slime(int X, int Y)
        {
            IEnemy.enemyDirection.X = 0;
            IEnemy.enemyDirection.Y = 0;

            slimeSprite = new SlimeSprite();

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

        public void Move(GameTime gameTime)
        {
            IEnemy.enemyPosition.X += IEnemy.enemyDirection.X;
            IEnemy.enemyPosition.Y += IEnemy.enemyDirection.Y;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            slimeSprite.Draw(_spriteBatch, IEnemy.enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            MovementUpdate(gameTime);
            slimeSprite.Update(gameTime);
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
