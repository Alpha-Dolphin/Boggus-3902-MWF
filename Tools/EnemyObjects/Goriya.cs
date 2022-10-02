using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;

using Microsoft.Xna.Framework.Graphics;

using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using System.IO;
using Microsoft.Xna.Framework.Content;

using LOZ.Tools.Interfaces;

namespace LOZ
{

    internal class Goriya : Enemy
    {
        Rectangle anim;

        Vector2 enemyDirection;
        Vector2 enemyPosition;
        SpriteEffects enemySpriteEffect;

        Rectangle boomerang;
        float boomerangRotation;

        Vector2 boomerangPosition;

        readonly Random rand;

        bool attacking;
        const int attackLength = 3000;
        double attackTime;

        bool animState;
        double animCounter;

        double moveCheck;
        double moveTime;
        double moveProb;

        public Goriya(int width, int height)
        {
            enemyDirection.X = 0;
            enemyDirection.Y = 0;
            enemyPosition.X = width / 2;
            enemyPosition.Y = height / 2;

            rand = new();

            attacking = false;

            animState = false;
            animCounter = 0.0;
            moveCheck = -1;
        }

        public void Attack(GameTime gameTime)
        {
            //Leaving this in just in case the mathematical rotation/motion causes problems
            //Goodnight sweet prince
            //(int, SpriteEffects)[] boomerangFrame = new[] { (0, SpriteEffects.None), (1, SpriteEffects.None), (2, SpriteEffects.None), (1, SpriteEffects.FlipHorizontally), (0, SpriteEffects.FlipHorizontally), (1, SpriteEffects.None), (2, SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically), (1, SpriteEffects.FlipVertically) };
            Rectangle[] frames = new[] { new Rectangle(290, 11, 8, 16), new Rectangle(299, 11, 8, 16), new Rectangle(308, 11, 8, 16) };
            if (attackTime > attackLength / 2)
            {
                if (enemyDirection.X < 0) boomerangPosition.X--;
                else if (enemyDirection.X > 0) boomerangPosition.X++;
                else if (enemyDirection.Y < 0) boomerangPosition.Y--;
                else boomerangPosition.Y++;
            }
            else
            {
                if (enemyDirection.X > 0) boomerangPosition.X--;
                else if (enemyDirection.X < 0) boomerangPosition.X++;
                else if (enemyDirection.Y > 0) boomerangPosition.Y--;
                else boomerangPosition.Y++;
            }
            boomerang = frames[1];
            boomerangRotation = (float)((attackLength - attackTime) / 200 % 8 * Math.PI);
            attackTime -= gameTime.ElapsedGameTime.TotalMilliseconds;
            if (attackTime <= 0.0) attacking = false;
        }

        public void Die(GameTime gameTime)
        {
            //Nothing
        }

        public void Move(GameTime gameTime)
        {
            if (!attacking)
            {
                enemyPosition.X += enemyDirection.X;
                enemyPosition.Y += enemyDirection.Y;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(
                Game1.REGULAR_ENEMIES,
                enemyPosition,
                anim,
                Color.White,
                0f,
                new Vector2(anim.Width / 2, anim.Height / 2),
                Vector2.One,
                enemySpriteEffect,
                0f
            );

            if (attacking)
            {
                _spriteBatch.Draw(
                Game1.REGULAR_ENEMIES,
                boomerangPosition,
                boomerang,
                Color.White,
                boomerangRotation,
                new Vector2(boomerang.Width / 2, boomerang.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0
            );
            }

            _spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            if (!attacking) MovementUpdate(gameTime);
            AnimationUpdate(gameTime);
            AttackUpdate(gameTime);
        }

        private void AttackUpdate(GameTime gameTime)
        {
            if (attacking) Attack(gameTime);
            else if (rand.Next() % 4950 <= 25)
            {
                attacking = true;
                attackTime = attackLength;
                boomerangPosition = enemyPosition;
            }
        }

        private void AnimationUpdate(GameTime gameTime)
        {
            Rectangle GoriyaUp = new(222, 11, 16, 16);
            Rectangle GoriyaDown = new(239, 11, 16, 16);
            Rectangle GoriyaSide = new(256, 11, 16, 16);
            Rectangle GoriyaSide2 = new(273, 11, 16, 16);

            //Currently this method does not know about nor care about if the enemy is attacking, which is a good thing, but probably hard to maintain
            if (enemyDirection.Y == 0) anim = (animState) ? GoriyaSide : GoriyaSide2;
            else if (enemyDirection.Y > 0) anim = GoriyaUp;
            else if (enemyDirection.Y < 0) anim = GoriyaDown;

            enemySpriteEffect = enemyDirection.Y != 0 ? (animState ? SpriteEffects.FlipHorizontally : SpriteEffects.None) : (enemyDirection.X < 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None);

            if (animCounter + 0.2 < gameTime.TotalGameTime.TotalSeconds)
            {
                animState = !animState;
                animCounter = gameTime.TotalGameTime.TotalSeconds;
            }
            animCounter -= gameTime.ElapsedGameTime.TotalSeconds;
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