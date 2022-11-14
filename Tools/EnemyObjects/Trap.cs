using LOZ.Tools.EnemyObjects.LOZ.Tools;
using LOZ.Tools.PlayerObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace LOZ.Tools
{
    internal class Trap : IEnemy, ICollidable
    {
        Vector2 enemyDirection; Vector2 enemyPosition;
        //readonly ISpriteEnemy slimeSprite;
        readonly TrapSprite trapSprite;

        int enemyState;

        public void SetHurtbox(Rectangle rect)
        {
            enemyPosition.Y = rect.Y;
            enemyPosition.X = rect.X;
        }
        public Trap(int X, int Y)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;

            trapSprite = new TrapSprite();

            enemyPosition.Y = Y;
            enemyPosition.X = X;

        }
        public Rectangle GetHurtbox()
        {
            Vector2 wH = trapSprite.GetWidthHeight();
            return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)wH.X, (int)wH.Y);
        }
        public void Attack(GameTime gameTime)
        {
            //Nothing
        }

        public void Die()
        {
            Game1.lm.RoomList[Game1.currentRoom].enemyList.Remove(this);
        }

        public void Move(GameTime gameTime)
        {
            enemyPosition.X += enemyDirection.X * enemyState;
            enemyPosition.Y += enemyDirection.Y * enemyState;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            trapSprite.Draw(_spriteBatch, enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            MovementUpdate(gameTime);
            trapSprite.Update(gameTime, enemyState);
        }

        public void Collide(int enemyState)
        {
            this.enemyState = enemyState;
        }

        private void MovementUpdate(GameTime gameTime)
        {
            if (enemyState == 0 && ((enemyDirection.X != 0 && enemyPosition.X == Link.position.X) || (enemyDirection.Y != 0 && enemyPosition.Y == Link.position.Y)))
            {
                enemyState = 4;
                enemyDirection = new(0, 0);
                Rectangle linkRect = new((int)Link.position.X, (int)Link.position.Y, 16, 16);
                Rectangle trap = Rectangle.Union(GetHurtbox(), linkRect);
                if (trap.X == linkRect.X)
                {
                    if (trap.Right < linkRect.Left) enemyDirection.X = 1;
                    else enemyDirection.X = -1;
                }
                else
                {
                    if (trap.Top < linkRect.Bottom) enemyDirection.Y = -1;
                    else enemyDirection.Y = 1;
                }
            }
        }
    }
}
