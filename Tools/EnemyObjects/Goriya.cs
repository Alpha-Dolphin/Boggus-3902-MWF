using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using LOZ.Tools.PlayerObjects;
using LOZ.Tools.EnemyObjects;

namespace LOZ.Tools
{
    internal class Goriya : IEnemy, ICollidable
    {
        Vector2 enemyDirection;
        Vector2 enemyPosition;

        readonly GoriyaSprite goriyaSprite;

        readonly EnemyObjects.Boomerang boomerang;

        readonly Random rand;

        double moveCheck;
        double moveTime;
        double moveProb;
        public void SetHurtbox(int x, int y)
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

            boomerang = new EnemyObjects.Boomerang();

            goriyaSprite = new GoriyaSprite();

            moveCheck = -1;
        }

        public Rectangle GetHurtbox()
        {
            Vector2 wH = goriyaSprite.GetWidthHeight();
            return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)wH.X, (int)wH.Y);
        }

        public void Attack(GameTime gameTime)
        {
            boomerang.Activate(enemyDirection, enemyPosition);
        }

        public void Die()
        {
            lm.enemyList.Remove(this);
        }

        public void Move(GameTime gameTime)
        {
            if (boomerang.GetAttackTime() < 0.0)
            {
                enemyPosition.X += (float)(enemyDirection.X * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
                enemyPosition.Y += (float)(enemyDirection.Y * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            goriyaSprite.Draw(_spriteBatch, enemyPosition);
            if (boomerang.GetAttackTime() > 0.0) boomerang.Draw(_spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            goriyaSprite.Update(gameTime, enemyDirection);
            if (boomerang.GetAttackTime() < 0.0)
            {
                MovementUpdate(gameTime);
                AttackUpdate(gameTime);
                boomerang.SetHurtbox(-1,-1);
            }
            else
            {
                boomerang.Update(gameTime);
            }
        }

        private void AttackUpdate(GameTime gameTime)
        {
            if (rand.Next() % 4950 <= 25) Attack(gameTime);
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
