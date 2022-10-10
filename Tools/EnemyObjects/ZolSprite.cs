﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.EnemyObjects
{
    internal class ZolSprite : ISpriteEnemy
    {
        Rectangle anim;

        public void Draw(SpriteBatch _spriteBatch, Vector2 enemyPosition)
        {
            _spriteBatch.Draw(
                Game1.REGULAR_ENEMIES,
                enemyPosition,
                anim,
                Color.White,
                0f,
                new Vector2(anim.Width / 2, anim.Height / 2),
                2,
                SpriteEffects.None,
                0f
            );
        }
        public void Update(GameTime gameTime)
        {
            Rectangle[] SlimeFrames = new[] { new Rectangle(77, 11, 16, 16), new Rectangle(94, 11, 16, 16) };
            anim = SlimeFrames[(int)(gameTime.TotalGameTime.TotalMilliseconds / 100) % 2];
        }
    }
}