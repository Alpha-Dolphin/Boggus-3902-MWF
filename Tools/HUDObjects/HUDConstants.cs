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
        public const int NUMROOMS = 18;
        public const int TRIFORCE_ROOM = 5;

        public static Keys PAUSE_BUTTON = Keys.Escape;
        public static Keys SELECT_ITEM = Keys.Enter;

        public const int TOP_HEIGHT = 256;

        public static Rectangle BLACK_PIXEL = new Rectangle(5, 5, 1, 1);
        public static Rectangle WHITE_PIXEL = new Rectangle(584, 1, 1, 1);
        public static Rectangle MAP_PIXEL = new Rectangle(386, 112, 1, 1);
        public static Color DEFAULTBACKGROUNDCOLOR = Color.Black;

        public static Rectangle INVENTORY_BACKGROUND = new Rectangle(1, 11, 256, 88);
        public static int CURRENT_SPECIAL_X = 68;
        public static int CURRENT_SPECIAL_Y = 48;
        public static Rectangle MAP_BACKGROUND = new Rectangle(258, 112, 256, 88);

        public static Rectangle MAPINSIDE_BACKGROUND_DESTINATION = new Rectangle(120, 96, 80, 64);

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

        //public static Rectangle MAPTOP = new Rectangle(30, 30, 50, 30);

        public static Rectangle LEVELNUM_BACKGROUND = new Rectangle(584, 1, 64, 40);
        public static Rectangle LEVELNUM_DESTINATION = new Rectangle(48, 0, 8, 8);

        public const int MAPTOP_ROWS = 3;
        public const int MAPTOP_COLUMNS = 6;
        public const int MAPTOP_X = 8;
        public const int MAPTOP_Y = 16;

        //0 means no blocks, 1 means top, 2 means bottom, 3 means both
        public static int[] MAPTOP_INFO = new int[]
        {
            0, 1, 3, 0, 2, 2,
            1, 3, 3, 3, 1, 0,
            0, 2, 3, 2, 0, 0
        };

        public static Dictionary<int, (int x, int y)> LOCATIONDOT_ROOMTOPOSITION_TOP = new Dictionary<int, (int x, int y)>()
        {
            { 2, (18, 16) },
            { 3, (26, 16) },
            { 4, (26, 20) },
            { 5, (42, 20) },
            { 6, (50, 20) },
            { 7, (10, 24) },
            { 8, (18, 24) },
            { 9, (26, 24) },
            { 10, (34, 24) },
            { 11, (42, 24) },
            { 12, (18, 28) },
            { 13, (26, 28) },
            { 14, (34, 28) },
            { 15, (26, 32) },
            { 16, (18, 36) },
            { 17, (26, 36) },
            { 18, (34, 36) },
        };

        public const int MAPFULL_ROWS = 6;
        public const int MAPFULL_COLUMNS = 6;
        public const int MAPFULL_X = 140;
        public const int MAPFULL_Y = 100;
        //See full list below for numbers
        public static int[] MAPFULL_INFO = new int[]
        {
            0, 2, 7, 0, 0, 0,
            0, 0, 13, 0, 6, 3,
            2, 8, 16, 8, 11, 0,
            0, 10, 16, 11, 0, 0,
            0, 0, 13, 0, 0, 0,
            0, 2, 16, 3, 0, 0
        };

        public static Dictionary<(int row, int col), int> ARRAY_TO_ROOMNUMBER = new Dictionary<(int row, int col), int>()
        {
            { (0, 1), 2 },
            { (0, 2), 3 },
            { (1, 2), 4 },
            { (1, 4), 5 },
            { (1, 5), 6 },
            { (2, 0), 7 },
            { (2, 1), 8 },
            { (2, 2), 9 },
            { (2, 3), 10 },
            { (2, 4), 11 },
            { (3, 1), 12 },
            { (3, 2), 13 },
            { (3, 3), 14 },
            { (4, 2), 15 },
            { (5, 1), 16 },
            { (5, 2), 17 },
            { (5, 3), 18 },
        };

        public static Dictionary<int, (int x, int y)> LOCATIONDOT_ROOMTOPOSITION_FULL = new Dictionary<int, (int x, int y)>()
        {
            { 2, (150, 102) },
            { 3, (158, 102) },
            { 4, (158, 110) },
            { 5, (174, 110) },
            { 6, (182, 110) },
            { 7, (142, 118) },
            { 8, (150, 118) },
            { 9, (158, 118) },
            { 10, (166, 118) },
            { 11, (174, 118) },
            { 12, (150, 126) },
            { 13, (158, 126) },
            { 14, (166, 126) },
            { 15, (158, 134) },
            { 16, (150, 142) },
            { 17, (158, 142) },
            { 18, (166, 142) },
        };

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

        public static Rectangle MAP_FULL_NONE = new Rectangle(519, 108, 8, 8);
        public static Rectangle MAP_FULL_E = new Rectangle(528, 108, 8, 8);
        public static Rectangle MAP_FULL_W = new Rectangle(537, 108, 8, 8);
        public static Rectangle MAP_FULL_EW = new Rectangle(546, 108, 8, 8);
        public static Rectangle MAP_FULL_S = new Rectangle(555, 108, 8, 8);
        public static Rectangle MAP_FULL_SE = new Rectangle(564, 108, 8, 8);
        public static Rectangle MAP_FULL_SW = new Rectangle(573, 108, 8, 8);
        public static Rectangle MAP_FULL_SEW = new Rectangle(582, 108, 8, 8);
        public static Rectangle MAP_FULL_N = new Rectangle(591, 108, 8, 8);
        public static Rectangle MAP_FULL_NE = new Rectangle(600, 108, 8, 8);
        public static Rectangle MAP_FULL_NW = new Rectangle(609, 108, 8, 8);
        public static Rectangle MAP_FULL_NEW = new Rectangle(618, 108, 8, 8);
        public static Rectangle MAP_FULL_NS = new Rectangle(627, 108, 8, 8);
        public static Rectangle MAP_FULL_NSE = new Rectangle(636, 108, 8, 8);
        public static Rectangle MAP_FULL_NSW = new Rectangle(645, 108, 8, 8);
        public static Rectangle MAP_FULL_NSEW = new Rectangle(654, 108, 8, 8);

        public static Rectangle LOCATION_DOT = new Rectangle(519, 126, 3, 3);

        private static Rectangle TRIFORCE_DOT1 = new Rectangle(528, 126, 3, 3);
        private static Rectangle TRIFORCE_DOT2 = new Rectangle(537, 126, 3, 3);
        public static List<Rectangle> TRIFORCE_DOT = new List<Rectangle>() { TRIFORCE_DOT1, TRIFORCE_DOT2 };
    }
}
