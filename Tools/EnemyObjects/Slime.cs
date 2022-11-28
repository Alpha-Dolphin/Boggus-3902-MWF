using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using LOZ.Tools;
using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework.Audio;

namespace LOZ.Tools
{
    internal class Slime : IEnemy, ICollidable
    {
        readonly private List<SoundEffect> soundEffectList = Game1.soundEffectList;
        Vector2 enemyDirection; Vector2 enemyPosition;
        readonly ISpriteEnemy slimeSprite;

        readonly Random rand;

        double moveCheck;
        double moveTime;
        double moveProb;

        int enemyState;

        int enemyHealth;
        double healthTimer;

        double stateTime;

        const double moveDelay = 1000;
        public void SetHurtbox(Rectangle rect)
        {
            enemyPosition.Y = rect.Y;
            enemyPosition.X = rect.X;
        }
        public Slime(int X, int Y)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;

            slimeSprite = new EnemySprite(Game1.REGULAR_ENEMIES_SPRITESHEET, new[] { new Rectangle(1, 11, 8, 16), new Rectangle(10, 11, 8, 16) });

            rand = new();

            enemyState = 1;

            enemyHealth = 2;
            healthTimer = 0f;

            stateTime = 0.0;

            enemyPosition.Y = Y;
            enemyPosition.X = X;

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

        private void Die()
        {
            Game1.enemyDieList.Add(this);
            soundEffectList[(int)SoundEffects.EnemyDie].Play();
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
            StateHandler(gameTime);
            if (enemyState == 0) MovementUpdate(gameTime);
            slimeSprite.Update(gameTime, enemyState);
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
