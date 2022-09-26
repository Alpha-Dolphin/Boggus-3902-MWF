using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace LOZ.Tools.ItemObjects
{
    internal class Compass : IItem
    {


        private Rectangle animation;
        private Vector2 position;
        private Vector2 size;
        private StationaryStaticSprite sprite;
        private Vector2 DefaultSize = new Vector2(16, 16);
        public Compass(Texture2D spritesheet, int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
            this.sprite.initialize();
            this.sprite.loadSpriteSheet(spritesheet);
            this.sprite.setPositionRectangle(x, y, (int)DefaultSize.X, (int)DefaultSize.Y);
            this.sprite.setFrameRectangle(257, 1, 16, 16);

        }


        public void Draw(SpriteBatch _spritebatch)
        {

            this.sprite.draw(_spritebatch);

        }

        public void Update(GameTime gametime)
        {


        }

    }
}
