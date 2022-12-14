using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using Microsoft.Xna.Framework.Audio;
using LOZ.Tools.Interfaces;

namespace LOZ.Tools
{
    internal class Goriya : IEnemy
    {
        readonly private List<SoundEffect> soundEffectList = Game1.soundEffectList;
        Vector2 enemyDirection;
        Vector2 enemyPosition;

        readonly EnemySprite goriyaSprite;

        readonly EnemyObjects.Boomerang boomerang;

        int enemyState;

        int enemyHealth;
        double healthTimer;

        double stateTime;

        readonly Random rand;

        double moveCheck;
        double moveTime;
        double moveProb;

        public Goriya(int X, int Y)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;

            enemyPosition.X = X;
            enemyPosition.Y = Y;

            rand = new();

            enemyState = 1;

            enemyHealth = 4;
            healthTimer = 0f;

            stateTime = 0;

            boomerang = new EnemyObjects.Boomerang();

/*            Game1.enemyNewList.Add(boomerang);
*/
            goriyaSprite = new EnemySprite(Game1.REGULAR_ENEMIES_SPRITESHEET, new[] { new Rectangle(222, 11, 16, 16), new Rectangle(239, 11, 16, 16), new Rectangle(256, 11, 16, 16), new Rectangle(273, 11, 16, 16) }, 3);

            moveCheck = -1;
        }

        public Rectangle GetRectangle()
        {
            Vector2 wH = goriyaSprite.GetWidthHeight();
            return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)wH.X, (int)wH.Y);
        }

        public void Attack(GameTime gameTime)
        {
            boomerang.Activate(enemyDirection, enemyPosition);
        }

        public void Damage()
        {
            if (healthTimer < 0f)
            {
                healthTimer = 1000f;
                enemyHealth--;
                if (enemyHealth <= 0) enemyState = -1;
                else soundEffectList[(int)SoundEffects.EnemyHit].Play();
            }
        }

        private void Die()
        {
            Game1.enemyDieList.Add(this);
            soundEffectList[(int)SoundEffects.EnemyDie].Play();
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
            StateHandler(gameTime);
            goriyaSprite.Update(gameTime, enemyState, healthTimer > 0f, enemyDirection);
            if (enemyState == 0 && boomerang.GetAttackTime() < 0.0)
            {
                MovementUpdate(gameTime);
                AttackUpdate(gameTime);
            }
            //Boomerang bug fix with uninitialized spritesheet texture if draw is called before all update calls
            boomerang.Update(gameTime);
            healthTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
        }
        private void StateHandler(GameTime gameTime)
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
                    Die();
                }
            }
        }
        private void AttackUpdate(GameTime gameTime)
        {
            if (rand.Next() % 4950 <= 25) Attack(gameTime);
        }

        public void SetHurtbox(Rectangle rect)
        {
            enemyPosition.Y = rect.Y;
            enemyPosition.X = rect.X;
        }

        public Rectangle GetHurtbox()
        {
            Vector2 wH = goriyaSprite.GetWidthHeight();
            return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)wH.X, (int)wH.Y);
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
