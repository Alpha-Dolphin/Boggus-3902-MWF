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

namespace LOZ
{
    internal class Keese : Enemy
    {
        Rectangle anim;

        Vector2 enemyDirection;
        Vector2 enemyPosition;

        readonly Random rand = new();

        double moveCounter;
        double timeToMove;
        double moveCheck;

        public Keese(int X, int Y)
        {
            enemyDirection.X = rand.Next() % 400 / 100 - 2;
            enemyDirection.Y = rand.Next() % 400 / 100 - 2;

            enemyPosition.X = X;
            enemyPosition.Y = Y;

            moveCounter = 0.0;

            timeToMove = 0.0;
            moveCheck = 0.0;
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
            Rectangle[] KeeseFrames = new[] { new Rectangle(183, 11, 16, 16), new Rectangle(200, 11, 16, 16) };
            anim = KeeseFrames[(int)(gameTime.TotalGameTime.TotalMilliseconds / 100) % 2];
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
