using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using LOZ.Tools.Interfaces;

namespace LOZ.Tools
{
    internal class Goriya : IEnemy
    {
        public Vector2 enemyDirection;
        public Vector2 enemyPosition;

        Vector2 boomerangPosition;

        readonly GoriyaSprite goriyaSprite;
        readonly BoomerangeSprite boomerangSprite;

        readonly Random rand;

        const int attackLength = 3000;
        double attackTime;

        double moveCheck;
        double moveTime;
        double moveProb;
        public void setPosition(int x, int y)
        {
            enemyPosition.X = x;
            enemyPosition.Y = y;
        }
        public Goriya(int X, int Y)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;

            enemyPosition.X = X;
            enemyPosition.Y = Y;

            rand = new();

            attackTime = -1;

            goriyaSprite = new GoriyaSprite();
            boomerangSprite = new BoomerangeSprite();

            moveCheck = -1;
        }

        public void Attack(GameTime gameTime)
        {
            int boomerangSpeedRecip = 25;
            if (attackTime > attackLength / 2)
            {
                if (enemyDirection.X < 0) boomerangPosition.X -= (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
                else if (enemyDirection.X > 0) boomerangPosition.X += (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
                else if (enemyDirection.Y < 0) boomerangPosition.Y -= (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
                else boomerangPosition.Y += (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
            }
            else
            {
                if (enemyDirection.X > 0) boomerangPosition.X -= (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
                else if (enemyDirection.X < 0) boomerangPosition.X += (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
                else if (enemyDirection.Y > 0) boomerangPosition.Y -= (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
                else boomerangPosition.Y += (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
            }
            attackTime -= gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public void Die(GameTime gameTime)
        {
            //Nothing
        }

        public void Move(GameTime gameTime)
        {
            if (attackTime < 0.0)
            {
                enemyPosition.X += (float)(enemyDirection.X * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
                enemyPosition.Y += (float)(enemyDirection.Y * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (attackTime > 0.0) boomerangSprite.Draw(_spriteBatch, boomerangPosition);
            goriyaSprite.Draw(_spriteBatch, enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            goriyaSprite.Update(gameTime, enemyDirection);
            AttackUpdate(gameTime);
            if (attackTime < 0.0) MovementUpdate(gameTime);
            else boomerangSprite.Update(gameTime, attackLength, attackTime);
        }

        private void AttackUpdate(GameTime gameTime)
        {
            if (attackTime > 0.0) Attack(gameTime);
            else if (rand.Next() % 4950 <= 25)
            {
                attackTime = attackLength;
                boomerangPosition = enemyPosition;
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
