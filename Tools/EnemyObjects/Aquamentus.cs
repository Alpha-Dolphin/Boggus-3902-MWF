using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ;
using LOZ.Tools.Sprites;

namespace LOZ.Tools
{
    internal class Aquamentus : IEnemy, ICollidable
    {
        
        Vector2 enemyDirection;
        Vector2 enemyPosition;

        //readonly ISpriteEnemy aquamentusSprite;
        AnimatedMovingSprite aquamentusSprite;

        readonly Random rand;

        Ball ball1;
        Ball ball2;
        Ball ball3;

        double moveCheck;
        double moveTime;
        double moveProb;
        public void SetHurtbox(Rectangle rect)
        {
            enemyPosition.Y = rect.Y;
            enemyPosition.X = rect.X;
        }
        public Aquamentus(int X, int Y)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;

            enemyPosition.Y = Y;
            enemyPosition.X = X;

            ball1 = new Ball(1);
            ball2 = new Ball(2);
            ball3 = new Ball(3);

            aquamentusSprite = new AnimatedMovingSprite(Game1.BOSSES_SPRITESHEET, (int) enemyPosition.X, (int) enemyPosition.Y, 
                new List<Rectangle>{ new Rectangle(1, 11, 24, 32), new Rectangle(26, 11, 24, 32), new Rectangle(51, 11, 24, 32), new Rectangle(76, 11, 24, 32) });

            rand = new();

            moveCheck = -1;
        }

        public void Attack(GameTime gameTime)
        {
            ball1.Activate(enemyPosition.X, enemyPosition.Y);
            ball2.Activate(enemyPosition.X, enemyPosition.Y);
            ball3.Activate(enemyPosition.X, enemyPosition.Y);
        }

        public void Die()
        {
            Game1.lm.RoomList[Game1.currentRoom].enemyList.Remove(this);
        }

        public void Move(GameTime gameTime)
        {
            enemyPosition.X += (float)(enemyDirection.X * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
            enemyPosition.Y += (float)(enemyDirection.Y * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
        }

        public Rectangle GetHurtbox()
        {
            Vector2 wH = new Vector2(aquamentusSprite.GetDestinationRectangle().Width, aquamentusSprite.GetDestinationRectangle().Height);
            return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)wH.X, (int)wH.Y);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            aquamentusSprite.Draw(_spriteBatch);
            if (ball1.GetBallLife() > 0.0)
            {
                ball1.Draw(_spriteBatch);
                ball2.Draw(_spriteBatch);
                ball3.Draw(_spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            MovementUpdate(gameTime);
            aquamentusSprite.Update((int) enemyPosition.X, (int) enemyPosition.Y);
            AttackUpdate(gameTime);
            if (ball1.GetBallLife() > 0.0)
            {
                ball1.Update(gameTime);
                ball2.Update(gameTime);
                ball3.Update(gameTime);
            }
            else
            {
                ball1.SetHurtbox(new Rectangle(-128, -128, -128, -128));
                ball2.SetHurtbox(new Rectangle(-128, -128, -128, -128));
                ball3.SetHurtbox(new Rectangle(-128, -128, -128, -128));
            }
        }

        private void AttackUpdate(GameTime gameTime)
        {
            if (ball1.GetBallLife() <= 0.0 && rand.Next() % 4950 <= 25) Attack(gameTime);
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

                    //Movement will always be X-based
                    if (true || rand.Next() % 2 == 1)
                    {
                        if (rand.Next() % 2 == 1) enemyDirection.X = speed;
                        else enemyDirection.X = -speed;
                        enemyDirection.Y = 0;
                    }
                    //No Y-movement for this enemy
                    /*else
                    {
                        if (rand.Next() % 2 == 1) enemyDirection.Y = speed;
                        else enemyDirection.Y = -speed;
                        enemyDirection.X = 0;
                    }*/

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
