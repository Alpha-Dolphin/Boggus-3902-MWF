using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using LOZ.Tools;

namespace LOZ.Tools
{
    internal class Slime : IEnemy, ICollidable
    {
        Vector2 enemyDirection;
        Vector2 enemyPosition;
        readonly ISpriteEnemy slimeSprite;

        readonly Random rand;

        double moveCheck;
        double moveTime;
        double moveProb;

        const double moveDelay = 1000;
        public void SetHurtbox(int x, int y)
        {
            enemyPosition.X = x;
            enemyPosition.Y = y;
        }
        public Slime(int X, int Y)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;

            slimeSprite = new SlimeSprite();

            rand = new();

            enemyPosition.X = X;
            enemyPosition.Y = Y;

            moveCheck = -1;
        }
        public Rectangle GetHurtbox()
        {
            Vector2 wH = slimeSprite.GetWidthHeight();
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
            enemyPosition.X += enemyDirection.X;
            enemyPosition.Y += enemyDirection.Y;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            slimeSprite.Draw(_spriteBatch, enemyPosition);
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
                        if (rand.Next() % 2 == 1) enemyDirection.X = speed;
                        else enemyDirection.X = -speed;
                        enemyDirection.Y = 0;
                    }
                    else
                    {
                        if (rand.Next() % 2 == 1) enemyDirection.Y = speed;
                        else enemyDirection.Y = -speed;
                        enemyDirection.X = 0;
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
                    enemyDirection.X = 0;
                    enemyDirection.Y = 0;
                }
            }
        }
    }
}
