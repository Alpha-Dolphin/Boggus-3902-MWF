using CSE3902_Sprint0.Sprites;
using LOZ.Tools.EnemyObjects;
using LOZ.Tools.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.PlayerObjects
{
    internal class Dodongo : IEnemy
    {
        Vector2 boomerangPosition;

        readonly DodongoSprite dodongoSprite;
        readonly BoomerangeSprite boomerangSprite;

        readonly Random rand;

        const int attackLength = 3000;
        double attackTime;

        double moveCheck;
        double moveTime;
        double moveProb;

        public Dodongo(int X, int Y)
        {
            IEnemy.enemyDirection.X = 0;
            IEnemy.enemyDirection.Y = 0;

            IEnemy.enemyPosition.X = X;
            IEnemy.enemyPosition.Y = Y;

            rand = new();

            attackTime = -1;

            dodongoSprite = new DodongoSprite();
            boomerangSprite = new BoomerangeSprite();

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
            return dodongoSprite.GetRectangle();
        }

        public void Move(GameTime gameTime)
        {
            if (attackTime < 0.0)
            {
                IEnemy.enemyPosition.X += (float)(IEnemy.enemyDirection.X * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
                IEnemy.enemyPosition.Y += (float)(IEnemy.enemyDirection.Y * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (attackTime > 0.0) boomerangSprite.Draw(_spriteBatch, boomerangPosition);
            dodongoSprite.Draw(_spriteBatch, IEnemy.enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            dodongoSprite.Update(gameTime, IEnemy.enemyDirection);
            AttackUpdate(gameTime);
            if (attackTime < 0.0) MovementUpdate(gameTime);
            else boomerangSprite.Update(gameTime, attackLength, attackTime);
        }

        private void AttackUpdate(GameTime gameTime)
        {
            if (attackTime > 0.0) Attack(gameTime);
            else if (rand.Next() % 4950 <= 25 && false)
            {
                attackTime = attackLength;
                boomerangPosition = IEnemy.enemyPosition;
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

