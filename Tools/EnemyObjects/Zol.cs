﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.EnemyObjects
{
    internal class Zol : IEnemy, ICollidable
    {
        Vector2 enemyDirection;
        Vector2 enemyPosition;
        readonly ISpriteEnemy ZolSprite;

        readonly Random rand;

        int enemyState;

        double stateTime;

        double moveCheck;
        double moveTime;
        double moveProb;

        const double moveDelay = 1000;
        public void SetHurtbox(Rectangle rect)
        {
            enemyPosition.Y = rect.Y;
            enemyPosition.X = rect.X;
        }
        public Zol(int X, int Y)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;

            ZolSprite = new ZolSprite();

            rand = new();

            enemyState = 1;

            stateTime = 0.0;

            enemyPosition.Y = Y;
            enemyPosition.X = X;

            moveCheck = -1;
        }

        public Rectangle GetHurtbox()
        {
            Vector2 wH = ZolSprite.GetWidthHeight();
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
            enemyPosition.X += enemyDirection.X;
            enemyPosition.Y += enemyDirection.Y;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            ZolSprite.Draw(_spriteBatch, enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            stateHandler(gameTime);
            if (enemyState == 0) MovementUpdate(gameTime);
            ZolSprite.Update(gameTime, enemyState);
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
