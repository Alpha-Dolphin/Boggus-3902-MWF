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

namespace LOZ.Tools.EnemyObjects
{
    internal class Keese : Enemy
    {
        Rectangle anim;

        Vector2 direction;
        Vector2 position;
        readonly Random rand = new();

        bool animState;

        double animCounter;
        double moveCounter;
        double timeToMove;
        double moveCheck;

        public Keese(int width, int height)
        {
            position.X = width / 2;
            position.Y = height / 2;
            direction.X = rand.Next() % 400 / 100 - 2;
            direction.Y = rand.Next() % 400 / 100 - 2;
            moveCounter = 0.0;
            animCounter = 0.0;
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
                position.X += direction.X;
                position.Y += direction.Y;
            }
            else
            {
                direction.X = rand.Next() % 400 / 100 - 2;
                direction.Y = rand.Next() % 400 / 100 - 2;
            }
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
            if (moveCheck <= 0) {
                if (moveCounter < 0 && (rand.Next(50, 5000)) < timeToMove)
                {
                    moveCounter = rand.NextInt64(100, 500);
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
            Rectangle KeeseSpread = new Rectangle(183, 11, 16, 16);
            Rectangle KeeseFolded = new Rectangle(200, 11, 16, 16);
            if (animCounter + 0.2 < gameTime.TotalGameTime.TotalSeconds)
            {
                anim = animState ? KeeseSpread : KeeseFolded;
                animState = !animState;
                animCounter = gameTime.TotalGameTime.TotalSeconds;
            }
            animCounter -= gameTime.ElapsedGameTime.TotalSeconds;
            moveCounter -= gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}