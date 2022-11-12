using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LOZ.Tools.EnvironmentObjects;
using LOZ.Tools.ItemObjects;
using LOZ.Tools.PlayerObjects;
using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LOZ.Tools.HUDObjects
{
    internal class HUD
    {
        bool full = false;
        bool lastPressed;

        Texture2D itemSpriteSheet;
        Texture2D HUDSpriteSheet;

        List<Sprite> topSprites;
        List<Sprite> fullSprites;

        Sprite fullBackground;

        Sprite inventoryBackground;
        Sprite mapBackground;
        Sprite currentSpecialWeapon;

        Sprite currentBox;
        Sprite selectionBox;
        int selectionBoxPosition = 0;
        Sprite boomerang;
        Sprite bomb;
        Sprite bow;
        Sprite candle;
        Sprite potion;

        Sprite mapIcon;
        Sprite compassIcon;
        Sprite mapFull;
        Sprite locationDotFull;


        //Everything below this is constantly on screen
        Sprite topBackground;
        Sprite levelNumBackground;
        Sprite levelNum;
        Sprite currentItemsBackground;
        Sprite mapTop;
        Sprite locationDotTop;

        Sprite rupeeTimes;
        Sprite keyTimes;
        Sprite bombTimes;
        Sprite specialWeapon;
        Sprite sword;

        //TextSprite life;
        private int health;
        Sprite[] hearts;

        public HUD(Texture2D HUDSpriteSheet, Texture2D itemSpriteSheet, SpriteFont font)
        {
            this.itemSpriteSheet = itemSpriteSheet;
            this.HUDSpriteSheet = HUDSpriteSheet;

            fullBackground = new Sprite(itemSpriteSheet, new Rectangle(0, 0, EnvironmentConstants.SCREEN_WIDTH / Sprite.xScale, 
                (EnvironmentConstants.SCREEN_HEIGHT - HUDConstants.TOP_HEIGHT) / Sprite.yScale), new List<Rectangle>() { HUDConstants.BLACK_PIXEL });
            fullBackground.SetColor(HUDConstants.DEFAULTBACKGROUNDCOLOR);

            inventoryBackground = new Sprite(HUDSpriteSheet, 0, 0, new List<Rectangle>() { HUDConstants.INVENTORY_BACKGROUND });
            mapBackground = new Sprite(HUDSpriteSheet, 0, inventoryBackground.height, new List<Rectangle>() { HUDConstants.MAP_BACKGROUND });

            mapIcon = new Sprite(itemSpriteSheet, HUDConstants.MAP_ICON, new List<Rectangle>() { ItemConstants.MAP });
            compassIcon = new Sprite(itemSpriteSheet, HUDConstants.COMPASS_ICON, new List<Rectangle>() { ItemConstants.COMPASS });
            boomerang = new Sprite(itemSpriteSheet, HUDConstants.BOOMERANG, new List<Rectangle>() { ItemConstants.BOOMERANG });
            bomb = new Sprite(itemSpriteSheet, HUDConstants.BOMB, new List<Rectangle>() { ItemConstants.BOMB });
            bow = new Sprite(itemSpriteSheet, HUDConstants.BOW, new List<Rectangle>() { ItemConstants.BOW });
            candle = new Sprite(itemSpriteSheet, HUDConstants.CANDLE, new List<Rectangle>() { ItemConstants.CANDLE });
            potion = new Sprite(itemSpriteSheet, HUDConstants.POTION, new List<Rectangle>() { ItemConstants.POTION });

            selectionBox = new Sprite(HUDSpriteSheet, HUDConstants.SELECTIONBOX_POSITIONS[selectionBoxPosition], new List<Rectangle>() { HUDConstants.SELECTIONBOX });

            //Below this is all top only
            topBackground = new Sprite(itemSpriteSheet, new Rectangle(0, 0, EnvironmentConstants.SCREEN_WIDTH / Sprite.xScale, HUDConstants.TOP_HEIGHT / Sprite.yScale),
                new List<Rectangle>() { HUDConstants.BLACK_PIXEL });
            topBackground.SetColor(HUDConstants.DEFAULTBACKGROUNDCOLOR);
            levelNumBackground = new Sprite(HUDSpriteSheet, 0, 0, new List<Rectangle>() { HUDConstants.LEVELNUM_BACKGROUND });
            levelNum = new Sprite(HUDSpriteSheet, HUDConstants.LEVELNUM_DESTINATION, new List<Rectangle>() { HUDConstants.ONE });
            currentItemsBackground = new Sprite(HUDSpriteSheet, HUDConstants.CURRENTITEMS_BACKGROUND_DESTINATION, new List<Rectangle>() { HUDConstants.CURRENTITEMS_BACKGROUND });

            rupeeTimes = new Sprite(HUDSpriteSheet, HUDConstants.RUPEE_TIMES, new List<Rectangle>() { HUDConstants.X });
            keyTimes = new Sprite(HUDSpriteSheet, HUDConstants.KEY_TIMES, new List<Rectangle>() { HUDConstants.X });
            bombTimes = new Sprite(HUDSpriteSheet, HUDConstants.BOMB_TIMES, new List<Rectangle>() { HUDConstants.X });

            specialWeapon = new Sprite(itemSpriteSheet, HUDConstants.SPECIALWEAPON_X, HUDConstants.SPECIALWEAPON_Y, new List<Rectangle>() { ItemConstants.BOOMERANG });
            sword = new Sprite(itemSpriteSheet, HUDConstants.SWORD_X, HUDConstants.SWORD_Y, new List<Rectangle>() { ItemConstants.WOODEN_SWORD });

            

            hearts = new Sprite[4];
            for(int i = 0; i < hearts.Length; i++)
            {
                hearts[i] = new Sprite(itemSpriteSheet, HUDConstants.HEART_X + ItemConstants.HEART_FULL.Width * i, 
                    HUDConstants.HEART_Y, new List<Rectangle>() { ItemConstants.HEART_FULL });
            }

            topSprites = new List<Sprite>() { topBackground, levelNumBackground, levelNum, currentItemsBackground, mapTop, locationDotTop, 
                rupeeTimes, keyTimes, bombTimes, specialWeapon, sword, };
            fullSprites = new List<Sprite>() { fullBackground, inventoryBackground, mapBackground, currentSpecialWeapon, currentBox, 
                selectionBox, boomerang, bomb, bow, candle, potion, mapIcon, compassIcon, mapFull, locationDotFull };
        }

        private void UpdateInventory(Link link)
        {
        }

        public void Update(Link link, List<Keys> keys)
        {
            bool pressed = keys.Contains(HUDConstants.PAUSE_BUTTON);

            if (health != link.GetHealth()) UpdateHealth(link);

            if (pressed)
            {
                if (!lastPressed)
                {
                    lastPressed = true;
                    Change(link);
                }
            }
            else lastPressed = false;
        }

        private void Change(Link link)
        {
            int shift = (EnvironmentConstants.SCREEN_HEIGHT - HUDConstants.TOP_HEIGHT) / Sprite.yScale;

            if (!full)
            {
                UpdateInventory(link);
                foreach (Sprite sprite in topSprites)
                {
                    if (sprite != null)
                    {
                        Rectangle currentSpriteDestination = sprite.GetDestinationRectangle();
                        sprite.SetPosition(currentSpriteDestination.X, currentSpriteDestination.Y + shift);
                    }
                }

                foreach (Sprite heart in hearts)
                {
                    Rectangle currentSpriteDestination = heart.GetDestinationRectangle();
                    heart.SetPosition(currentSpriteDestination.X, currentSpriteDestination.Y + shift);
                }
            } else
            {
                foreach (Sprite sprite in topSprites)
                {
                    if (sprite != null)
                    {
                        Rectangle currentSpriteDestination = sprite.GetDestinationRectangle();
                        sprite.SetPosition(currentSpriteDestination.X, currentSpriteDestination.Y - shift);
                    }
                }

                foreach (Sprite heart in hearts)
                {
                    Rectangle currentSpriteDestination = heart.GetDestinationRectangle();
                    heart.SetPosition(currentSpriteDestination.X, currentSpriteDestination.Y - shift);
                }
            }

            full = !full;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (full) DrawHUDFull(spriteBatch);
            
            DrawHUDTop(spriteBatch);
        }

        private void DrawHUDFull(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(itemSpriteSheet, fullBackground.GetDestinationRectangle(), HUDConstants.BLACK_PIXEL, Color.Black);
            foreach (Sprite sprite in fullSprites)
            {
                if (sprite != null)
                {
                    sprite.Draw(spriteBatch);
                }
            }
        }

        private void DrawHUDTop(SpriteBatch spriteBatch)
        {
            foreach (Sprite sprite in topSprites)
            {
                if (sprite != null)
                {
                    sprite.Draw(spriteBatch);
                }
            }

            foreach(Sprite heart in hearts)
            {
                heart.Draw(spriteBatch);
            }
        }

        private void UpdateHealth(Link link)
        {
            hearts = new Sprite[link.GetHearts()];
            health = link.GetHealth();
            int i;

            for (i = 0; i < health / 2; i++)
            {
                hearts[i] = new Sprite(itemSpriteSheet, HUDConstants.HEART_X + ItemConstants.HEART_FULL.Width * i,
                    HUDConstants.HEART_Y, new List<Rectangle>() { ItemConstants.HEART_FULL });
            }
            if (health % 2 > 0)
            {

                hearts[i] = new Sprite(itemSpriteSheet, HUDConstants.HEART_X + ItemConstants.HEART_HALF.Width * i,
                    HUDConstants.HEART_Y, new List<Rectangle>() { ItemConstants.HEART_HALF });
                i++;
            }
            for (i = i; i < hearts.Length; i++)
            {
                hearts[i] = new Sprite(itemSpriteSheet, HUDConstants.HEART_X + ItemConstants.HEART_FULL.Width * i,
                    HUDConstants.HEART_Y, new List<Rectangle>() { ItemConstants.HEART_EMPTY });
            }
        }

        public bool Paused()
        {
            return full;
        }

        public void PreviousItem()
        {
            selectionBoxPosition--;
            if (selectionBoxPosition < 0) selectionBoxPosition += HUDConstants.SELECTIONBOX_POSITIONS.Length;
            selectionBox.Update(HUDConstants.SELECTIONBOX_POSITIONS[selectionBoxPosition].X, HUDConstants.SELECTIONBOX_POSITIONS[selectionBoxPosition].Y);
        }

        public void NextItem()
        {
            selectionBoxPosition++;
            selectionBoxPosition %= 5;
            selectionBox.Update(HUDConstants.SELECTIONBOX_POSITIONS[selectionBoxPosition].X, HUDConstants.SELECTIONBOX_POSITIONS[selectionBoxPosition].Y);
        }

        public void ChangeSpecial()
        {
            switch (selectionBoxPosition)
            {
                case 0:
                    currentSpecialWeapon = new Sprite(itemSpriteSheet, HUDConstants.SPECIALWEAPON_X, HUDConstants.SPECIALWEAPON_Y, 
                        new List<Rectangle>() { ItemConstants.BOOMERANG }); break;
                case 1:
                    currentSpecialWeapon = new Sprite(itemSpriteSheet, HUDConstants.SPECIALWEAPON_X, HUDConstants.SPECIALWEAPON_Y,
                        new List<Rectangle>() { ItemConstants.BOMB }); break;
                case 2:
                    currentSpecialWeapon = new Sprite(itemSpriteSheet, HUDConstants.SPECIALWEAPON_X, HUDConstants.SPECIALWEAPON_Y,
                        new List<Rectangle>() { ItemConstants.BOW }); break;
                case 3:
                    currentSpecialWeapon = new Sprite(itemSpriteSheet, HUDConstants.SPECIALWEAPON_X, HUDConstants.SPECIALWEAPON_Y,
                        new List<Rectangle>() { ItemConstants.CANDLE }); break;
                case 4:
                    currentSpecialWeapon = new Sprite(itemSpriteSheet, HUDConstants.SPECIALWEAPON_X, HUDConstants.SPECIALWEAPON_Y,
                        new List<Rectangle>() { ItemConstants.POTION }); break;
            }
        }
    }
}
