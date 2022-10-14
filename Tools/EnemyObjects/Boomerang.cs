using LOZ.Tools.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.EnemyObjects
{
    internal class Boomerang : IEnemy
    {
        Vector2 enemyDirection;
        Vector2 enemyPosition;

        readonly BoomerangSprite boomerangSprite;

        const int attackLength = 3000;
        double attackTime;

        public Boomerang()
        {
            attackTime = -1;

            boomerangSprite = new BoomerangSprite();
        }
        public Rectangle GetRectangle()
        {
            Vector2 wH = boomerangSprite.GetWidthHeight();
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

        public void Die(GameTime gameTime)
        {
            //Nothing
        }

        public void Attack(GameTime gameTime)
        {
            //Nothing
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            boomerangSprite.Draw(_spriteBatch, enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            Move(gameTime);
            boomerangSprite.Update(gameTime, attackLength, attackTime);
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
