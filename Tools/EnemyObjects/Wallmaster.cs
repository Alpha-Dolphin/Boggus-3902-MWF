using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using LOZ.Tools;
using LOZ.Tools.Sprites;
using LOZ.Tools.EnemyObjects.LOZ.Tools;

namespace LOZ.Tools
{
    internal class Wallmaster : IEnemy, ICollidable
    {
        Vector2 enemyDirection; Vector2 enemyPosition;
        //readonly ISpriteEnemy slimeSprite;
        readonly WallMasterSprite wallMasterSprite;

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
        public Wallmaster(int X, int Y)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;

            wallMasterSprite = new WallMasterSprite();

            rand = new();

            enemyPosition.Y = Y;
            enemyPosition.X = X;

            moveCheck = -1;
        }
        public Rectangle GetHurtbox()
        {
            Vector2 wH = wallMasterSprite.GetWidthHeight();
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
            wallMasterSprite.Draw(_spriteBatch, enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            MovementUpdate(gameTime);
            wallMasterSprite.Update(grabbed);
        }

        private void MovementUpdate(GameTime gameTime)
        {
            //A
        }
    }
}
