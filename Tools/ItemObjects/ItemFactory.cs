using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.ItemObjects
{
    internal class ItemFactory
    {
        private int currentItemNum = 0;
        private IItem currentItem;
        private int numItems = 1;
        private int x = 300;
        private int y = 300;
        private Texture2D spriteSheet;
        public ItemFactory(int itemnum, Texture2D spritesheet)
        {
            this.currentItemNum = itemnum;
            this.spriteSheet = spritesheet;
            this.currentItem = new Compass(spritesheet, this.x, this.y);
        }

        void Update(char c)
        {
            if (c.Equals('u') || c.Equals('U'))
            {
                if (this.currentItemNum == 0)
                {
                    this.currentItemNum = numItems - 1;
                }
                else
                {
                    this.currentItemNum--;
                }

            }
            else if (c.Equals('i') || c.Equals('I'))
            {
                if (this.currentItemNum == numItems - 1)
                {
                    this.currentItemNum = 0;
                }
                else
                {
                    this.currentItemNum++;
                }
            }
        }

        public void CreateItem()
        {
            switch(this.currentItemNum)
            {
                case 0:
                    currentItem = new Compass(this.spriteSheet, x, y);
                    break;
            }
        }

        public void Draw(SpriteBatch _spritebatch)
        {
            this.currentItem.Draw(_spritebatch);
        }
      
    }
}
