using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools
{
    internal class BackgroundConstants
    {
        public static int SCREEN_WIDTH;
        public static int SCREEN_HEIGHT;

        public static Rectangle ROOM_EXTERIOR = new Rectangle(521, 11, 256, 176);

        static Rectangle CENTER_WALL_TOP = new Rectangle(815, 11, 32, 32);
        static Rectangle CENTER_WALL_LEFT = new Rectangle(815, 44, 32, 32);
        static Rectangle CENTER_WALL_RIGHT = new Rectangle(815, 77, 32, 32);
        static Rectangle CENTER_WALL_BOTTOM = new Rectangle(815, 110, 32, 32);
        public static List<Rectangle> CENTER_WALL = new List<Rectangle>() { CENTER_WALL_TOP, CENTER_WALL_LEFT, CENTER_WALL_RIGHT, CENTER_WALL_BOTTOM};

        static Rectangle CENTER_DOOR_TOP = new Rectangle(848, 11, 32, 32);
        static Rectangle CENTER_DOOR_LEFT = new Rectangle(848, 44, 32, 32);
        static Rectangle CENTER_DOOR_RIGHT = new Rectangle(848, 77, 32, 32);
        static Rectangle CENTER_DOOR_BOTTOM = new Rectangle(848, 110, 32, 32);
        public static List<Rectangle> CENTER_DOOR = new List<Rectangle>() { CENTER_WALL_TOP, CENTER_WALL_LEFT, CENTER_WALL_RIGHT, CENTER_WALL_BOTTOM };

        static Rectangle CENTER_LOCKEDDOOR_TOP = new Rectangle(881, 11, 32, 32);
        static Rectangle CENTER_LOCKEDDOOR_LEFT = new Rectangle(881, 44, 32, 32);
        static Rectangle CENTER_LOCKEDDOOR_RIGHT = new Rectangle(881, 77, 32, 32);
        static Rectangle CENTER_LOCKEDDOOR_BOTTOM = new Rectangle(881, 110, 32, 32);
        public static List<Rectangle> CENTER_LOCKEDDOOR = new List<Rectangle>() { CENTER_WALL_TOP, CENTER_WALL_LEFT, CENTER_WALL_RIGHT, CENTER_WALL_BOTTOM };

        static Rectangle CENTER_CLOSEDDOOR_TOP = new Rectangle(914, 11, 32, 32);
        static Rectangle CENTER_CLOSEDDOOR_LEFT = new Rectangle(914, 44, 32, 32);
        static Rectangle CENTER_CLOSEDDOOR_RIGHT = new Rectangle(914, 77, 32, 32);
        static Rectangle CENTER_CLOSEDDOOR_BOTTOM = new Rectangle(914, 110, 32, 32);
        public static List<Rectangle> CENTER_CLOSEDDOOR = new List<Rectangle>() { CENTER_WALL_TOP, CENTER_WALL_LEFT, CENTER_WALL_RIGHT, CENTER_WALL_BOTTOM };

        static Rectangle CENTER_HOLE_TOP = new Rectangle(947, 11, 32, 32);
        static Rectangle CENTER_HOLE_LEFT = new Rectangle(947, 44, 32, 32);
        static Rectangle CENTER_HOLE_RIGHT = new Rectangle(947, 77, 32, 32);
        static Rectangle CENTER_HOLE_BOTTOM = new Rectangle(947, 110, 32, 32);
        public static List<Rectangle> CENTER_HOLE = new List<Rectangle>() { CENTER_WALL_TOP, CENTER_WALL_LEFT, CENTER_WALL_RIGHT, CENTER_WALL_BOTTOM };

        const int ROOM_LEFT_START = 1;
        const int ROOM_TOP_START = 192;
        const int ROOM_HORIZONTAL_GAP = 195;
        const int ROOM_VERTICAL_GAP = 115;
        const int ROOM_WIDTH = 192;
        const int ROOM_HEIGHT = 112;

        static Rectangle ROOM_EMPTY_BACKGROUND = new Rectangle(ROOM_LEFT_START, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_1_BACKGROUND = new Rectangle(421, 1009, 256, 160);
        static Rectangle ROOM_2_BACKGROUND = new Rectangle(ROOM_LEFT_START, ROOM_TOP_START + 2 * ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_WIDTH);
        static Rectangle ROOM_3_BACKGROUND = new Rectangle(ROOM_LEFT_START + ROOM_HORIZONTAL_GAP, ROOM_TOP_START + 2 * ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_4_BACKGROUND = new Rectangle(ROOM_LEFT_START + 2 * ROOM_HORIZONTAL_GAP, ROOM_TOP_START + ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_5_BACKGROUND = new Rectangle(ROOM_LEFT_START + 4*ROOM_HORIZONTAL_GAP, ROOM_TOP_START + ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_6_BACKGROUND = new Rectangle(ROOM_LEFT_START + 5*ROOM_HORIZONTAL_GAP, ROOM_TOP_START + ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_7_BACKGROUND = new Rectangle(ROOM_LEFT_START + 5 * ROOM_HORIZONTAL_GAP, ROOM_TOP_START + 6*ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_8_BACKGROUND = new Rectangle(ROOM_LEFT_START, ROOM_TOP_START + ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_9_BACKGROUND = new Rectangle(ROOM_LEFT_START + ROOM_HORIZONTAL_GAP, ROOM_TOP_START + ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_10_BACKGROUND = new Rectangle(ROOM_LEFT_START + 4*ROOM_HORIZONTAL_GAP, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_11_BACKGROUND = new Rectangle(ROOM_LEFT_START + 2*ROOM_HORIZONTAL_GAP, ROOM_TOP_START + ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_12_BACKGROUND = new Rectangle(ROOM_LEFT_START + 3*ROOM_HORIZONTAL_GAP, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_13_BACKGROUND = new Rectangle(ROOM_LEFT_START + 4*ROOM_HORIZONTAL_GAP, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_14_BACKGROUND = new Rectangle(ROOM_LEFT_START + 5*ROOM_HORIZONTAL_GAP, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_15_BACKGROUND = new Rectangle(ROOM_LEFT_START + 3*ROOM_HORIZONTAL_GAP, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_16_BACKGROUND = new Rectangle(ROOM_LEFT_START, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_17_BACKGROUND = new Rectangle(ROOM_LEFT_START + ROOM_HORIZONTAL_GAP, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_18_BACKGROUND = new Rectangle(ROOM_LEFT_START + 2*ROOM_HORIZONTAL_GAP, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);

        public static List<Rectangle> ROOMS = new List<Rectangle>() { ROOM_1_BACKGROUND, ROOM_2_BACKGROUND, ROOM_3_BACKGROUND, ROOM_4_BACKGROUND, 
            ROOM_5_BACKGROUND, ROOM_6_BACKGROUND, ROOM_7_BACKGROUND, ROOM_8_BACKGROUND, ROOM_9_BACKGROUND, ROOM_10_BACKGROUND, ROOM_11_BACKGROUND, 
            ROOM_12_BACKGROUND, ROOM_13_BACKGROUND, ROOM_14_BACKGROUND, ROOM_15_BACKGROUND, ROOM_16_BACKGROUND, ROOM_17_BACKGROUND, ROOM_18_BACKGROUND };

        public static void Initialize(int width, int height)
        {
            BackgroundConstants.SCREEN_WIDTH = width;
            BackgroundConstants.SCREEN_HEIGHT = height;
        }
    }
}
