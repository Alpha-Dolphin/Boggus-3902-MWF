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
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using LOZ.Tools.Sprites;

namespace LOZ.Tools.ItemObjects
{
    internal class Bomb : IItem
    {
        private Vector2 position;
        private Sprite sprite;
        private Vector2 DefaultSize = new(8, 16);
        public void setPlacement(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }
        public Bomb(Texture2D spritesheet, int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
            this.sprite = new Sprite(Game1.ITEM_SPRITESHEET, x, y,
                new List<Rectangle>() { new Rectangle(136, 0, (int)DefaultSize.X, (int)DefaultSize.Y) });
        }


        public void Draw(SpriteBatch _spriteBatch)
        {

            this.sprite.Draw(_spriteBatch);

        }

        public void Update(GameTime gametime)
        {


        }

    }
}
