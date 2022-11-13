using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.HUDObjects
{
    internal class HUDConstants
    {
        public static Keys PAUSE_BUTTON = Keys.Escape;
        public static Keys SELECT_ITEM = Keys.Enter;

        public const int TOP_HEIGHT = 256;

        public static Rectangle BLACK_PIXEL = new Rectangle(5, 5, 1, 1);
        public static Color DEFAULTBACKGROUNDCOLOR = Color.Black;

        public static Rectangle INVENTORY_BACKGROUND = new Rectangle(1, 11, 256, 88);
        public static int CURRENT_SPECIAL_X = 68;
        public static int CURRENT_SPECIAL_Y = 48;
        public static Rectangle MAP_BACKGROUND = new Rectangle(258, 112, 256, 88);

        public static Rectangle MAP_ICON = new Rectangle(48, 110, 8, 16);
        public static Rectangle COMPASS_ICON = new Rectangle(45, 150, 16, 16);
        public static Rectangle BOOMERANG = new Rectangle(134, 52, 5, 8);
        public static Rectangle BOMB = new Rectangle(152, 48, 8, 16);
        public static Rectangle BOW = new Rectangle(172, 48, 8, 16);
        public static Rectangle CANDLE = new Rectangle(192, 48, 8, 16);
        public static Rectangle POTION = new Rectangle(172, 64, 8, 16);


        public static Rectangle SELECTIONBOX = new Rectangle(519, 137, 16, 16);
        public static Rectangle[] SELECTIONBOX_POSITIONS = new Rectangle[5]
        {
            new Rectangle(128, 48, 16, 16),
            new Rectangle(148, 48, 16, 16),
            new Rectangle(168, 48, 16, 16),
            new Rectangle(188, 48, 16, 16),
            new Rectangle(168, 64, 16, 16)
        };

        public static Rectangle MAPTOP = new Rectangle(30, 30, 50, 30);

        public static Rectangle LEVELNUM_BACKGROUND = new Rectangle(584, 1, 64, 40);
        public static Rectangle LEVELNUM_DESTINATION = new Rectangle(48, 0, 8, 8);
        public static Rectangle CURRENTITEMS_BACKGROUND = new Rectangle(258, 11, 256, 56);
        public static Rectangle CURRENTITEMS_BACKGROUND_DESTINATION = new Rectangle(0, 8, 256, 56);

        public static Rectangle RUPEE_TIMES = new Rectangle(96, 24, 8, 8);
        public static Rectangle KEY_TIMES = new Rectangle(96, 40, 8, 8);
        public static Rectangle BOMB_TIMES = new Rectangle(96, 48, 8, 8);

        public const int SPECIALWEAPON_X = 130;
        public const int SPECIALWEAPON_Y = 32;
        public const int SWORD_X = 152;
        public const int SWORD_Y = 32;

        public const int HEART_X = 180;
        public const int HEART_Y = 40;

        public static Rectangle X = new Rectangle(519, 117, 8, 8);
        public static Rectangle ZERO = new Rectangle(528, 117, 8, 8);
        public static Rectangle ONE = new Rectangle(537, 117, 8, 8);
        public static Rectangle TWO = new Rectangle(546, 117, 8, 8);
        public static Rectangle THREE = new Rectangle(555, 117, 8, 8);
        public static Rectangle FOUR = new Rectangle(564, 117, 8, 8);
        public static Rectangle FIVE = new Rectangle(573, 117, 8, 8);
        public static Rectangle SIX = new Rectangle(582, 117, 8, 8);
        public static Rectangle SEVEN = new Rectangle(591, 117, 8, 8);
        public static Rectangle EIGHT = new Rectangle(600, 117, 8, 8);
        public static Rectangle NINE = new Rectangle(609, 117, 8, 8);

        public static Rectangle MAP_BLUE_TOP = new Rectangle(663, 108, 8, 8);
        public static Rectangle MAP_BLUE_BOT = new Rectangle(672, 108, 8, 8);
        public static Rectangle MAP_BLUE_TWO = new Rectangle(681, 108, 8, 8);
    }
}
