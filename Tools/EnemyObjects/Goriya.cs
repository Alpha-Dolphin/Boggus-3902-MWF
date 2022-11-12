using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using LOZ.Tools.PlayerObjects;
using LOZ.Tools.EnemyObjects;
using LOZ.Tools.Sprites;

namespace LOZ.Tools
{
    internal class Goriya : IEnemy, ICollidable
    {
        Vector2 enemyDirection;
        EnemyConstants.Direction direction;
        bool directionChange = false;
        Vector2 enemyPosition;

        //readonly GoriyaSprite goriyaSprite;
        AnimatedMovingSprite goriyaSprite;

        //readonly EnemyObjects.Boomerang boomerang;
        PlayerObjects.Boomerang boomerang;

        readonly Random rand;

        double moveCheck;
        double moveTime;
        double moveProb;
        public void SetHurtbox(Rectangle rect)
        {
            enemyPosition.Y = rect.Y;
            enemyPosition.X = rect.X;
        }
        public Goriya(int X, int Y)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;
            direction = EnemyConstants.Direction.Down;

            enemyPosition.Y = Y;
            enemyPosition.X = X;

            rand = new();

            goriyaSprite = new AnimatedMovingSprite(Game1.REGULAR_ENEMIES_SPRITESHEET, (int)enemyPosition.X, (int)enemyPosition.Y,
                EnemyConstants.GORIYA_DOWN);

            moveCheck = -1;
        }

        public Rectangle GetHurtbox()
        {
            Vector2 wH = new Vector2(goriyaSprite.GetDestinationRectangle().Width, goriyaSprite.GetDestinationRectangle().Height);
            return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)wH.X, (int)wH.Y);
        }

        public void Attack(GameTime gameTime)
        {
            Vector2 velocity = new Vector2(0, 0);

            switch (this.direction)
            {
                case EnemyConstants.Direction.Up: velocity = new Vector2(0, -1); break;
                case EnemyConstants.Direction.Left: velocity = new Vector2(-1, 0); break;
                case EnemyConstants.Direction.Right: velocity = new Vector2(1, 0); break;
                case EnemyConstants.Direction.Down: velocity = new Vector2(0, 1); break;
            }

            boomerang = new PlayerObjects.Boomerang(Game1.LINK_SPRITESHEET, this, enemyPosition, PlayerConstants.BOOMERANG_SPEED * velocity);
        }

        public void Die()
        {
            Game1.enemyDieList.Add(this);
        }

        public void Move(GameTime gameTime)
        {
            EnemyConstants.Direction temp;
            if (boomerang == null)
            {
                Vector2 delta = new Vector2((float)(enemyDirection.X * gameTime.ElapsedGameTime.TotalMilliseconds / 25), (float)(enemyDirection.Y * gameTime.ElapsedGameTime.TotalMilliseconds / 25));
                if (Math.Abs(delta.X) > 0)
                {
                    temp = delta.X > 0 ? EnemyConstants.Direction.Right : EnemyConstants.Direction.Left;
                }
                else if (Math.Abs(delta.Y) > 0)
                {

                    temp = delta.Y > 0 ? EnemyConstants.Direction.Down : EnemyConstants.Direction.Up;
                }
                else
                {
                    temp = EnemyConstants.Direction.None;
                }

                directionChange = !temp.Equals(direction);
                direction = temp;

                enemyPosition += delta;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            goriyaSprite.Draw(_spriteBatch);
            if (boomerang != null) boomerang.Draw(_spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            goriyaSprite.Update((int)enemyPosition.X, (int)enemyPosition.Y);
            MovementUpdate(gameTime);
            AttackUpdate(gameTime);
            if (boomerang != null)
            {
                boomerang.Update();
                if (!boomerang.stillExists()) boomerang = null;
            }

            if (directionChange)
            {
                switch (direction)
                {
                    case EnemyConstants.Direction.Up:
                        goriyaSprite = new AnimatedMovingSprite(Game1.REGULAR_ENEMIES_SPRITESHEET,
                        (int)enemyPosition.X, (int)enemyPosition.Y, EnemyConstants.GORIYA_UP); break;
                    case EnemyConstants.Direction.Left:
                        goriyaSprite = new AnimatedMovingSprite(Game1.REGULAR_ENEMIES_SPRITESHEET,
                        (int)enemyPosition.X, (int)enemyPosition.Y, EnemyConstants.GORIYA_LEFT); break;
                    case EnemyConstants.Direction.Right:
                        goriyaSprite = new AnimatedMovingSprite(Game1.REGULAR_ENEMIES_SPRITESHEET,
                        (int)enemyPosition.X, (int)enemyPosition.Y, EnemyConstants.GORIYA_RIGHT); break;
                    case EnemyConstants.Direction.Down:
                        goriyaSprite = new AnimatedMovingSprite(Game1.REGULAR_ENEMIES_SPRITESHEET,
                        (int)enemyPosition.X, (int)enemyPosition.Y, EnemyConstants.GORIYA_DOWN); break;
                    case EnemyConstants.Direction.None:
                        goriyaSprite = new AnimatedMovingSprite(Game1.REGULAR_ENEMIES_SPRITESHEET,
                        (int)enemyPosition.X, (int)enemyPosition.Y, new List<Rectangle>() { goriyaSprite.GetSourceRectangle() }); break;
                }
            }
        }

        private void AttackUpdate(GameTime gameTime)
        {
            if (rand.Next() % 4950 <= 25) Attack(gameTime);
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
