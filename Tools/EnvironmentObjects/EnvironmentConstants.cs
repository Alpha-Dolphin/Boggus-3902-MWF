using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.Sprites;
using LOZ.Tools.HUDObjects;

namespace LOZ.Tools.EnvironmentObjects
{
    internal class EnvironmentConstants
    {
        public static int SCREEN_WIDTH;
        public static int SCREEN_HEIGHT;

        public static int EXTERIOR_WIDTH = 32;

        public static Rectangle ROOM_EXTERIOR = new Rectangle(521, 11, 256, 176);
        public enum DoorType
        {
            Wall,
            Open,
            Locked,
            Closed,
            Hole,
            Nothing
        }

        public static DoorType[][] ROOM_DOORS = new DoorType[19][]
        {
            new DoorType[] { DoorType.Wall, DoorType.Open, DoorType.Locked, DoorType.Closed }, //0
            new DoorType[] { DoorType.Nothing, DoorType.Nothing, DoorType.Nothing, DoorType.Nothing }, //1
            new DoorType[] { DoorType.Wall, DoorType.Wall, DoorType.Locked, DoorType.Wall }, //2
            new DoorType[] { DoorType.Wall, DoorType.Locked, DoorType.Wall, DoorType.Locked }, //3
            new DoorType[] { DoorType.Locked, DoorType.Wall, DoorType.Wall, DoorType.Open }, //4
            new DoorType[] { DoorType.Wall, DoorType.Wall, DoorType.Closed, DoorType.Locked }, //5
            new DoorType[] { DoorType.Wall, DoorType.Open, DoorType.Wall, DoorType.Wall }, //6
            new DoorType[] { DoorType.Wall, DoorType.Wall, DoorType.Open, DoorType.Wall }, //7
            new DoorType[] { DoorType.Wall, DoorType.Closed, DoorType.Open, DoorType.Locked }, //8
            new DoorType[] { DoorType.Open, DoorType.Open, DoorType.Locked, DoorType.Hole }, //9
            new DoorType[] { DoorType.Wall, DoorType.Locked, DoorType.Open, DoorType.Hole }, //10
            new DoorType[] { DoorType.Open, DoorType.Open, DoorType.Wall, DoorType.Wall }, //11
            new DoorType[] { DoorType.Locked, DoorType.Wall, DoorType.Closed, DoorType.Wall }, //12
            new DoorType[] { DoorType.Hole, DoorType.Open, DoorType.Open, DoorType.Open }, //13
            new DoorType[] { DoorType.Hole, DoorType.Open, DoorType.Wall, DoorType.Wall }, //14
            new DoorType[] { DoorType.Open, DoorType.Wall, DoorType.Wall, DoorType.Locked }, //15
            new DoorType[] { DoorType.Wall, DoorType.Wall, DoorType.Open, DoorType.Wall }, //16
            new DoorType[] { DoorType.Locked, DoorType.Open, DoorType.Open, DoorType.Open }, //17
            new DoorType[] { DoorType.Wall, DoorType.Open, DoorType.Wall, DoorType.Wall } //18
        };

        public const int DOOR_WIDTH = 32;

        static Rectangle DOOR_WALL_TOP = new Rectangle(815, 11, DOOR_WIDTH, DOOR_WIDTH);
        static Rectangle DOOR_WALL_LEFT = new Rectangle(815, 44, DOOR_WIDTH, DOOR_WIDTH);
        static Rectangle DOOR_WALL_RIGHT = new Rectangle(815, 77, DOOR_WIDTH, DOOR_WIDTH);
        static Rectangle DOOR_WALL_BOTTOM = new Rectangle(815, 110, DOOR_WIDTH, DOOR_WIDTH);
        public static List<Rectangle> DOOR_WALL = new List<Rectangle>() { DOOR_WALL_TOP, DOOR_WALL_LEFT, DOOR_WALL_RIGHT, DOOR_WALL_BOTTOM };

        static Rectangle DOOR_OPEN_TOP = new Rectangle(848, 11, DOOR_WIDTH, DOOR_WIDTH);
        static Rectangle DOOR_OPEN_LEFT = new Rectangle(848, 44, DOOR_WIDTH, DOOR_WIDTH);
        static Rectangle DOOR_OPEN_RIGHT = new Rectangle(848, 77, DOOR_WIDTH, DOOR_WIDTH);
        static Rectangle DOOR_OPEN_BOTTOM = new Rectangle(848, 110, DOOR_WIDTH, DOOR_WIDTH);
        public static List<Rectangle> DOOR_OPEN = new List<Rectangle>() { DOOR_OPEN_TOP, DOOR_OPEN_LEFT, DOOR_OPEN_RIGHT, DOOR_OPEN_BOTTOM };

        static Rectangle DOOR_LOCKED_TOP = new Rectangle(881, 11, DOOR_WIDTH, DOOR_WIDTH);
        static Rectangle DOOR_LOCKED_LEFT = new Rectangle(881, 44, DOOR_WIDTH, DOOR_WIDTH);
        static Rectangle DOOR_LOCKED_RIGHT = new Rectangle(881, 77, DOOR_WIDTH, DOOR_WIDTH);
        static Rectangle DOOR_LOCKED_BOTTOM = new Rectangle(881, 110, DOOR_WIDTH, DOOR_WIDTH);
        public static List<Rectangle> DOOR_LOCKED = new List<Rectangle>() { DOOR_LOCKED_TOP, DOOR_LOCKED_LEFT, DOOR_LOCKED_RIGHT, DOOR_LOCKED_BOTTOM };

