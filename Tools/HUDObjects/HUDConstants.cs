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

        public const int TOP_HEIGHT = 256;

        public static Rectangle BLACK_PIXEL = new Rectangle(5, 5, 1, 1);
        public static Color DEFAULTBACKGROUNDCOLOR = Color.Black;

        public static Rectangle INVENTORY_BACKGROUND = new Rectangle(1, 11, 256, 88);
        public static Rectangle MAP_BACKGROUND = new Rectangle(258, 112, 256, 88);

        public static Rectangle SELECTIONBOX = new Rectangle(519, 137, 16, 16);
        public const int SELECTIONBOX_X = 100;
        public const int SELECTIONBOX_Y = 100;

        //public const string LEVELNUM_TEXT = "LEVEL-1";
        //public const int LEVELNUM_X = 70;
        //public const int LEVELNUM_Y = 20;

        public static Rectangle MAPTOP = new Rectangle(30, 30, 50, 30);

        public static Rectangle LEVELNUM_BACKGROUND = new Rectangle(584, 1, 64, 40);
        public static Rectangle CURRENTITEMS_BACKGROUND = new Rectangle(258, 11, 256, 56);
        public static Rectangle CURRENTITEMS_BACKGROUND_DESTINATION = new Rectangle(0, 8, 256, 56);
        //public const int RUPEE_X = 120;
        //public const int RUPEE_Y = 15;
        //public const string RUPEEAMOUNT_TEXT = "X0";
        //public const int RUPEEAMOUNT_X = 380;
        //public const int RUPEEAMOUNT_Y = 45;

        //public const int KEY_X = 120;
        //public const int KEY_Y = 40;
        //public const string KEYAMOUNT_TEXT = "X0";
        //public const int KEYAMOUNT_X = 380;
        //public const int KEYAMOUNT_Y = 120;

        //public const int BOMBTOP_X = 120;
        //public const int BOMBTOP_Y = 50;
        //public const string BOMBAMOUNT_TEXT = "X0";
        //public const int BOMBAMOUNT_X = 380;
        //public const int BOMBAMOUNT_Y = 180;

        //public const string CONTROLSPECIAL_TEXT = "B";
        //public const int CONTROLSPECIAL_X = 510;
        //public const int CONTROLSPECIAL_Y = 45;
        public const int SPECIALWEAPON_X = 170;
        public const int SPECIALWEAPON_Y = 35;
        //public const string CONTROLSWORD_TEXT = "A";
        //public const int CONTROLSWORD_X = 585;
        //public const int CONTROLSWORD_Y = 45;
        public const int SWORD_X = 200;
        public const int SWORD_Y = 25;

        //public const string LIFE_TEXT = "-LIFE-";
        //public const int LIFE_X = 735;
        //public const int LIFE_Y = 45;
        public const int HEART_X = 170;
        public const int HEART_Y = 40;
    }
}
