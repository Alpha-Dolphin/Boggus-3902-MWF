﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace LOZ.Tools.ItemObjects
{
    internal class BluePotion : IItem
    {
        private Vector2 position;
        private StationaryAnimatedSprite sprite = new();
        private Vector2 DefaultSize = new(8, 16);
        public BluePotion(Texture2D spritesheet, int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
            this.sprite.initialize();
            this.sprite.loadSpriteSheet(spritesheet);
            this.sprite.setPositionRectangle(x, y, (int)DefaultSize.X * 2, (int)DefaultSize.Y * 2);
            this.sprite.setFrameRectangle(80, 16, (int)DefaultSize.X, (int)DefaultSize.Y);
        }


        public void Draw(SpriteBatch _spriteBatch)
        {

            this.sprite.draw(_spriteBatch);

        }

        public void Update(GameTime gametime)
        {
            this.sprite.updateCurrentFrame(gametime);

        }

    }
}