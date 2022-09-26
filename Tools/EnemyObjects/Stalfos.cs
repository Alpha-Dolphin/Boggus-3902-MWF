using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;
using SharpDX.Direct3D9;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using System.IO;
using Microsoft.Xna.Framework.Content;

namespace Workspace
{
    internal class Stalfos : Enemy
    {
        Rectangle anim;

        Vector2 direction;
        Vector2 position;
        readonly Random rand = new();

        bool animState;

        double animCounter;
        double moveCheck;

        public Stalfos(int width, int height)
        {
            position.X = width / 2;
            position.Y = height / 2;
            direction.X = 0;
            direction.Y = 0;
            animCounter = 0.0;
            moveCheck = -1;
            anim = new Rectangle(1, 59, 16, 16);
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
                Game1.Sheet1,
                position,
                anim,
                Color.White,
                0f,
                new Vector2(anim.Width / 2, anim.Height / 2),
                Vector2.One,
                animState ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0f
            );

            _spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            if (moveCheck <= 0) {
                moveCheck = 25;
                if (true)
                {
                    //Please just let not zero equal true
                    int speed = 1;

                    if (rand.Next() % 2 == 1) {
                        if (rand.Next() % 2 == 1) direction.X = speed; 
                        else direction.X = -speed; 
                    } else direction.X = 0;

                    if (rand.Next() % 2 == 1){ 
                        if (rand.Next() % 2 == 1) direction.Y = speed;
                        else direction.Y = -speed;
                    } else direction.Y = 0;

                    moveCheck = 1000;
                }
            } else
            {
                moveCheck -= gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            if (animCounter + 0.2 < gameTime.TotalGameTime.TotalSeconds)
            {
                animState = !animState;
                animCounter = gameTime.TotalGameTime.TotalSeconds;
            }
            animCounter -= gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
