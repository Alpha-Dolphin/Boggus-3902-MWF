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
        public const int ENEMY_ANIMATION_SPEED = 5;
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


        private static Rectangle DODONGO_UP1 = new Rectangle(35, 58, 16, 16);
        private static Rectangle DODONGO_UP2 = new Rectangle(52, 58, 16, 16);
        private static Rectangle DODONGO_LEFT1 = new Rectangle(887, 58, 16, 16);
        private static Rectangle DODONGO_LEFT2 = new Rectangle(854, 58, 16, 16);
        private static Rectangle DODONGO_LEFT3 = new Rectangle(821, 58, 16, 16);
        private static Rectangle DODONGO_RIGHT1 = new Rectangle(69, 58, 32, 16);
        private static Rectangle DODONGO_RIGHT2 = new Rectangle(102, 58, 16, 16);
        private static Rectangle DODONGO_RIGHT3 = new Rectangle(135, 58, 16, 16);
        private static Rectangle DODONGO_DOWN1 = new Rectangle(1, 58, 16, 16);
        private static Rectangle DODONGO_DOWN2 = new Rectangle(18, 58, 16, 16);

        public static List<Rectangle> DODONGO_UP = new List<Rectangle>() { DODONGO_UP1, DODONGO_UP2 };
        public static List<Rectangle> DODONGO_LEFT = new List<Rectangle>() { DODONGO_LEFT1, DODONGO_LEFT2, DODONGO_LEFT3 };
        public static List<Rectangle> DODONGO_RIGHT = new List<Rectangle>() { DODONGO_RIGHT1, DODONGO_RIGHT2, DODONGO_RIGHT3 };
        public static List<Rectangle> DODONGO_DOWN = new List<Rectangle>() { DODONGO_DOWN1, DODONGO_DOWN2 };


        private static Rectangle AQUAMENTUS_PROJECTILE1 = new Rectangle(101, 11, 8, 16);
        private static Rectangle AQUAMENTUS_PROJECTILE2 = new Rectangle(110, 11, 8, 16);
        private static Rectangle AQUAMENTUS_PROJECTILE3 = new Rectangle(119, 11, 8, 16);
        private static Rectangle AQUAMENTUS_PROJECTILE4 = new Rectangle(128, 11, 8, 16);
        public static List<Rectangle> AQUAMENTUS_PROJECTILE = new List<Rectangle>() { AQUAMENTUS_PROJECTILE1, AQUAMENTUS_PROJECTILE2, AQUAMENTUS_PROJECTILE3, AQUAMENTUS_PROJECTILE4 };
    }
}
