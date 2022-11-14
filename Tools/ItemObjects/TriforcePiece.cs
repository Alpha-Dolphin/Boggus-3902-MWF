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
    internal class TriforcePiece : IItem
    {
        private Vector2 position;
        private AnimatedMovingSprite sprite;
        private Vector2 DefaultSize = new(10, 10);

        public void SetPlacement(int x, int y)
        {
            position.X = x;
            position.Y = y;
            this.sprite.Update(x, y);
        }
        public TriforcePiece(Texture2D spritesheet, int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
            this.sprite = new AnimatedMovingSprite(Game1.ITEM_SPRITESHEET, x, y,
                new List<Rectangle>() { ItemConstants.TRIFORCE_YELLOW, ItemConstants.TRIFORCE_BLUE });
        }


        public void Draw(SpriteBatch _spriteBatch)
        {

            this.sprite.Draw(_spriteBatch);

        }

        public void Update(GameTime gametime)
        {
            this.sprite.Update((int) position.X, (int) position.Y);
        }

        Vector2 IItem.GetPosition()
        {
            return position;
        }
        public Rectangle GetHurtbox()
        {
            return this.sprite.GetDestinationRectangle();
        }

        public void SetHurtbox(Rectangle rect)
        {
            this.SetPlacement(rect.X, rect.Y);
        }

    }
}
