using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace LOZ.Tools.ItemObjects
{
    internal class ItemFactory
    {
        private int currentItemNum = 0;
        private IItem currentItem;
        private int numItems = 4;
        private int x = 300;
        private int y = 300;
        private Texture2D spriteSheet;
        public ItemFactory(int itemnum, Texture2D spritesheet)
        {
            this.currentItemNum = itemnum;
            this.spriteSheet = spritesheet;
            this.currentItem = new Compass(spritesheet, this.x, this.y);
        }

        public void Update(List<Keys> keys)
        {
            foreach(Keys key in keys)
            {
                if (key.ToString().ToUpper().Equals("U"))
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
                else if (key.ToString().ToUpper().Equals("I"))
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

        }

        public void CreateItem()
        {
            switch(this.currentItemNum)
            {
                case 0: currentItem = new Compass(this.spriteSheet, x, y); break;

                case 1: currentItem = new Map(this.spriteSheet, x, y); break;

                case 2: currentItem = new Key(this.spriteSheet, x, y); break;

                case 3: currentItem = new HeartContainer(this.spriteSheet, x, y); break;

            }
        }

        public void Draw(SpriteBatch _spritebatch)
        {
            this.currentItem.Draw(_spritebatch);
        }
       
    }
}
