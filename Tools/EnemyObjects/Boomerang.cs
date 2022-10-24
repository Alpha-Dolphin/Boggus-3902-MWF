using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.EnemyObjects
{
    internal class Boomerang : IEnemy, ICollidable
    {
        Vector2 enemyDirection;
        Vector2 enemyPosition;

        //readonly BoomerangSprite boomerangSprite;
        AnimatedMovingSprite boomerangSprite;

        const int attackLength = 3000;
        double attackTime;
        public void SetHurtbox(int x, int y)
        {
            enemyPosition.X = x;
            enemyPosition.Y = y;
        }

        public Boomerang()
        {
            attackTime = -1;

            boomerangSprite = new AnimatedMovingSprite(Game1.REGULAR_ENEMIES, (int)enemyPosition.X, (int)enemyPosition.Y,
                new List<Rectangle> { new Rectangle(290, 11, 8, 16), new Rectangle(299, 11, 8, 16), new Rectangle(308, 11, 8, 16) });
        }
        public Rectangle GetHurtbox()
        {
            Vector2 wH = new Vector2(boomerangSprite.GetDestinationRectangle().Width, boomerangSprite.GetDestinationRectangle().Height);
            return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)wH.X, (int)wH.Y);
        }

        public void Move(GameTime gameTime)
        {
            int boomerangSpeedRecip = 25;
            if (attackTime > attackLength / 2)
            {
                if (enemyDirection.X < 0) enemyPosition.X -= (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
                else if (enemyDirection.X > 0) enemyPosition.X += (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
                else if (enemyDirection.Y < 0) enemyPosition.Y -= (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
                else enemyPosition.Y += (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
            }
            else
            {
                if (enemyDirection.X > 0) enemyPosition.X -= (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
                else if (enemyDirection.X < 0) enemyPosition.X += (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
                else if (enemyDirection.Y > 0) enemyPosition.Y -= (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
                else enemyPosition.Y += (float)(gameTime.ElapsedGameTime.TotalMilliseconds / boomerangSpeedRecip);
            }
            attackTime -= gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public void Die()
        {
            lm.enemyList.Remove(this);
        }

        public void Attack(GameTime gameTime)
        {
            //Nothing
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            boomerangSprite.Draw(_spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            Move(gameTime);
            boomerangSprite.Update((int)enemyPosition.X, (int)enemyPosition.Y);
        }

        public double GetAttackTime()
        {
            return attackTime;
        }

        public void Activate(Vector2 eD, Vector2 eP)
        {
            enemyPosition = eP;
            enemyDirection = eD;
            attackTime = attackLength;
        }
    }
}