        static Rectangle DOOR_CLOSED_TOP = new Rectangle(914, 11, DOOR_WIDTH, DOOR_WIDTH);
        static Rectangle DOOR_CLOSED_LEFT = new Rectangle(914, 44, DOOR_WIDTH, DOOR_WIDTH);
        static Rectangle DOOR_CLOSED_RIGHT = new Rectangle(914, 77, DOOR_WIDTH, DOOR_WIDTH);
        static Rectangle DOOR_CLOSED_BOTTOM = new Rectangle(914, 110, DOOR_WIDTH, DOOR_WIDTH);
        public static List<Rectangle> DOOR_CLOSED = new List<Rectangle>() { DOOR_CLOSED_TOP, DOOR_CLOSED_LEFT, DOOR_CLOSED_RIGHT, DOOR_CLOSED_BOTTOM };

        static Rectangle DOOR_HOLE_TOP = new Rectangle(947, 11, DOOR_WIDTH, DOOR_WIDTH);
        static Rectangle DOOR_HOLE_LEFT = new Rectangle(947, 44, DOOR_WIDTH, DOOR_WIDTH);
        static Rectangle DOOR_HOLE_RIGHT = new Rectangle(947, 77, DOOR_WIDTH, DOOR_WIDTH);
        static Rectangle DOOR_HOLE_BOTTOM = new Rectangle(947, 110, DOOR_WIDTH, DOOR_WIDTH);
        public static List<Rectangle> DOOR_HOLE = new List<Rectangle>() { DOOR_HOLE_TOP, DOOR_HOLE_LEFT, DOOR_HOLE_RIGHT, DOOR_HOLE_BOTTOM };

        const int ROOM_LEFT_START = 1;
        const int ROOM_TOP_START = 192;
        const int ROOM_HORIZONTAL_GAP = 195;
        const int ROOM_VERTICAL_GAP = 115;
        const int ROOM_WIDTH = 192;
        const int ROOM_HEIGHT = 112;

        public static Rectangle ROOM_EMPTY_BACKGROUND = new Rectangle(ROOM_LEFT_START, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_1_BACKGROUND = new Rectangle(421, 1009, 256, 160);
        static Rectangle ROOM_2_BACKGROUND = new Rectangle(ROOM_LEFT_START, ROOM_TOP_START + 2 * ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_3_BACKGROUND = new Rectangle(ROOM_LEFT_START + ROOM_HORIZONTAL_GAP, ROOM_TOP_START + 2 * ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_4_BACKGROUND = new Rectangle(ROOM_LEFT_START + 3 * ROOM_HORIZONTAL_GAP, ROOM_TOP_START + ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_5_BACKGROUND = new Rectangle(ROOM_LEFT_START + 4 * ROOM_HORIZONTAL_GAP, ROOM_TOP_START + ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_6_BACKGROUND = new Rectangle(ROOM_LEFT_START + 5 * ROOM_HORIZONTAL_GAP, ROOM_TOP_START + ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_7_BACKGROUND = new Rectangle(ROOM_LEFT_START + 5 * ROOM_HORIZONTAL_GAP, ROOM_TOP_START + 6 * ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_8_BACKGROUND = new Rectangle(ROOM_LEFT_START, ROOM_TOP_START + ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_9_BACKGROUND = new Rectangle(ROOM_LEFT_START + ROOM_HORIZONTAL_GAP, ROOM_TOP_START + ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_10_BACKGROUND = new Rectangle(ROOM_LEFT_START + 4 * ROOM_HORIZONTAL_GAP, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_11_BACKGROUND = new Rectangle(ROOM_LEFT_START + 2 * ROOM_HORIZONTAL_GAP, ROOM_TOP_START + ROOM_VERTICAL_GAP, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_12_BACKGROUND = new Rectangle(ROOM_LEFT_START + 3 * ROOM_HORIZONTAL_GAP, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_13_BACKGROUND = new Rectangle(ROOM_LEFT_START + 4 * ROOM_HORIZONTAL_GAP, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_14_BACKGROUND = new Rectangle(ROOM_LEFT_START + 5 * ROOM_HORIZONTAL_GAP, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_15_BACKGROUND = new Rectangle(ROOM_LEFT_START + 3 * ROOM_HORIZONTAL_GAP, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_16_BACKGROUND = new Rectangle(ROOM_LEFT_START, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_17_BACKGROUND = new Rectangle(ROOM_LEFT_START + ROOM_HORIZONTAL_GAP, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);
        static Rectangle ROOM_18_BACKGROUND = new Rectangle(ROOM_LEFT_START + 2 * ROOM_HORIZONTAL_GAP, ROOM_TOP_START, ROOM_WIDTH, ROOM_HEIGHT);

        public static List<Rectangle> ROOMS = new List<Rectangle>() { ROOM_EMPTY_BACKGROUND, ROOM_1_BACKGROUND, ROOM_2_BACKGROUND, ROOM_3_BACKGROUND, ROOM_4_BACKGROUND,
            ROOM_5_BACKGROUND, ROOM_6_BACKGROUND, ROOM_7_BACKGROUND, ROOM_8_BACKGROUND, ROOM_9_BACKGROUND, ROOM_10_BACKGROUND, ROOM_11_BACKGROUND,
            ROOM_12_BACKGROUND, ROOM_13_BACKGROUND, ROOM_14_BACKGROUND, ROOM_15_BACKGROUND, ROOM_16_BACKGROUND, ROOM_17_BACKGROUND, ROOM_18_BACKGROUND };

        public static void Initialize(int width, int height)
        {
            SCREEN_WIDTH = width;
            SCREEN_HEIGHT = height;
            AnimatedMovingSprite.xScale = Sprite.xScale = width / ROOM_EXTERIOR.Width;
            AnimatedMovingSprite.yScale = Sprite.yScale = (height - HUDConstants.TOP_HEIGHT) / ROOM_EXTERIOR.Height;
        }
    }
}
