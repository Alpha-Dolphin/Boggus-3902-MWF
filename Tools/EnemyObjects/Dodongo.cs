using LOZ.Tools.EnemyObjects;
using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.PlayerObjects;
using Microsoft.Xna.Framework.Audio;

namespace LOZ.Tools.PlayerObjects
{
    internal class Dodongo : IEnemy, ICollidable
    {
        private List<SoundEffect> soundEffectList = Game1.soundEffectList;
        Vector2 enemyDirection;
        EnemyConstants.Direction direction;
        bool directionChange = false;
        Vector2 enemyPosition;

        double stateTime;

        int enemyState;

        AnimatedMovingSprite dodongoSprite;

        readonly Random rand;

        const int attackLength = 3000;
        double attackTime;

        double moveCheck;
        double moveTime;
        double moveProb;
        public void SetHurtbox(Rectangle rect)
        {
            enemyPosition.Y = rect.Y;
            enemyPosition.X = rect.X;
        }
        public Dodongo(int X, int Y)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;

            enemyPosition.Y = Y;
            enemyPosition.X = X;

            rand = new();

            enemyState = 1;

            stateTime = 0;

            attackTime = -1;

            dodongoSprite = new AnimatedMovingSprite(Game1.BOSSES_SPRITESHEET, (int) enemyPosition.X, (int) enemyPosition.Y, 
                new List<Rectangle>() { new Rectangle(1, 58, 16, 16), new Rectangle(35, 58, 16, 16) });

            moveCheck = -1;
        }

        public void Attack(GameTime gameTime)
        {

        }

        public void Die()
        {
            enemyState = -1;
            soundEffectList[(int)SoundEffects.DodongoScream].Play();
        }

        public void DeleteEnemy()
        {
            Game1.enemyDieList.Add(this);
        }
        public Rectangle GetHurtbox()
        {
            Vector2 wH = new Vector2(dodongoSprite.GetDestinationRectangle().Width, dodongoSprite.GetDestinationRectangle().Height);
            return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)wH.X, (int)wH.Y);
        }

        public void Move(GameTime gameTime)
        {
            EnemyConstants.Direction temp;

            if (attackTime < 0.0)
            {
                enemyPosition.X += (float)(enemyDirection.X * gameTime.ElapsedGameTime.TotalMilliseconds / 25);
                enemyPosition.Y += (float)(enemyDirection.Y * gameTime.ElapsedGameTime.TotalMilliseconds / 25);

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
            dodongoSprite.Draw(_spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            stateHandler(gameTime);
            if (enemyState == 0)
            {
                dodongoSprite.Update((int)enemyPosition.X, (int)enemyPosition.Y);
                AttackUpdate(gameTime);
                if (attackTime < 0.0) MovementUpdate(gameTime);
            }

            if (directionChange)
            {
                switch (direction)
                {
                    case EnemyConstants.Direction.Up:
                        dodongoSprite = new AnimatedMovingSprite(Game1.REGULAR_ENEMIES_SPRITESHEET,
                        (int)enemyPosition.X, (int)enemyPosition.Y, EnemyConstants.GORIYA_UP); break;
                    case EnemyConstants.Direction.Left:
                        dodongoSprite = new AnimatedMovingSprite(Game1.REGULAR_ENEMIES_SPRITESHEET,
                        (int)enemyPosition.X, (int)enemyPosition.Y, EnemyConstants.GORIYA_LEFT); break;
                    case EnemyConstants.Direction.Right:
                        dodongoSprite = new AnimatedMovingSprite(Game1.REGULAR_ENEMIES_SPRITESHEET,
                        (int)enemyPosition.X, (int)enemyPosition.Y, EnemyConstants.GORIYA_RIGHT); break;
                    case EnemyConstants.Direction.Down:
                        dodongoSprite = new AnimatedMovingSprite(Game1.REGULAR_ENEMIES_SPRITESHEET,
                        (int)enemyPosition.X, (int)enemyPosition.Y, EnemyConstants.GORIYA_DOWN); break;
                    case EnemyConstants.Direction.None:
                        dodongoSprite = new AnimatedMovingSprite(Game1.REGULAR_ENEMIES_SPRITESHEET,
                        (int)enemyPosition.X, (int)enemyPosition.Y, new List<Rectangle>() { dodongoSprite.GetSourceRectangle() }); break;
                }
            }

        }
        private void stateHandler(GameTime gameTime)
        {
            if (enemyState == 1)
            {
                stateTime += gameTime.ElapsedGameTime.TotalMilliseconds;
                if (stateTime > Constants.enemyEntryExitTime)
                {
                    stateTime = 0;
                    enemyState = 0;
                }
            }
            else if (enemyState == -1)
            {
                stateTime += gameTime.ElapsedGameTime.TotalMilliseconds;
                if (stateTime > Constants.enemyEntryExitTime)
                {
                    DeleteEnemy();
                }
            }
        }
        private void AttackUpdate(GameTime gameTime)
        {
            if (attackTime > 0.0) Attack(gameTime);
            else if (rand.Next() % 4950 <= 25 && false)
            {
                attackTime = attackLength;
            }
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

