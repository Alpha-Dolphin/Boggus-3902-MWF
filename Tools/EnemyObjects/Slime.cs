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

        Vector2 direction;
        Vector2 position;

        readonly Random rand;

        bool animState;
        double animCounter;

        double moveCheck;
        double moveTime;
        double moveProb;

        const double moveDelay = 1000;

        public Slime(int width, int height)
        {
            position.X = width / 2;
            position.Y = height / 2;
            direction.X = 0;
            direction.Y = 0;
            animCounter = 0.0;
            moveCheck = -1;
            rand = new();
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
                SpriteEffects.None,
                0f
            );

            _spriteBatch.End();
        }

        public void Update(GameTime gameTime)
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
                    direction.X = 0;
                    direction.Y = 0;
                }
            }

            Rectangle SlimeSquished = new(1, 11, 8, 16);
            Rectangle SlimeStreched = new(10, 11, 8, 16);
            if (animCounter + 0.2 < gameTime.TotalGameTime.TotalSeconds)
            {
                anim = (animState) ? SlimeSquished : SlimeStreched;
                animState = !animState;
                animCounter = gameTime.TotalGameTime.TotalSeconds;
            }
            animCounter -= gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
