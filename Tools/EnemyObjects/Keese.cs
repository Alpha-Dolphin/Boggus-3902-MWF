using LOZ.Tools;
using Microsoft.Xna.Framework;
using System;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using LOZ.Tools.EnemyObjects;
using LOZ.Tools.Sprites;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;

namespace LOZ.Tools
{
    internal class Keese : IEnemy, ICollidable
    {
        readonly private List<SoundEffect> soundEffectList = Game1.soundEffectList;
        readonly Random rand = new();

        Vector2 enemyDirection; Vector2 enemyPosition;
        readonly ISpriteEnemy keeseSprite;

        double moveCounter;
        double timeToMove;
        double moveCheck;

        int enemyState;
        double stateTime;

        int enemyHealth;
        public void SetHurtbox(Rectangle rect)
        {
            enemyPosition.Y = rect.Y;
            enemyPosition.X = rect.X;
        }
        public Keese(int X, int Y)
        {
            enemyDirection.X = rand.Next() % 400 / 100 - 2;
            enemyDirection.Y = rand.Next() % 400 / 100 - 2;

            enemyPosition.Y = Y;
            enemyPosition.X = X;

            keeseSprite = new EnemySprite(Game1.REGULAR_ENEMIES_SPRITESHEET, new[] { new Rectangle(183, 11, 16, 16), new Rectangle(200, 11, 16, 16) });

            enemyHealth = 1;

            stateTime = 0.0;
            enemyState = 1;

            moveCounter = 0.0;
            timeToMove = 0.0;
            moveCheck = 0.0;
        }

        public Rectangle GetHurtbox()
        {
            Vector2 wH = keeseSprite.GetWidthHeight();
            return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)wH.X, (int)wH.Y);
        }

        public void Attack(GameTime gameTime)
        {
            //Nothing
        }

        public void Damage()
        {
            enemyHealth--;
            if (enemyHealth <= 0) enemyState = -1;
        }

        private void Die()
        {
            Game1.enemyDieList.Add(this);
            soundEffectList[(int)SoundEffects.EnemyDie].Play();
        }

        public void Move(GameTime gameTime)
        {
            if (0 < moveCounter)
            {
                enemyPosition.X += (float)(enemyDirection.X * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
                enemyPosition.Y += (float)(enemyDirection.Y * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
            }
            else
            {
                enemyDirection.X = rand.Next() % 400 / 100 - 2;
                enemyDirection.Y = rand.Next() % 400 / 100 - 2;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            keeseSprite.Draw(_spriteBatch, enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            StateHandler(gameTime);
            if (enemyState == 0) MovementUpdate(gameTime);
            keeseSprite.Update(gameTime, enemyState);
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
            if (moveCheck <= 0)
            {
                if (moveCounter < 0 && rand.Next() % 4950 + 50 < timeToMove)
                {
                    moveCounter = rand.Next() % 400 + 100;
                    timeToMove = 0;
                }
                else if (moveCounter < 0)
                {
                    moveCheck = 5;
                    timeToMove += moveCheck;
                }
            }
            else
            {
                moveCheck -= gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            moveCounter -= gameTime.ElapsedGameTime.TotalMilliseconds;
        }
    }
}
