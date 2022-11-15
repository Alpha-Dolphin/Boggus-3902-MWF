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

        Vector2 originalPosition;

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

            originalPosition = new(X, Y);

            enemyState = 0;
        }
        public Rectangle GetHurtbox()
        {
            Vector2 wH = new(5,5);
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
            enemyPosition.X += enemyDirection.X * enemyState / 2;
            enemyPosition.Y += enemyDirection.Y * enemyState / 2;
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
            if ((enemyState == -1) 
                && Rectangle.Intersect(new Rectangle(GetHurtbox().X, GetHurtbox().Y, 1, 1), new Rectangle((int) originalPosition.X, (int) originalPosition.Y, 1, 1)) != new Rectangle())
            {
                enemyState = 0;
                enemyDirection = new Vector2(0, 0);
            }
            Rectangle linkRect = new((int)Link.position.X + 8, (int)Link.position.Y + 8, 2, 2);
            Rectangle enemyRect = GetHurtbox();
            if (enemyState == 0 &&
                    (
                        Rectangle.Intersect(new Rectangle(-50, (int)enemyPosition.Y, 1000, 16), linkRect) != new Rectangle()
                        ||
                        Rectangle.Intersect(new Rectangle((int)enemyPosition.X, -50, 16, 1000), linkRect) != new Rectangle()
                    )
                )
            {
                originalPosition = new(GetHurtbox().X, GetHurtbox().Y);
                enemyDirection = new(0, 0);
                enemyState = 4;
                if (Rectangle.Intersect(new Rectangle(-50, (int)enemyPosition.Y, 1000, 16), linkRect) != new Rectangle())
                {
                    if (enemyRect.Left > linkRect.Left) enemyDirection.X = -1;
                    else enemyDirection.X = 1;
                }
                else
                {
                    if (enemyRect.Top > linkRect.Top) enemyDirection.Y = -1;
                    else enemyDirection.Y = 1;
                }
            }
        }
    }
}
