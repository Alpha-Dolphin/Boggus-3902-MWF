using LOZ.Tools;
using Microsoft.Xna.Framework;
using System;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using LOZ.Tools.EnemyObjects;
using LOZ.Tools.Sprites;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using LOZ.Tools.LevelManager;

namespace LOZ.Tools
{
    internal class EnemySpawner : IEnemy, ICollidable
    {
        private List<SoundEffect> soundEffectList = Game1.soundEffectList;
        readonly Random rand = new();

        Vector2 enemyDirection; Vector2 enemyPosition;
        readonly ISpriteEnemy spawnerSprite;

        int enemyState;
        double stateTime;

        double attackTimer;
        double attackCooldown;

        readonly EnemyFactory enemyFactory;

        int enemyHealth;
        public void SetHurtbox(Rectangle rect)
        {
            enemyPosition.Y = rect.Y;
            enemyPosition.X = rect.X;
        }
        public EnemySpawner(int X, int Y)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;

            enemyPosition.Y = Y;
            enemyPosition.X = X;

            spawnerSprite = new EnemySprite(Game1.SPAWNER, new[] { new Rectangle(0, 0, 16, 16)});

            enemyFactory = new();

            enemyHealth = 1;
            
            attackTimer = 0;
            attackCooldown = 0;

            stateTime = 0.0;
            enemyState = 1;
        }

        public Rectangle GetHurtbox()
        {
            Vector2 wH = spawnerSprite.GetWidthHeight();
            return new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)wH.X, (int)wH.Y);
        }

        public void Attack(GameTime gameTime)
        {
            int enem = 6;
            while (enem == 6 || enem >= 9) enem = rand.Next(0, 9);
            enemyFactory.curr = enem;
            IEnemy newEnem = enemyFactory.NewEnemy();
            newEnem.SetHurtbox(new Rectangle((int) enemyPosition.X, (int) enemyPosition.Y, -1, -1));
            Game1.enemyNewList.Add(newEnem);
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
            //No movement
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            spawnerSprite.Draw(_spriteBatch, enemyPosition);
        }

        public void Update(GameTime gameTime)
        {
            StateHandler(gameTime);
            if (enemyState == 0) AttackUpdate(gameTime);
            spawnerSprite.Update(gameTime, enemyState);
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
        private void AttackUpdate(GameTime gameTime)
        {
            if (attackCooldown <= 0)
            {
                attackCooldown = 250;
                if (rand.Next() % 4950 + 50 < attackTimer)
                {
                    attackTimer = 0;
                    Attack(gameTime);
                }
                else
                {
                    attackTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
                }
            }
            else
            {
                attackCooldown -= gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
    }
}
