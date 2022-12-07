using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using LOZ.Tools.Interfaces;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace LOZ.Tools
{
    internal class Rope : IEnemy, ICollidable
    {
        readonly private List<SoundEffect> soundEffectList = Game1.soundEffectList;

        Vector2 enemyDirection;
        Vector2 enemyPosition;
        readonly ISpriteEnemy RopeSprite;

        readonly Random rand;

        double moveCheck;
        double moveTime;
        double moveProb;

        double stateTime;
        int enemyState;

        int enemyHealth;

        const double moveDelay = 1000;
        public void SetHurtbox(Rectangle rect)
        {
            enemyPosition.Y = rect.Y;
            enemyPosition.X = rect.X;
        }
        public Rope(int X, int Y)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;

            RopeSprite = new EnemySprite(Game1.REGULAR_ENEMIES_SPRITESHEET, new[] { new Rectangle(126, 59, 16, 16), new Rectangle(143, 59, 16, 16) });

            rand = new();

            enemyPosition.Y = Y;
            enemyPosition.X = X;

            stateTime = 0.0;

            enemyHealth = 0;

            enemyState = 1;

            moveCheck = -1;
        }

        public void Attack(GameTime gameTime)
        {
            //Nothing
        }

        public void Damage()
        {
            enemyHealth--;
            if (enemyHealth <= 0) enemyState = -1;
            else soundEffectList[(int)SoundEffects.EnemyHit].Play();
        }

        private void Die()
        {
            Game1.enemyDieList.Add(this);
        }

        public Rectangle GetHurtbox()
        {
            Vector2 wH = RopeSprite.GetWidthHeight();
            return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)wH.X, (int)wH.Y);
        }

        public void Move(GameTime gameTime)
        {
            enemyPosition.X += enemyDirection.X;
            enemyPosition.Y += enemyDirection.Y;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            RopeSprite.Draw(_spriteBatch, enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            StateHandler(gameTime);
            if (enemyState == 0) MovementUpdate(gameTime);
            RopeSprite.Update(gameTime, enemyState, false);
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
