using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using LOZ.Tools.Interfaces;

namespace LOZ.Tools.PlayerObjects
{
    internal class Dodongo : IEnemy, ICollidable
    {
        readonly private List<SoundEffect> soundEffectList = Game1.soundEffectList;
        Vector2 enemyDirection;
        bool directionChange = false;
        Vector2 enemyPosition;

        double stateTime;

        int enemyState;

        int enemyHealth;
        double healthTimer;

        readonly EnemySprite dodongoSprite;

        readonly Random rand;

        const int attackLength = 3000;
        double attackTime;

        double moveCheck;
        double moveTime;
        double moveProb;
        public void SetHurtbox(Rectangle rect)
        {
            enemyPosition.Y = rect.Y;
            enemyPosition.X = rect.X;
        }
        public Dodongo(int X, int Y)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;

            enemyPosition.Y = Y;
            enemyPosition.X = X;

            rand = new();

            enemyState = 1;

            enemyHealth = 10;
            healthTimer = 0f;

            stateTime = 0;

            attackTime = -1;

            dodongoSprite = new EnemySprite(Game1.BOSSES_SPRITESHEET, new[] { new Rectangle(69, 58, 32, 16), new Rectangle(69, 58, 32, 16), new Rectangle(102, 58, 32, 16), new Rectangle(69, 58, 32, 16) });
            moveCheck = -1;
        }

        public void Attack(GameTime gameTime)
        {
            //Nothing
        }

        public void Damage()
        {
            if (healthTimer < 0f)
            {
                healthTimer = 1000f;
                enemyHealth--;
                if (enemyHealth <= 0)
                {
                    enemyState = -1;
                }
            }
        }

        public void Die()
        {
            soundEffectList[(int)SoundEffects.DodongoScream].Play();
            Game1.enemyDieList.Add(this);
        }
        public Rectangle GetHurtbox()
        {
            Vector2 wH = dodongoSprite.GetWidthHeight();
            return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)wH.X, (int)wH.Y);
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
            dodongoSprite.Draw(_spriteBatch, enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            StateHandler(gameTime);
            if (enemyState == 0)
            {
                dodongoSprite.Update(gameTime, enemyState, enemyDirection);
                AttackUpdate(gameTime);
                if (attackTime < 0.0) MovementUpdate(gameTime);
            }
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
            if (attackTime > 0.0) Attack(gameTime);
            else if (rand.Next() % 4950 <= 25 && false)
            {
                attackTime = attackLength;
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

