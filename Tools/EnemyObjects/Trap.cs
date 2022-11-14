using LOZ.Tools.EnemyObjects.LOZ.Tools;
using Microsoft.Xna.Framework;
using System;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace LOZ.Tools
{
    internal class Trap : IEnemy, ICollidable
    {
        Vector2 enemyDirection; Vector2 enemyPosition;
        //readonly ISpriteEnemy slimeSprite;
        readonly TrapSprite trapSprite;

        readonly Random rand;

        double moveCheck;
        double moveTime;
        double moveProb;

        public bool grabbed;

        const double moveDelay = 1000;
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

            moveCheck = -1;
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
            enemyPosition.X += enemyDirection.X;
            enemyPosition.Y += enemyDirection.Y;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            trapSprite.Draw(_spriteBatch, enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            MovementUpdate(gameTime);
            trapSprite.Update(grabbed);
        }

        private void MovementUpdate(GameTime gameTime)
        {
            //A
        }
    }
}
