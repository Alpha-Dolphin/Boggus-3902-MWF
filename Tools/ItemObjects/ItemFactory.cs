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
        private int previousItemNum = 0;
        private IItem currentItem;
        private int numItems = 15;
        private int defaultX = 600;
        private int defaultY = 350;
        private Texture2D spriteSheet;
        public ItemFactory(Texture2D spritesheet)
        {
            this.spriteSheet = spritesheet;
            this.currentItem = new Compass(spritesheet, this.defaultX, this.defaultY);
        }

        // Thanks to John Cook for help with handling item cycling

        /* Not needed for real game, will retain for documentation
        public void Update(List<Keys> pressed, List<Keys> held, GameTime gametime)
        {
            if (pressed.Contains(Keys.I) && !held.Contains(Keys.I)) //Increment with rollover
            {
                currentItemNum = (currentItemNum + 1) % numItems;
            }
            if (pressed.Contains(Keys.U) && !held.Contains(Keys.U)) //Decrement with rollover
            {
                currentItemNum = (numItems+ (currentItemNum - 1)) % numItems;
            }
            this.currentItem.Update(gametime);
        }
        */ 
        

        public IItem CreateItem(Item item, int x, int y)
        {
            switch (item)
            {
                case Item.Compass: this.currentItem = new Compass(this.spriteSheet, x, y); break;

                case Item.Map: this.currentItem = new Map(this.spriteSheet, x, y); break;

                case Item.Key: this.currentItem = new Key(this.spriteSheet, x, y); break;

                case Item.HeartContainer: this.currentItem = new HeartContainer(this.spriteSheet, x, y); break;

                case Item.TriforcePiece: this.currentItem = new TriforcePiece(this.spriteSheet, x, y); break;

                case Item.WoodenBoomerang: this.currentItem = new WoodenBoomerang(this.spriteSheet, x, y); break;

                case Item.Bow: this.currentItem = new Bow(this.spriteSheet, x, y); break;

                case Item.Heart: this.currentItem = new Heart(this.spriteSheet, x, y); break;

                case Item.Rupee: this.currentItem = new Rupee(this.spriteSheet, x, y); break;

                case Item.Arrow: this.currentItem = new Arrow(this.spriteSheet, x, y); break;

                case Item.Bomb: this.currentItem = new Bomb(this.spriteSheet, x, y); break;

                case Item.Fairy: this.currentItem = new Fairy(this.spriteSheet, x, y); break;

                case Item.Clock: this.currentItem = new Clock(this.spriteSheet, x, y); break;

                case Item.BlueCandle: this.currentItem = new BlueCandle(this.spriteSheet, x, y); break;

                case Item.BluePotion: this.currentItem = new BluePotion(this.spriteSheet, x, y); break;

                default: this.currentItem = new Compass(this.spriteSheet, x, y); break;
            }                
            return this.currentItem;
        }
    }
}
