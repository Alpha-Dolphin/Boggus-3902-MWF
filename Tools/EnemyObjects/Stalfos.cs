using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using System.IO;
using Microsoft.Xna.Framework.Content;
using LOZ.Tools;
using LOZ.Tools.Sprites;
using LOZ.Tools.EnemyObjects;
using System.Data;
using Microsoft.Xna.Framework.Audio;

namespace LOZ.Tools
{
    internal class Stalfos : IEnemy, ICollidable
    {
        private List<SoundEffect> soundEffectList = Game1.soundEffectList;
        Vector2 enemyDirection; Vector2 enemyPosition;
        readonly ISpriteEnemy stalfosSprite;
        int enemyState;
        double stateTime;

        readonly Random rand = new();

        double moveCheck;
        double moveTime;
        double moveProb;
        public void SetHurtbox(Rectangle rect)
        {
            enemyPosition.Y = rect.Y;
            enemyPosition.X = rect.X;
        }
        public Stalfos(int X, int Y)
        {

            enemyPosition.Y = Y;
            enemyPosition.X = X;

            enemyState = 1;
            stateTime = 0;

            stalfosSprite = new StalfosSprite();

            enemyDirection.X = 0;
            enemyDirection.Y = 0;

            moveCheck = -1;
        }

        public Rectangle GetHurtbox()
        {
            Vector2 wH = stalfosSprite.GetWidthHeight();
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
            soundEffectList[(int)SoundEffects.EnemyDie].Play();
        }

        public void Move(GameTime gameTime)
        {
            enemyPosition.X += enemyDirection.X;
            enemyPosition.Y += enemyDirection.Y;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            stalfosSprite.Draw(_spriteBatch, enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            if (enemyState == 0) MovementUpdate(gameTime);
            StateHandler(gameTime);
            stalfosSprite.Update(gameTime, enemyState);
        }

        private void StateHandler(GameTime gameTime)
        {
            if (enemyState == 1) {
                stateTime += gameTime.ElapsedGameTime.TotalMilliseconds;
                if (stateTime > Constants.enemyEntryExitTime)
                {
                    stateTime = 0;
                    enemyState = 0;
                }
            } else if (enemyState == -1)
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
