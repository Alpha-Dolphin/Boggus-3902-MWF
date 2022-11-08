using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using LOZ.Tools;
using LOZ.Tools.Sprites;

namespace LOZ.Tools
{
    internal class Slime : IEnemy, ICollidable
    {
        Vector2 enemyDirection; Vector2 enemyPosition;
        //readonly ISpriteEnemy slimeSprite;
        AnimatedMovingSprite slimeSprite;

        readonly Random rand;

        double moveCheck;
        double moveTime;
        double moveProb;

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

            slimeSprite = new AnimatedMovingSprite(Game1.REGULAR_ENEMIES_SPRITESHEET, (int)enemyPosition.X, (int)enemyPosition.Y,
                new List<Rectangle> { new Rectangle(1, 11, 8, 16), new Rectangle(10, 11, 8, 16) });

            rand = new();

            enemyPosition.Y = Y;
            enemyPosition.X = X;

            moveCheck = -1;
        }
        public Rectangle GetHurtbox()
        {
            Vector2 wH = new Vector2(slimeSprite.GetDestinationRectangle().Width, slimeSprite.GetDestinationRectangle().Height);
            return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)wH.X, (int)wH.Y);
        }
        public void Attack(GameTime gameTime)
        {
            //Nothing
        }

        public void Die()
        {
            Game1.enemyDieList.Add(this);
        }

        public void Move(GameTime gameTime)
        {
            enemyPosition.X += enemyDirection.X;
            enemyPosition.Y += enemyDirection.Y;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            slimeSprite.Draw(_spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            MovementUpdate(gameTime);
            slimeSprite.Update((int)enemyPosition.X, (int)enemyPosition.Y);
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
