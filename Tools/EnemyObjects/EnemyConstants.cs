using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.EnemyObjects
{
    internal class EnemyConstants
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            None
        }

        private static Rectangle GORIYA_UP1 = new Rectangle(239, 11, 16, 16);
        private static Rectangle GORIYA_UP2 = new Rectangle(659, 11, 16, 16);
        private static Rectangle GORIYA_LEFT1 = new Rectangle(642, 11, 16, 16);
        private static Rectangle GORIYA_LEFT2 = new Rectangle(625, 11, 16, 16);
        private static Rectangle GORIYA_RIGHT1 = new Rectangle(256, 11, 16, 16);
        private static Rectangle GORIYA_RIGHT2 = new Rectangle(273, 11, 16, 16);
        private static Rectangle GORIYA_DOWN1 = new Rectangle(222, 11, 16, 16);
        private static Rectangle GORIYA_DOWN2 = new Rectangle(676, 11, 16, 16);

        public static List<Rectangle> GORIYA_UP = new List<Rectangle>() { GORIYA_UP1, GORIYA_UP2 };
        public static List<Rectangle> GORIYA_LEFT = new List<Rectangle>() { GORIYA_LEFT1, GORIYA_LEFT2 };
        public static List<Rectangle> GORIYA_RIGHT = new List<Rectangle>() { GORIYA_RIGHT1, GORIYA_RIGHT2 };
        public static List<Rectangle> GORIYA_DOWN = new List<Rectangle>() { GORIYA_DOWN1, GORIYA_DOWN2 };

        private static Rectangle STALFOS1 = new Rectangle(1, 59, 16, 16);
        private static Rectangle STALFOS2 = new Rectangle(897, 59, 16, 16);
        public static List<Rectangle> STALFOS = new List<Rectangle>() { STALFOS1, STALFOS2 };
    }
}
