using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Graphics;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using System.IO;
using Microsoft.Xna.Framework.Content;
using LOZ.Tools.Interfaces;

namespace LOZ.Tools
{
    internal class Slime : Enemy
    {
        Rectangle anim;

        Vector2 enemyDirection;
        Vector2 enemyPosition;

        readonly Random rand = new();

        double moveCheck;
        double moveTime;
        double moveProb;

        const double moveDelay = 1000;

        public Slime(int X, int Y)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;

            enemyPosition.X = X;
            enemyPosition.Y = Y;

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

        public void Move(GameTime gameTime)
        {
            enemyPosition.X += (float)(enemyDirection.X * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
            enemyPosition.Y += (float)(enemyDirection.Y * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(
                Game1.REGULAR_ENEMIES,
                enemyPosition,
                anim,
                Color.White,
                0f,
                new Vector2(anim.Width / 2, anim.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );

            _spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            MovementUpdate(gameTime);
            AnimationUpdate(gameTime);
        }

        private void AnimationUpdate(GameTime gameTime)
        {
            Rectangle[] SlimeFrames = new[] { new Rectangle(1, 11, 8, 16), new Rectangle(10, 11, 8, 16) };
            anim = SlimeFrames[(int)(gameTime.TotalGameTime.TotalMilliseconds / 100) % 2];
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