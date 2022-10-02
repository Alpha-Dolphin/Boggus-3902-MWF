using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace LOZ.Tools.ItemObjects
{
    internal class ItemFactory
    {
        private int currentItemNum = 0;
        private IItem currentItem;
        private int numItems = 13;
        private int x = 600;
        private int y = 350;
        private Texture2D spriteSheet;
        public ItemFactory(int itemnum, Texture2D spritesheet)
        {
            this.currentItemNum = itemnum;
            this.spriteSheet = spritesheet;
            this.currentItem = new Compass(spritesheet, this.x, this.y);
        }

        public void Update(List<Keys> keys, GameTime gametime)
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

            this.currentItem.Update(gametime);

        }

        public void CreateItem()
        {
            switch(this.currentItemNum)
            {
                case 0: this.currentItem = new Compass(this.spriteSheet, x, y); break;

                case 1: this.currentItem = new Map(this.spriteSheet, x, y); break;

                case 2: this.currentItem = new Key(this.spriteSheet, x, y); break;

                case 3: this.currentItem = new HeartContainer(this.spriteSheet, x, y); break;

                case 4: this.currentItem = new TriforcePiece(this.spriteSheet, x, y); break;

                case 5: this.currentItem = new WoodenBoomerang(this.spriteSheet, x, y); break;

                case 6: this.currentItem = new Bow(this.spriteSheet, x, y); break;

                case 7: this.currentItem = new Heart(this.spriteSheet, x, y); break;

                case 8: this.currentItem = new Rupee(this.spriteSheet, x, y); break;

                case 9: this.currentItem = new Arrow(this.spriteSheet, x, y); break;

                case 10: this.currentItem = new Bomb(this.spriteSheet, x, y); break;

                case 11: this.currentItem = new Fairy(this.spriteSheet, x, y); break;

                case 12: this.currentItem = new Clock(this.spriteSheet, x, y); break;

                case 13: this.currentItem = new BlueCandle(this.spriteSheet, x, y); break;

                case 14: this.currentItem = new BluePotion(this.spriteSheet, x, y); break;

                default: this.currentItem = new Compass(this.spriteSheet, x, y); break;


            }
        }

        public void Draw(SpriteBatch _spritebatch)
        {
            this.currentItem.Draw(_spritebatch);
        }
       
    }
}
