using LOZ.Tools.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.EnemyObjects
{
    internal class Zol : Enemy
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

        public Zol(int width, int height)
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

            Rectangle ZolSquished = new(77, 11, 16, 16);
            Rectangle ZolStreched = new(94, 11, 16, 16);
            if (animCounter + 0.2 < gameTime.TotalGameTime.TotalSeconds)
            {
                anim = (animState) ? ZolSquished : ZolStreched;
                animState = !animState;
                animCounter = gameTime.TotalGameTime.TotalSeconds;
            }
            animCounter -= gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}