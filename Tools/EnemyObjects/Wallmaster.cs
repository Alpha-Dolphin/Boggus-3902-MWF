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
using LOZ.Tools.PlayerObjects;
using System.Collections;

namespace LOZ.Tools
{
    internal class Wallmaster : IEnemy, ICollidable
    {
        Vector2 enemyDirection; Vector2 enemyPosition;
        //readonly ISpriteEnemy slimeSprite;
        readonly WallMasterSprite wallMasterSprite;

        double prevLinkValue;

        public bool grabbed;

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

            enemyPosition.Y = Y;
            enemyPosition.X = X;
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
            if ((enemyDirection.X != 0 && enemyPosition.X == Link.position.X) || (enemyDirection.Y != 0 && enemyPosition.Y == Link.position.Y))
            {
                enemyDirection = new(0, 0);
                Rectangle linkRect = new((int)Link.position.X, (int)Link.position.Y, 16, 16);
                Rectangle dist = Rectangle.Union(GetHurtbox(), linkRect);
                if (dist.Bottom - dist.Top > dist.Right - dist.Left)
                {
                    if (dist.Right == linkRect.Right) enemyDirection.X = 1;
                    else enemyDirection.X = -1;
                }
                else
                {
                    if (dist.Bottom == linkRect.Bottom) enemyDirection.Y = 1;
                    else enemyDirection.Y = -1;
                }
            }
        }
    }
}