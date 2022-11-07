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

        Texture2D spriteSheet;

        List<Sprite> topSprites;
        List<Sprite> fullSprites;

        Sprite fullBackground;

        Sprite inventoryBackground;
        Sprite mapBackground;
        Sprite currentSpecialWeapon;

        Sprite currentBox;
        Sprite selectionBox;
        Sprite boomerang;
        Sprite bomb;
        Sprite bow;
        Sprite candle;
        Sprite potion;

        //TextSprite mapWord;
        Sprite mapIcon;
        //TextSprite compassWord;
        Sprite compassIcon;
        Sprite mapFull;
        Sprite locationDotFull;


        //Everything below this is constantly on screen
        Sprite topBackground;
        Sprite levelNumBackground;
        Sprite currentItemsBackground;
        //TextSprite levelNumber;
        Sprite mapTop;
        Sprite locationDotTop;

        //Sprite rupee;
        //TextSprite rupeeAmount;
        //Sprite key;
        //TextSprite keyAmount;
        //Sprite bombTop;
        //TextSprite bombAmount;

        //TextSprite controlSpecial;
        Sprite specialWeapon;
        //TextSprite controlSword;
        Sprite sword;

        //TextSprite life;
        private int health;
        Sprite[] hearts;

        public HUD(Texture2D HUDSpriteSheet, Texture2D itemSpriteSheet, SpriteFont font)
        {
            this.spriteSheet = itemSpriteSheet;

            fullBackground = new Sprite(itemSpriteSheet, new Rectangle(0, 0, EnvironmentConstants.SCREEN_WIDTH / Sprite.xScale, 
                (EnvironmentConstants.SCREEN_HEIGHT - HUDConstants.TOP_HEIGHT) / Sprite.yScale), new List<Rectangle>() { HUDConstants.BLACK_PIXEL });
            fullBackground.SetColor(HUDConstants.DEFAULTBACKGROUNDCOLOR);

            inventoryBackground = new Sprite(HUDSpriteSheet, 0, 0, new List<Rectangle>() { HUDConstants.INVENTORY_BACKGROUND });
            mapBackground = new Sprite(HUDSpriteSheet, 0, inventoryBackground.height, new List<Rectangle>() { HUDConstants.MAP_BACKGROUND });

            selectionBox = new Sprite(HUDSpriteSheet, HUDConstants.SELECTIONBOX_X, HUDConstants.SELECTIONBOX_Y, new List<Rectangle>() { HUDConstants.SELECTIONBOX });

            //Below this is all top only
            topBackground = new Sprite(itemSpriteSheet, new Rectangle(0, 0, EnvironmentConstants.SCREEN_WIDTH / Sprite.xScale, HUDConstants.TOP_HEIGHT / Sprite.yScale),
                new List<Rectangle>() { HUDConstants.BLACK_PIXEL });
            topBackground.SetColor(HUDConstants.DEFAULTBACKGROUNDCOLOR);
            levelNumBackground = new Sprite(HUDSpriteSheet, 0, 0, new List<Rectangle>() { HUDConstants.LEVELNUM_BACKGROUND });
            currentItemsBackground = new Sprite(HUDSpriteSheet, HUDConstants.CURRENTITEMS_BACKGROUND_DESTINATION, new List<Rectangle>() { HUDConstants.CURRENTITEMS_BACKGROUND });
            //levelNumber = new TextSprite();
            //levelNumber.SetFont(font);
            //levelNumber.SetText(HUDConstants.LEVELNUM_TEXT);
            //levelNumber.SetPosition(HUDConstants.LEVELNUM_X, HUDConstants.LEVELNUM_Y);

            //rupee = new Sprite(spriteSheet, HUDConstants.RUPEE_X, HUDConstants.RUPEE_Y, new List<Rectangle>() { ItemConstants.RUPEE_YELLOW });
            //rupeeAmount = new TextSprite();
            //rupeeAmount.SetFont(font);
            //rupeeAmount.SetText(HUDConstants.RUPEEAMOUNT_TEXT);
            //rupeeAmount.SetPosition(HUDConstants.RUPEEAMOUNT_X, HUDConstants.RUPEEAMOUNT_Y);
            //key = new Sprite(spriteSheet, HUDConstants.KEY_X, HUDConstants.KEY_Y, new List<Rectangle>() { ItemConstants.KEY });
            //keyAmount = new TextSprite();
            //keyAmount.SetFont(font);
            //keyAmount.SetText(HUDConstants.KEYAMOUNT_TEXT);
            //keyAmount.SetPosition(HUDConstants.KEYAMOUNT_X, HUDConstants.KEYAMOUNT_Y);
            //bomb = new Sprite(spriteSheet, HUDConstants.BOMBTOP_X, HUDConstants.BOMBTOP_Y, new List<Rectangle>() { ItemConstants.BOMB });
            //bombAmount = new TextSprite();
            //bombAmount.SetFont(font);
            //bombAmount.SetText(HUDConstants.BOMBAMOUNT_TEXT);
            //bombAmount.SetPosition(HUDConstants.BOMBAMOUNT_X, HUDConstants.BOMBAMOUNT_Y);

            //controlSpecial = new TextSprite();
            //controlSpecial.SetFont(font);
            //controlSpecial.SetText(HUDConstants.CONTROLSPECIAL_TEXT);
            //controlSpecial.SetPosition(HUDConstants.CONTROLSPECIAL_X, HUDConstants.CONTROLSPECIAL_Y);
            specialWeapon = new Sprite(itemSpriteSheet, HUDConstants.SPECIALWEAPON_X, HUDConstants.SPECIALWEAPON_Y, new List<Rectangle>() { PlayerConstants.BOOMERANG_WOOD_FRAMES[0] });
            //controlSword = new TextSprite();
            //controlSword.SetFont(font);
            //controlSword.SetText(HUDConstants.CONTROLSPECIAL_TEXT);
            //controlSword.SetPosition(HUDConstants.CONTROLSPECIAL_X, HUDConstants.CONTROLSPECIAL_Y);
            sword = new Sprite(itemSpriteSheet, HUDConstants.SWORD_X, HUDConstants.SWORD_Y, new List<Rectangle>() { PlayerConstants.SWORDBEAM_UP_FRAMES[0] });

            //life = new TextSprite();
            //life.SetFont(font);
            //life.SetText(HUDConstants.LIFE_TEXT);
            //life.SetPosition(HUDConstants.LIFE_X, HUDConstants.LIFE_Y);
            //life.SetColor(Color.Red);

            hearts = new Sprite[4];
            for(int i = 0; i < hearts.Length; i++)
            {
                hearts[i] = new Sprite(itemSpriteSheet, HUDConstants.HEART_X + ItemConstants.HEART_FULL.Width * i, 
                    HUDConstants.HEART_Y, new List<Rectangle>() { ItemConstants.HEART_FULL });
            }

            //topSprites = new List<ISprite>() { levelNumber, mapTop, locationDotTop, rupee, rupeeAmount, key, keyAmount, bombTop, bombAmount, controlSpecial, specialWeapon, controlSword, life };
            topSprites = new List<Sprite>() { topBackground, levelNumBackground, currentItemsBackground, mapTop, locationDotTop, specialWeapon, sword, };
            fullSprites = new List<Sprite>() { fullBackground, inventoryBackground, mapBackground, currentSpecialWeapon, currentBox, 
                selectionBox, boomerang, bomb, bow, candle, potion, mapIcon, compassIcon, mapFull, locationDotFull };
        }

        private void UpdateInfo(Link link)
        {
            //Update
        }

        public void Update(Link link, List<Keys> keys)
        {
            bool pressed = keys.Contains(HUDConstants.PAUSE_BUTTON);

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
                UpdateInfo(link);
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
            spriteBatch.Draw(spriteSheet, fullBackground.GetDestinationRectangle(), HUDConstants.BLACK_PIXEL, Color.Black);
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

        public bool Paused()
        {
            return full;
        }
    }
}
