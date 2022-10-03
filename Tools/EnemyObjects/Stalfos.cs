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
using LOZ;

namespace Workspace
{
    internal class Stalfos : Enemy
    {
        Rectangle anim;

        Vector2 direction;
        Vector2 position;

        readonly Random rand = new();

        SpriteEffects animState;

        double moveCheck;
        double moveTime;
        double moveProb;

        public Stalfos(int X, int Y)
        {
            anim = new Rectangle(1, 59, 16, 16);

            position.X = X;
            position.Y = Y;

            direction.X = 0;
            direction.Y = 0;

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
            position.X += direction.X;
            position.Y += direction.Y;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(
                Game1.REGULAR_ENEMIES,
                position,
                anim,
                Color.White,
                0f,
                new Vector2(anim.Width / 2, anim.Height / 2),
                Vector2.One,
                animState,
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
            animState = (((int)(gameTime.TotalGameTime.TotalMilliseconds / 100) % 2) == 0) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
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
                        if (rand.Next() % 2 == 1) direction.X = speed;
                        else direction.X = -speed;
                        direction.Y = 0;
                    }
                    else
                    {
                        if (rand.Next() % 2 == 1) direction.Y = speed;
                        else direction.Y = -speed;
                        direction.X = 0;
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
