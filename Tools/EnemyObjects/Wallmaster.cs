using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using LOZ.Tools;
using LOZ.Tools.Sprites;
using LOZ.Tools.PlayerObjects;
using System.Collections;
using Microsoft.Xna.Framework.Audio;

namespace LOZ.Tools
{
    internal class Wallmaster : IEnemy, ICollidable
    {
        readonly private List<SoundEffect> soundEffectList = Game1.soundEffectList;
        Vector2 enemyDirection; Vector2 enemyPosition;

        readonly ISpriteEnemy wallMasterSprite;
        private Vector2 prevEnemyPos;
        Vector2 prevLinkPos;
        
        int enemyHealth;
        
        int enemyState;

        double stateTime;

        public void SetHurtbox(Rectangle rect)
        {
            enemyPosition.Y = rect.Y;
            enemyPosition.X = rect.X;
        }
        public Wallmaster(int X, int Y)
        {
            enemyDirection.X = 1;
            enemyDirection.Y = 0;

            wallMasterSprite = new EnemySprite(Game1.REGULAR_ENEMIES_SPRITESHEET, new[] { new Rectangle(393, 11, 16, 16), new Rectangle(410, 11, 16, 16) });

            enemyPosition.Y = Y;
            enemyPosition.X = X;

            enemyHealth = 1;

            enemyState = 1;

            stateTime = 0.0;
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

        public void Damage()
        {
            enemyHealth--;
            if (enemyHealth <= 0) enemyState = -1;
        }

        private void Die()
        {
            Game1.enemyDieList.Add(this);
            soundEffectList[(int)SoundEffects.EnemyDie].Play();
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
            StateHandler(gameTime);
            wallMasterSprite.Update(gameTime, enemyState);
            if (enemyState == 0) MovementUpdate(gameTime);
        }

        private void StateHandler(GameTime gameTime)
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
                    Die();
                }
            }
        }
        private void MovementUpdate(GameTime gameTime)
        {
            //In the future, implement some code if there is an object between Link and the wallmasters
/*            if (prevEnemyPos != enemyPosition && prevLinkPos == Link.position)
            {*/
                if ((enemyDirection.X != 0 && prevLinkPos.Y * enemyDirection.X < Link.position.Y) || (enemyDirection.Y != 0 && prevLinkPos.X * enemyDirection.Y < Link.position.X))
                {
                    enemyDirection = new(0, 0);
                    Rectangle linkRect = new((int)Link.position.X + 4, (int)Link.position.Y + 4, 8, 8);
                    Rectangle enemyRect = GetHurtbox();
                    Rectangle dist = Rectangle.Union(enemyRect, linkRect);
                    if (dist.Bottom - dist.Top < dist.Right - dist.Left)
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
/*            }
            else
            {
                (enemyDirection.X, enemyDirection.Y) = (enemyDirection.Y, enemyDirection.X);
            }
            prevEnemyPos = enemyPosition;*/
            prevLinkPos = Link.position;
        }
    }
}