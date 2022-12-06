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

        Link link;

        Texture2D itemSpriteSheet;
        Texture2D HUDSpriteSheet;

        List<Sprite> topSprites;
        List<Sprite> fullSprites;

        Sprite fullBackground;

        Sprite inventoryBackground;
        Sprite mapBackground;
        Sprite mapInsideBackground;
        Sprite currentSpecialWeapon;

        Sprite currentBox;
        Sprite selectionBox;
        int selectionBoxPosition = 0;
        List<Sprite> items;
        Sprite boomerang;
        Sprite bomb;
        Sprite bow;
        Sprite candle;
        Sprite potion;

        Sprite mapIcon;
        Sprite compassIcon;
        Map mapFull;
        Sprite locationDotFull;


        //Everything below this is constantly on screen
        Sprite topBackground;
        Sprite levelNumBackground;
        Sprite levelNum;
        Sprite currentItemsBackground;
        Map mapTop;
        Sprite locationDotTop;
        AnimatedMovingSprite bossDot;

        Sprite rupeeTimes;
        Sprite[] rupeeNumber;
        Sprite keyTimes;
        Sprite[] keyNumber;
        Sprite bombTimes;
        Sprite[] bombNumber;
        Sprite specialWeapon;
        Sprite sword;

        private int health;
        Sprite[] hearts;

        public HUD(Texture2D HUDSpriteSheet, Texture2D itemSpriteSheet, SpriteFont font, Link link)
        {
            this.itemSpriteSheet = itemSpriteSheet;
            this.HUDSpriteSheet = HUDSpriteSheet;

            fullBackground = new Sprite(itemSpriteSheet, new Rectangle(0, 0, EnvironmentConstants.SCREEN_WIDTH / Sprite.xScale, 
                (EnvironmentConstants.SCREEN_HEIGHT - HUDConstants.TOP_HEIGHT) / Sprite.yScale), new List<Rectangle>() { HUDConstants.BLACK_PIXEL });
            fullBackground.SetColor(HUDConstants.DEFAULTBACKGROUNDCOLOR);

            inventoryBackground = new Sprite(HUDSpriteSheet, 0, 0, new List<Rectangle>() { HUDConstants.INVENTORY_BACKGROUND });
            mapBackground = new Sprite(HUDSpriteSheet, 0, inventoryBackground.height, new List<Rectangle>() { HUDConstants.MAP_BACKGROUND });
            mapInsideBackground = new Sprite(HUDSpriteSheet, HUDConstants.MAPINSIDE_BACKGROUND_DESTINATION, new List<Rectangle>() { HUDConstants.MAP_PIXEL });
            mapFull = new Map(HUDSpriteSheet, false);
            locationDotFull = new Sprite(HUDSpriteSheet, 0, 0, new List<Rectangle>() { HUDConstants.LOCATION_DOT });

            selectionBox = new Sprite(HUDSpriteSheet, HUDConstants.SELECTIONBOX_POSITIONS[selectionBoxPosition], new List<Rectangle>() { HUDConstants.SELECTIONBOX });

            //Below this is all top only
            topBackground = new Sprite(itemSpriteSheet, new Rectangle(0, 0, EnvironmentConstants.SCREEN_WIDTH / Sprite.xScale, HUDConstants.TOP_HEIGHT / Sprite.yScale),
                new List<Rectangle>() { HUDConstants.BLACK_PIXEL });
            topBackground.SetColor(HUDConstants.DEFAULTBACKGROUNDCOLOR);
            levelNumBackground = new Sprite(HUDSpriteSheet, 0, 0, new List<Rectangle>() { HUDConstants.LEVELNUM_BACKGROUND });
            levelNum = new Sprite(HUDSpriteSheet, HUDConstants.LEVELNUM_DESTINATION, new List<Rectangle>() { HUDConstants.ONE });
            mapTop = new Map(HUDSpriteSheet, true);
            locationDotTop = new Sprite(HUDSpriteSheet, 0, 0, new List<Rectangle>() { HUDConstants.LOCATION_DOT });

            bossDot = new AnimatedMovingSprite(HUDSpriteSheet, 0, 0, HUDConstants.TRIFORCE_DOT);
            (int x, int y) bossDotLocation;
            HUDConstants.LOCATIONDOT_ROOMTOPOSITION_TOP.TryGetValue(HUDConstants.TRIFORCE_ROOM, out bossDotLocation);
            bossDot.Update(bossDotLocation.x, bossDotLocation.y);

            currentItemsBackground = new Sprite(HUDSpriteSheet, HUDConstants.CURRENTITEMS_BACKGROUND_DESTINATION, new List<Rectangle>() { HUDConstants.CURRENTITEMS_BACKGROUND });

            rupeeTimes = new Sprite(HUDSpriteSheet, HUDConstants.RUPEE_TIMES, new List<Rectangle>() { HUDConstants.X });
            keyTimes = new Sprite(HUDSpriteSheet, HUDConstants.KEY_TIMES, new List<Rectangle>() { HUDConstants.X });
            bombTimes = new Sprite(HUDSpriteSheet, HUDConstants.BOMB_TIMES, new List<Rectangle>() { HUDConstants.X });

            sword = new Sprite(itemSpriteSheet, HUDConstants.SWORD_X, HUDConstants.SWORD_Y, new List<Rectangle>() { ItemConstants.WOODEN_SWORD });

            

            hearts = new Sprite[4];
            for(int i = 0; i < hearts.Length; i++)
            {
                hearts[i] = new Sprite(itemSpriteSheet, HUDConstants.HEART_X + ItemConstants.HEART_FULL.Width * i, 
                    HUDConstants.HEART_Y, new List<Rectangle>() { ItemConstants.HEART_FULL });
            }

            rupeeNumber = new Sprite[1];
            rupeeNumber[0] = new Sprite(HUDSpriteSheet, HUDConstants.RUPEE_TIMES.X + HUDConstants.RUPEE_TIMES.Width, HUDConstants.RUPEE_TIMES.Y,
                new List<Rectangle>() { HUDConstants.ZERO });
            keyNumber = new Sprite[1];
            keyNumber[0] = new Sprite(HUDSpriteSheet, HUDConstants.KEY_TIMES.X + HUDConstants.KEY_TIMES.Width, HUDConstants.KEY_TIMES.Y,
                new List<Rectangle>() { HUDConstants.ZERO });
            bombNumber = new Sprite[1];
            bombNumber[0] = new Sprite(HUDSpriteSheet, HUDConstants.BOMB_TIMES.X + HUDConstants.BOMB_TIMES.Width, HUDConstants.BOMB_TIMES.Y,
                new List<Rectangle>() { HUDConstants.ZERO });

            this.link = link;
            UpdateInventory();

            UpdateSpriteLists();
        }

        private void UpdateSpriteLists()
        {
            topSprites = new List<Sprite>() { topBackground, levelNumBackground, levelNum, currentItemsBackground,
                rupeeTimes, keyTimes, bombTimes, specialWeapon, sword, };
            fullSprites = new List<Sprite>() { fullBackground, inventoryBackground, mapBackground, mapInsideBackground, currentSpecialWeapon, currentBox,
                selectionBox, boomerang, bomb, bow, candle, potion, mapIcon, compassIcon };
        }

        private void UpdateInventory()
        {
            LinkInventory.bomb = LinkInventory.bombs > 0;

            if (mapIcon == null)
            {
                if(LinkInventory.map) mapIcon = new Sprite(itemSpriteSheet, HUDConstants.MAP_ICON, new List<Rectangle>() { ItemConstants.MAP });
            }
            if (compassIcon == null)
            {
                if (LinkInventory.compass)
                    compassIcon = new Sprite(itemSpriteSheet, HUDConstants.COMPASS_ICON, new List<Rectangle>() { ItemConstants.COMPASS });
            }
            if (boomerang == null)
            {
                if (LinkInventory.boomerang) boomerang = new Sprite(itemSpriteSheet, HUDConstants.BOOMERANG, new List<Rectangle>() { ItemConstants.BOOMERANG });
            }
            if (bomb == null)
            {
                if (LinkInventory.bomb) bomb = new Sprite(itemSpriteSheet, HUDConstants.BOMB, new List<Rectangle>() { ItemConstants.BOMB });
            }
            if (bow == null)
            {
                if (LinkInventory.bow) bow = new Sprite(itemSpriteSheet, HUDConstants.BOW, new List<Rectangle>() { ItemConstants.BOW });
            }
            if (candle == null)
            {
                if (LinkInventory.candleFlame) candle = new Sprite(itemSpriteSheet, HUDConstants.CANDLE, new List<Rectangle>() { ItemConstants.CANDLE });
            }
            if (potion == null)
            {
                if (LinkInventory.potion) potion = new Sprite(itemSpriteSheet, HUDConstants.POTION, new List<Rectangle>() { ItemConstants.POTION });
            }
        }

        private void UpdateNumbers()
        {
            rupeeNumber = CreateNumber(LinkInventory.rupees, rupeeTimes);
            keyNumber = CreateNumber(LinkInventory.keys, keyTimes);
            bombNumber = CreateNumber(LinkInventory.bombs, bombTimes);
        }

        private Sprite[] CreateNumber(int value, Sprite start)
        {
            int[] numArray = value.ToString().Select(t => int.Parse(t.ToString())).ToArray();
            Sprite[] returnVal = new Sprite[numArray.Length];
            for (int i = 0; i < numArray.Length; i++)
            {
                returnVal[i] = CreateDigit(numArray[i], start.x + (i + 1) * start.width, start.y);
            }

            return returnVal;
        }

        private Sprite CreateDigit(int num, int x, int y)
        {
            List<Rectangle> sourceRectangle = new List<Rectangle>();
            switch (num)
            {
                case 0: sourceRectangle.Add(HUDConstants.ZERO); break;
                case 1: sourceRectangle.Add(HUDConstants.ONE); break;
                case 2: sourceRectangle.Add(HUDConstants.TWO); break;
                case 3: sourceRectangle.Add(HUDConstants.THREE); break;
                case 4: sourceRectangle.Add(HUDConstants.FOUR); break;
                case 5: sourceRectangle.Add(HUDConstants.FIVE); break;
                case 6: sourceRectangle.Add(HUDConstants.SIX); break;
                case 7: sourceRectangle.Add(HUDConstants.SEVEN); break;
                case 8: sourceRectangle.Add(HUDConstants.EIGHT); break;
                case 9: sourceRectangle.Add(HUDConstants.NINE); break;
            }

            return new Sprite(HUDSpriteSheet, x, y, sourceRectangle);
        }

        public void UpdateLink(Link link)
        {
            this.link = link;
        }

        public void Update(List<Keys> keys, int roomNumber)
        {
            bool pressed = keys.Contains(HUDConstants.PAUSE_BUTTON);

            if (health != link.GetHealth()) UpdateHealth(link);
            UpdateNumbers();

            if (pressed)
            {
                if (!lastPressed)
                {
                    lastPressed = true;
                    Change();
                }
            }
            else lastPressed = false;

            if (full && keys.Contains(HUDConstants.SELECT_ITEM)) ChangeSpecial();

            mapTop.Update(roomNumber);
            mapFull.Update(roomNumber);

            (int x, int y) locationDotTopPosition;
            bool locationDotTopSuccess = HUDConstants.LOCATIONDOT_ROOMTOPOSITION_TOP.TryGetValue(roomNumber, out locationDotTopPosition);
            if (locationDotTopSuccess)
            {
                if(full) locationDotTop.Update(locationDotTopPosition.x, locationDotTopPosition.y + (EnvironmentConstants.SCREEN_HEIGHT - HUDConstants.TOP_HEIGHT) / Sprite.yScale);
                else locationDotTop.Update(locationDotTopPosition.x, locationDotTopPosition.y);
            }
            else locationDotTop.Update(-256, -256);
            
            (int x, int y) locationDotFullPosition;
            bool locationDotFullSuccess = HUDConstants.LOCATIONDOT_ROOMTOPOSITION_FULL.TryGetValue(roomNumber, out locationDotFullPosition);
            if (locationDotFullSuccess)
            {
                if (full) locationDotFull.Update(locationDotFullPosition.x, locationDotFullPosition.y + (EnvironmentConstants.SCREEN_HEIGHT - HUDConstants.TOP_HEIGHT) / Sprite.yScale);
                else locationDotFull.Update(locationDotFullPosition.x, locationDotFullPosition.y);
            }
            else locationDotFull.Update(-256, -256);
        }

        private void Change()
        {
            int shift = (EnvironmentConstants.SCREEN_HEIGHT - HUDConstants.TOP_HEIGHT) / Sprite.yScale;

            if (!full)
            {
                UpdateInventory();
                UpdateSpriteLists();
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
                foreach (Sprite num in rupeeNumber)
                {
                    Rectangle currentSpriteDestination = num.GetDestinationRectangle();
                    num.SetPosition(currentSpriteDestination.X, currentSpriteDestination.Y + shift);
                }
                foreach (Sprite num in keyNumber)
                {
                    Rectangle currentSpriteDestination = num.GetDestinationRectangle();
                    num.SetPosition(currentSpriteDestination.X, currentSpriteDestination.Y + shift);
                }
                foreach (Sprite num in bombNumber)
                {
                    Rectangle currentSpriteDestination = num.GetDestinationRectangle();
                    num.SetPosition(currentSpriteDestination.X, currentSpriteDestination.Y + shift);
                }
                foreach (Sprite pixel in mapTop)
                {
                    Rectangle currentSpriteDestination = pixel.GetDestinationRectangle();
                    pixel.SetPosition(currentSpriteDestination.X, currentSpriteDestination.Y + shift);
                }

                Rectangle bossDotDestination = bossDot.GetDestinationRectangle();
                bossDot.Update(bossDotDestination.X, bossDotDestination.Y + shift);

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
                foreach (Sprite num in rupeeNumber)
                {
                    Rectangle currentSpriteDestination = num.GetDestinationRectangle();
                    num.SetPosition(currentSpriteDestination.X, currentSpriteDestination.Y - shift);
                }
                foreach (Sprite num in keyNumber)
                {
                    Rectangle currentSpriteDestination = num.GetDestinationRectangle();
                    num.SetPosition(currentSpriteDestination.X, currentSpriteDestination.Y - shift);
                }
                foreach (Sprite num in bombNumber)
                {
                    Rectangle currentSpriteDestination = num.GetDestinationRectangle();
                    num.SetPosition(currentSpriteDestination.X, currentSpriteDestination.Y - shift);
                }
                foreach (Sprite pixel in mapTop)
                {
                    Rectangle currentSpriteDestination = pixel.GetDestinationRectangle();
                    pixel.SetPosition(currentSpriteDestination.X, currentSpriteDestination.Y - shift);
                }

                Rectangle bossDotDestination = bossDot.GetDestinationRectangle();
                bossDot.Update(bossDotDestination.X, bossDotDestination.Y - shift);
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
            if (LinkInventory.map) mapFull.Draw(spriteBatch);
            if (LinkInventory.compass) locationDotFull.Draw(spriteBatch);
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
            foreach (Sprite num in rupeeNumber)
            {
                num.Draw(spriteBatch);

            }
            foreach (Sprite num in keyNumber)
            {
                num.Draw(spriteBatch);
            }
            foreach (Sprite num in bombNumber)
            {
                num.Draw(spriteBatch);
            }
            if (LinkInventory.map)
            {
                mapTop.Draw(spriteBatch);
                bossDot.Update(bossDot.GetX(), bossDot.GetY());
                bossDot.Draw(spriteBatch);
            }
            if (LinkInventory.compass) locationDotTop.Draw(spriteBatch);
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

        private void ChangeSpecial()
        {
            switch (selectionBoxPosition)
            {
                case 0:
                    if (LinkInventory.boomerang)
                    {
                        currentSpecialWeapon = new Sprite(itemSpriteSheet, HUDConstants.CURRENT_SPECIAL_X, HUDConstants.CURRENT_SPECIAL_Y,
                            new List<Rectangle>() { ItemConstants.BOOMERANG });
                        specialWeapon = new Sprite(itemSpriteSheet, HUDConstants.SPECIALWEAPON_X, HUDConstants.SPECIALWEAPON_Y, new List<Rectangle>() { ItemConstants.BOOMERANG });
                        link.UpdateSpecialWeapon(PlayerConstants.Link_Projectiles.Boomerang);
                    }
                    break;
                case 1:
                    if (LinkInventory.bomb)
                    {
                        currentSpecialWeapon = new Sprite(itemSpriteSheet, HUDConstants.CURRENT_SPECIAL_X, HUDConstants.CURRENT_SPECIAL_Y,
                            new List<Rectangle>() { ItemConstants.BOMB });
                        specialWeapon = new Sprite(itemSpriteSheet, HUDConstants.SPECIALWEAPON_X, HUDConstants.SPECIALWEAPON_Y, new List<Rectangle>() { ItemConstants.BOMB });
                        link.UpdateSpecialWeapon(PlayerConstants.Link_Projectiles.Bomb);
                    }
                    break;
                case 2:
                    if (LinkInventory.bow)
                    {
                        currentSpecialWeapon = new Sprite(itemSpriteSheet, HUDConstants.CURRENT_SPECIAL_X, HUDConstants.CURRENT_SPECIAL_Y,
                            new List<Rectangle>() { ItemConstants.BOW });
                        specialWeapon = new Sprite(itemSpriteSheet, HUDConstants.SPECIALWEAPON_X, HUDConstants.SPECIALWEAPON_Y, new List<Rectangle>() { ItemConstants.BOW });
                        link.UpdateSpecialWeapon(PlayerConstants.Link_Projectiles.WoodArrow);
                    }
                    break;
                case 3:
                    if (LinkInventory.candleFlame)
                    {
                        currentSpecialWeapon = new Sprite(itemSpriteSheet, HUDConstants.CURRENT_SPECIAL_X, HUDConstants.CURRENT_SPECIAL_Y,
                            new List<Rectangle>() { ItemConstants.CANDLE });
                        specialWeapon = new Sprite(itemSpriteSheet, HUDConstants.SPECIALWEAPON_X, HUDConstants.SPECIALWEAPON_Y, new List<Rectangle>() { ItemConstants.CANDLE });
                        link.UpdateSpecialWeapon(PlayerConstants.Link_Projectiles.CandleFlame);
                    }
                    break;
                case 4:
                    if (LinkInventory.potion)
                    {
                        currentSpecialWeapon = new Sprite(itemSpriteSheet, HUDConstants.CURRENT_SPECIAL_X, HUDConstants.CURRENT_SPECIAL_Y,
                            new List<Rectangle>() { ItemConstants.POTION });
                        specialWeapon = new Sprite(itemSpriteSheet, HUDConstants.SPECIALWEAPON_X, HUDConstants.SPECIALWEAPON_Y, new List<Rectangle>() { ItemConstants.POTION });
                        link.UpdateSpecialWeapon(PlayerConstants.Link_Projectiles.Potion);
                    }
                    break;
            }

            Change();
            Change();

            UpdateSpriteLists();
        }
    }
}
