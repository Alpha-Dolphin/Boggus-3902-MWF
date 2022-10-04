using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.PlayerObjects
{
    public class LinkConstants
    {
        public enum Link_States
        {
            Normal,
            Walking,
            Attacking,
            UseItem,
            Damaged,
            Dead
        }
        public enum Link_Actions
        {
            Move,
            Attack,
            ChangeItem,
            Damage
        }
        public enum Link_Projectiles
        {
            Arrow,
            SwordBeam,
            Boomerang,
            Bomb,
            CandleFlame
        }
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public const int GAME_WIDTH = 800;
        public const int GAME_HEIGHT = 480;

        public const int DEFAULT_X = GAME_WIDTH / 2;
        public const int DEFAULT_Y = GAME_HEIGHT / 2;

        public static string[] DEFAULT_ITEMS = new string[] { "test" };
        public const LinkConstants.Link_States DEFAULT_STATE = LinkConstants.Link_States.Normal;
        public const LinkConstants.Direction DEFAULT_DIRECTION = LinkConstants.Direction.Down;

        public const string LINK_SPRITESHEET_NAME = "SpriteSheets/Link_EmptyBackground";
        public static Color DEFAULT_PICTURE_COLOR = Color.White;

        public static List<Keys> LINK_KEYS = new List<Keys>(new Keys[] { MOVE_UP_KEY, MOVE_LEFT_KEY, MOVE_RIGHT_KEY, MOVE_DOWN_KEY,
            ATTACK_SWORD1, ATTACK_SWORD2, 
            ITEM_1, ITEM_PAD1, ITEM_2, ITEM_PAD2, ITEM_3, ITEM_PAD3, ITEM_4, ITEM_PAD4, ITEM_5, ITEM_PAD5, 
            ITEM_6, ITEM_PAD6, ITEM_7, ITEM_PAD7, ITEM_8, ITEM_PAD8, ITEM_9, ITEM_PAD9, ITEM_0, ITEM_PAD0,
            DAMAGE_KEY });

        public static List<Keys> MOVEMENT_KEYS = new List<Keys>(new Keys[] { MOVE_UP_KEY, MOVE_LEFT_KEY, MOVE_RIGHT_KEY, MOVE_DOWN_KEY,
            MOVE_UPARROW_KEY, MOVE_LEFTARROW_KEY, MOVE_RIGHTARROW_KEY, MOVE_DOWNARROW_KEY });
        public const Keys MOVE_UP_KEY = Keys.W;
        public const Keys MOVE_UPARROW_KEY = Keys.Up;
        public const Keys MOVE_LEFT_KEY = Keys.A;
        public const Keys MOVE_LEFTARROW_KEY = Keys.Left;
        public const Keys MOVE_RIGHT_KEY = Keys.D;
        public const Keys MOVE_RIGHTARROW_KEY = Keys.Right;
        public const Keys MOVE_DOWN_KEY = Keys.S;
        public const Keys MOVE_DOWNARROW_KEY = Keys.Down;

        public static List<Keys> SWORD_ATTACK_KEYS = new List<Keys>( new Keys[] { ATTACK_SWORD1, ATTACK_SWORD2 });
        public const Keys ATTACK_SWORD1 = Keys.Z;
        public const Keys ATTACK_SWORD2 = Keys.N;

        public static List<Keys> ITEM_KEYS = new List<Keys>(new Keys[] { ITEM_1, ITEM_PAD1, ITEM_2, ITEM_PAD2, ITEM_3, ITEM_PAD3, ITEM_4, ITEM_PAD4,
            ITEM_5, ITEM_PAD5, ITEM_6, ITEM_PAD6, ITEM_7, ITEM_PAD7, ITEM_8, ITEM_PAD8, ITEM_9, ITEM_PAD9, ITEM_0, ITEM_PAD0});
        public const Keys ITEM_1 = Keys.D1;
        public const Keys ITEM_PAD1 = Keys.NumPad1;
        public const Keys ITEM_2 = Keys.D2;
        public const Keys ITEM_PAD2 = Keys.NumPad2;
        public const Keys ITEM_3 = Keys.D3;
        public const Keys ITEM_PAD3 = Keys.NumPad3;
        public const Keys ITEM_4 = Keys.D4;
        public const Keys ITEM_PAD4 = Keys.NumPad4;
        public const Keys ITEM_5 = Keys.D5;
        public const Keys ITEM_PAD5 = Keys.NumPad5;
        public const Keys ITEM_6 = Keys.D6;
        public const Keys ITEM_PAD6 = Keys.NumPad6;
        public const Keys ITEM_7 = Keys.D7;
        public const Keys ITEM_PAD7 = Keys.NumPad7;
        public const Keys ITEM_8 = Keys.D8;
        public const Keys ITEM_PAD8 = Keys.NumPad8;
        public const Keys ITEM_9 = Keys.D9;
        public const Keys ITEM_PAD9 = Keys.NumPad9;
        public const Keys ITEM_0 = Keys.D0;
        public const Keys ITEM_PAD0 = Keys.NumPad0;

        public static List<Keys> DAMAGE_KEYS = new List<Keys>(new Keys[] { DAMAGE_KEY });
        public const Keys DAMAGE_KEY = Keys.E;

        public const int MAX_HEALTH = 8;

        public const int DEFAULT_FRAMERATE = 10;

        public static Vector2 DEFAULT_LOCATIONSHIFT = new Vector2(0, 0);

        public const int LINK_MOVEDOWNWIDTH1 = 15;
        public const int LINK_MOVEDOWNWIDTH2 = 13;
        public const int LINK_MOVESIDEWIDTH1 = 15;
        public const int LINK_MOVESIDEWIDTH2 = 14;
        public const int LINK_MOVEUPWIDTH = 12;

        public const int LINK_MOVEHEIGHT = 16;
        public const int LINK_MOVESIDEHEIGHT2 = 15;

        public const int LINK_MOVEDOWNX1 = 1;
        public const int LINK_MOVEDOWNX2 = 19;
        public const int LINK_MOVELEFTX1 = 692;
        public const int LINK_MOVELEFTX2 = 676;
        public const int LINK_MOVERIGHTX1 = 35;
        public const int LINK_MOVERIGHTX2 = 52;
        public const int LINK_MOVEUPX1 = 71;
        public const int LINK_MOVEUPX2 = 88;

        public const int LINK_MOVEY = 11;
        public const int LINK_MOVESIDEY2 = 12;

        public static Rectangle LINK_MOVEUP_FRAME1 = new Rectangle(LINK_MOVEUPX1, LINK_MOVEY, LINK_MOVEUPWIDTH, LINK_MOVEHEIGHT);
        public static Rectangle LINK_MOVEUP_FRAME2 = new Rectangle(LINK_MOVEUPX2, LINK_MOVEY, LINK_MOVEUPWIDTH, LINK_MOVEHEIGHT);
        public static List<Rectangle> LINK_MOVEUP_FRAMES = new List<Rectangle> { LINK_MOVEUP_FRAME1, LINK_MOVEUP_FRAME2 };

        public static Rectangle LINK_MOVELEFT_FRAME1 = new Rectangle(LINK_MOVELEFTX1, LINK_MOVEY, LINK_MOVESIDEWIDTH1, LINK_MOVEHEIGHT);
        public static Rectangle LINK_MOVELEFT_FRAME2 = new Rectangle(LINK_MOVELEFTX2, LINK_MOVESIDEY2, LINK_MOVESIDEWIDTH2, LINK_MOVESIDEHEIGHT2);
        public static List<Rectangle> LINK_MOVELEFT_FRAMES = new List<Rectangle> { LINK_MOVELEFT_FRAME1, LINK_MOVELEFT_FRAME2 };

        public static Rectangle LINK_MOVERIGHT_FRAME1 = new Rectangle(LINK_MOVERIGHTX1, LINK_MOVEY, LINK_MOVESIDEWIDTH1, LINK_MOVEHEIGHT);
        public static Rectangle LINK_MOVERIGHT_FRAME2 = new Rectangle(LINK_MOVERIGHTX2, LINK_MOVESIDEY2, LINK_MOVESIDEWIDTH2, LINK_MOVESIDEHEIGHT2);
        public static List<Rectangle> LINK_MOVERIGHT_FRAMES = new List<Rectangle> { LINK_MOVERIGHT_FRAME1, LINK_MOVERIGHT_FRAME2 };

        public static Rectangle LINK_MOVEDOWN_FRAME1 = new Rectangle(LINK_MOVEDOWNX1, LINK_MOVEY, LINK_MOVEDOWNWIDTH1, LINK_MOVEHEIGHT);
        public static Rectangle LINK_MOVEDOWN_FRAME2 = new Rectangle(LINK_MOVEDOWNX2, LINK_MOVEY, LINK_MOVEDOWNWIDTH2, LINK_MOVEHEIGHT);
        public static List<Rectangle> LINK_MOVEDOWN_FRAMES = new List<Rectangle> { LINK_MOVEDOWN_FRAME1, LINK_MOVEDOWN_FRAME2 };

        public const int LINK_SWORD_ATTACKUPY1 = 109;
        public const int LINK_SWORD_ATTACKUPY2 = 97;
        public const int LINK_SWORD_ATTACKUPX3 = 37;
        public const int LINK_SWORD_ATTACKUPY3 = 98;
        public const int LINK_SWORD_ATTACKUPX4 = 54;
        public const int LINK_SWORD_ATTACKUPY4 = 106;

        public const int LINK_SWORD_ATTACKSIDEWIDTH1 = 15;
        public const int LINK_SWORD_ATTACKSIDEHEIGHT1 = 15;
        public const int LINK_SWORD_ATTACKSIDEWIDTH2 = 27;
        public const int LINK_SWORD_ATTACKSIDEHEIGHT2 = 15;
        public const int LINK_SWORD_ATTACKSIDEWIDTH3 = 23;
        public const int LINK_SWORD_ATTACKSIDEHEIGHT3 = 15;
        public const int LINK_SWORD_ATTACKSIDEWIDTH4 = 19;
        public const int LINK_SWORD_ATTACKSIDEHEIGHT4 = 16;

        public const int LINK_SWORD_ATTACKUPWIDTH1 = 16;
        public const int LINK_SWORD_ATTACKUPHEIGHT1 = 16;
        public const int LINK_SWORD_ATTACKUPWIDTH2 = 16;
        public const int LINK_SWORD_ATTACKUPHEIGHT2 = 28;
        public const int LINK_SWORD_ATTACKUPWIDTH3 = 12;
        public const int LINK_SWORD_ATTACKUPHEIGHT3 = 27;
        public const int LINK_SWORD_ATTACKUPWIDTH4 = 12;
        public const int LINK_SWORD_ATTACKUPHEIGHT4 = 19;

        public const int LINK_SWORD_ATTACKLEFTX1 = 726;
        public const int LINK_SWORD_ATTACKLEFTX2 = 697;
        public const int LINK_SWORD_ATTACKLEFTX3 = 673;
        public const int LINK_SWORD_ATTACKLEFTX4 = 653;
        public const int LINK_SWORD_ATTACKSIDEY = 78;
        public const int LINK_SWORD_ATTACKSIDEY4 = 77;
        public const int LINK_SWORD_ATTACKRIGHTX3 = 46;
        public const int LINK_SWORD_ATTACKRIGHTX4 = 70;

        public const int LINK_SWORD_ATTACKX1 = 1;
        public const int LINK_SWORD_ATTACKX2 = 18;
        public const int LINK_SWORD_ATTACKDOWNX3 = 35;
        public const int LINK_SWORD_ATTACKDOWNX4 = 53;
        public const int LINK_SWORD_ATTACKDOWNY = 47;

        public const int LINK_SWORD_ATTACKDOWNWIDTH1 = 16;
        public const int LINK_SWORD_ATTACKDOWNHEIGHT1 = 15;
        public const int LINK_SWORD_ATTACKDOWNWIDTH2 = 16;
        public const int LINK_SWORD_ATTACKDOWNHEIGHT2 = 27;
        public const int LINK_SWORD_ATTACKDOWNWIDTH3 = 15;
        public const int LINK_SWORD_ATTACKDOWNHEIGHT3 = 23;
        public const int LINK_SWORD_ATTACKDOWNWIDTH4 = 13;
        public const int LINK_SWORD_ATTACKDOWNHEIGHT4 = 19;

        public static Rectangle LINK_SWORD_ATTACKUP_FRAME1 = new Rectangle(LINK_SWORD_ATTACKX1, LINK_SWORD_ATTACKUPY1, LINK_SWORD_ATTACKUPWIDTH1, LINK_SWORD_ATTACKUPHEIGHT1);
        public static Vector2 LINK_SWORD_ATTACKUP_LOCATIONSHIFT1 = new Vector2(0, 0);
        public static Rectangle LINK_SWORD_ATTACKUP_FRAME2 = new Rectangle(LINK_SWORD_ATTACKX2, LINK_SWORD_ATTACKUPY2, LINK_SWORD_ATTACKUPWIDTH2, LINK_SWORD_ATTACKUPHEIGHT2);
        public static Vector2 LINK_SWORD_ATTACKUP_LOCATIONSHIFT2 = new Vector2(0, -12);
        public static Rectangle LINK_SWORD_ATTACKUP_FRAME3 = new Rectangle(LINK_SWORD_ATTACKUPX3, LINK_SWORD_ATTACKUPY3, LINK_SWORD_ATTACKUPWIDTH3, LINK_SWORD_ATTACKUPHEIGHT3);
        public static Vector2 LINK_SWORD_ATTACKUP_LOCATIONSHIFT3 = new Vector2(0, -11);
        public static Rectangle LINK_SWORD_ATTACKUP_FRAME4 = new Rectangle(LINK_SWORD_ATTACKUPX4, LINK_SWORD_ATTACKUPY4, LINK_SWORD_ATTACKUPWIDTH4, LINK_SWORD_ATTACKUPHEIGHT4);
        public static Vector2 LINK_SWORD_ATTACKUP_LOCATIONSHIFT4 = new Vector2(0, -3);
        public static List<Rectangle> LINK_SWORD_ATTACKUP_FRAMES = new List<Rectangle> { LINK_SWORD_ATTACKUP_FRAME1, LINK_SWORD_ATTACKUP_FRAME2, LINK_SWORD_ATTACKUP_FRAME3, LINK_SWORD_ATTACKUP_FRAME4 };
        public static List<Vector2> LINK_SWORD_ATTACKUP_LOCATIONSHIFT = new List<Vector2> { LINK_SWORD_ATTACKUP_LOCATIONSHIFT1, LINK_SWORD_ATTACKUP_LOCATIONSHIFT2, LINK_SWORD_ATTACKUP_LOCATIONSHIFT3, LINK_SWORD_ATTACKUP_LOCATIONSHIFT4 };
        
        public static Rectangle LINK_SWORD_ATTACKLEFT_FRAME1 = new Rectangle(LINK_SWORD_ATTACKLEFTX1, LINK_SWORD_ATTACKSIDEY, LINK_SWORD_ATTACKSIDEWIDTH1, LINK_SWORD_ATTACKSIDEHEIGHT1);
        public static Vector2 LINK_SWORD_ATTACKLEFT_LOCATIONSHIFT1 = new Vector2(0, 0);
        public static Rectangle LINK_SWORD_ATTACKLEFT_FRAME2 = new Rectangle(LINK_SWORD_ATTACKLEFTX2, LINK_SWORD_ATTACKSIDEY, LINK_SWORD_ATTACKSIDEWIDTH2, LINK_SWORD_ATTACKSIDEHEIGHT2);
        public static Vector2 LINK_SWORD_ATTACKLEFT_LOCATIONSHIFT2 = new Vector2(-12, 0);
        public static Rectangle LINK_SWORD_ATTACKLEFT_FRAME3 = new Rectangle(LINK_SWORD_ATTACKLEFTX3, LINK_SWORD_ATTACKSIDEY, LINK_SWORD_ATTACKSIDEWIDTH3, LINK_SWORD_ATTACKSIDEHEIGHT3);
        public static Vector2 LINK_SWORD_ATTACKLEFT_LOCATIONSHIFT3 = new Vector2(-9, 0);
        public static Rectangle LINK_SWORD_ATTACKLEFT_FRAME4 = new Rectangle(LINK_SWORD_ATTACKLEFTX4, LINK_SWORD_ATTACKSIDEY4, LINK_SWORD_ATTACKSIDEWIDTH4, LINK_SWORD_ATTACKSIDEHEIGHT4);
        public static Vector2 LINK_SWORD_ATTACKLEFT_LOCATIONSHIFT4 = new Vector2(-5, 0);
        public static List<Rectangle> LINK_SWORD_ATTACKLEFT_FRAMES = new List<Rectangle> { LINK_SWORD_ATTACKLEFT_FRAME1, LINK_SWORD_ATTACKLEFT_FRAME2, LINK_SWORD_ATTACKLEFT_FRAME3, LINK_SWORD_ATTACKLEFT_FRAME4 };
        public static List<Vector2> LINK_SWORD_ATTACKLEFT_LOCATIONSHIFT = new List<Vector2> { LINK_SWORD_ATTACKLEFT_LOCATIONSHIFT1, LINK_SWORD_ATTACKLEFT_LOCATIONSHIFT2, LINK_SWORD_ATTACKLEFT_LOCATIONSHIFT3, LINK_SWORD_ATTACKLEFT_LOCATIONSHIFT4 };

        public static Rectangle LINK_SWORD_ATTACKRIGHT_FRAME1 = new Rectangle(LINK_SWORD_ATTACKX1, LINK_SWORD_ATTACKSIDEY, LINK_SWORD_ATTACKSIDEWIDTH1, LINK_SWORD_ATTACKSIDEHEIGHT1);
        public static Rectangle LINK_SWORD_ATTACKRIGHT_FRAME2 = new Rectangle(LINK_SWORD_ATTACKX2, LINK_SWORD_ATTACKSIDEY, LINK_SWORD_ATTACKSIDEWIDTH2, LINK_SWORD_ATTACKSIDEHEIGHT2);
        public static Rectangle LINK_SWORD_ATTACKRIGHT_FRAME3 = new Rectangle(LINK_SWORD_ATTACKRIGHTX3, LINK_SWORD_ATTACKSIDEY, LINK_SWORD_ATTACKSIDEWIDTH3, LINK_SWORD_ATTACKSIDEHEIGHT3);
        public static Rectangle LINK_SWORD_ATTACKRIGHT_FRAME4 = new Rectangle(LINK_SWORD_ATTACKRIGHTX4, LINK_SWORD_ATTACKSIDEY4, LINK_SWORD_ATTACKSIDEWIDTH4, LINK_SWORD_ATTACKSIDEHEIGHT4);
        public static List<Rectangle> LINK_SWORD_ATTACKRIGHT_FRAMES = new List<Rectangle> { LINK_SWORD_ATTACKRIGHT_FRAME1, LINK_SWORD_ATTACKRIGHT_FRAME2, LINK_SWORD_ATTACKRIGHT_FRAME3, LINK_SWORD_ATTACKRIGHT_FRAME4 };

        public static Rectangle LINK_SWORD_ATTACKDOWN_FRAME1 = new Rectangle(LINK_SWORD_ATTACKX1, LINK_SWORD_ATTACKDOWNY, LINK_SWORD_ATTACKDOWNWIDTH1, LINK_SWORD_ATTACKDOWNHEIGHT1);
        public static Rectangle LINK_SWORD_ATTACKDOWN_FRAME2 = new Rectangle(LINK_SWORD_ATTACKX2, LINK_SWORD_ATTACKDOWNY, LINK_SWORD_ATTACKDOWNWIDTH2, LINK_SWORD_ATTACKDOWNHEIGHT2);
        public static Rectangle LINK_SWORD_ATTACKDOWN_FRAME3 = new Rectangle(LINK_SWORD_ATTACKDOWNX3, LINK_SWORD_ATTACKDOWNY, LINK_SWORD_ATTACKDOWNWIDTH3, LINK_SWORD_ATTACKDOWNHEIGHT3);
        public static Rectangle LINK_SWORD_ATTACKDOWN_FRAME4 = new Rectangle(LINK_SWORD_ATTACKDOWNX4, LINK_SWORD_ATTACKDOWNY, LINK_SWORD_ATTACKDOWNWIDTH4, LINK_SWORD_ATTACKDOWNHEIGHT4);
        public static List<Rectangle> LINK_SWORD_ATTACKDOWN_FRAMES = new List<Rectangle> { LINK_SWORD_ATTACKDOWN_FRAME1, LINK_SWORD_ATTACKDOWN_FRAME2, LINK_SWORD_ATTACKDOWN_FRAME3, LINK_SWORD_ATTACKDOWN_FRAME4 };

        public static Rectangle DAMAGED_RED = new Rectangle(143, 258, 15, 16);
        public static List<Rectangle> DAMAGED = new List<Rectangle> { LINK_MOVEDOWN_FRAME1, DAMAGED_RED };
        public const int DAMAGED_FRAMERATE = 5;

        public const int INVINCIBILITY_FRAMES = 30;

        public const int USE_ITEM_UPX = 141;
        public const int USE_ITEM_UPY = 11;
        public const int USE_ITEM_UPWIDTH = 16;
        public const int USE_ITEM_UPHEIGHT = 16;
        public static List<Rectangle> USE_ITEM_UP_FRAMES = new List<Rectangle> { new Rectangle(USE_ITEM_UPX, USE_ITEM_UPY, USE_ITEM_UPWIDTH, USE_ITEM_UPHEIGHT) };

        public const int USE_ITEM_LEFTX = 603;
        public const int USE_ITEM_LEFTY = 12;
        public const int USE_ITEM_LEFTWIDTH = 15;
        public const int USE_ITEM_LEFTHEIGHT = 15;
        public static List<Rectangle> USE_ITEM_LEFT_FRAMES = new List<Rectangle> { new Rectangle(USE_ITEM_LEFTX, USE_ITEM_LEFTY, USE_ITEM_LEFTWIDTH, USE_ITEM_LEFTHEIGHT) };

        public const int USE_ITEM_RIGHTX = 124;
        public const int USE_ITEM_RIGHTY = 12;
        public const int USE_ITEM_RIGHTWIDTH = 15;
        public const int USE_ITEM_RIGHTHEIGHT = 15;
        public static List<Rectangle> USE_ITEM_RIGHT_FRAMES = new List<Rectangle> { new Rectangle(USE_ITEM_RIGHTX, USE_ITEM_RIGHTY, USE_ITEM_RIGHTWIDTH, USE_ITEM_RIGHTHEIGHT) };

        public const int USE_ITEM_DOWNX = 107;
        public const int USE_ITEM_DOWNY = 11;
        public const int USE_ITEM_DOWNWIDTH = 16;
        public const int USE_ITEM_DOWNHEIGHT = 15;
        public static List<Rectangle> USE_ITEM_DOWN_FRAMES = new List<Rectangle> { new Rectangle(USE_ITEM_DOWNX, USE_ITEM_DOWNY, USE_ITEM_DOWNWIDTH, USE_ITEM_DOWNHEIGHT) };

        public const int SWORD_WIDTH = 7;
        public const int SWORD_HEIGHT = 16;

        public const int SWORD_MAGICAL_BLUE_UPX = 36;
        public const int SWORD_MAGICAL_BLUE_UPY = 154;
        public static Rectangle SWORD_MAGICAL_BLUE_UP = new Rectangle(SWORD_MAGICAL_BLUE_UPX, SWORD_MAGICAL_BLUE_UPY, SWORD_WIDTH, SWORD_HEIGHT);

        public const int SWORD_MAGICAL_BLUE_LEFTX = 681;
        public const int SWORD_MAGICAL_BLUE_LEFTY = 159;
        public static Rectangle SWORD_MAGICAL_BLUE_LEFT = new Rectangle(SWORD_MAGICAL_BLUE_LEFTX, SWORD_MAGICAL_BLUE_LEFTY, SWORD_HEIGHT, SWORD_WIDTH);

        public const int SWORD_MAGICAL_BLUE_RIGHTX = 45;
        public const int SWORD_MAGICAL_BLUE_RIGHTY = 159;
        public static Rectangle SWORD_MAGICAL_BLUE_RIGHT = new Rectangle(SWORD_MAGICAL_BLUE_RIGHTX, SWORD_MAGICAL_BLUE_RIGHTY, SWORD_HEIGHT, SWORD_WIDTH);

        public const int SWORD_MAGICAL_BLUE_DOWNX = 319;
        public const int SWORD_MAGICAL_BLUE_DOWNY = 154;
        public static Rectangle SWORD_MAGICAL_BLUE_DOWN = new Rectangle(SWORD_MAGICAL_BLUE_DOWNX, SWORD_MAGICAL_BLUE_DOWNY, SWORD_WIDTH, SWORD_HEIGHT);

        public const int SWORD_MAGICAL_RED_UPX = 71;
        public const int SWORD_MAGICAL_RED_UPY = 154;
        public static Rectangle SWORD_MAGICAL_RED_UP = new Rectangle(SWORD_MAGICAL_RED_UPX, SWORD_MAGICAL_RED_UPY, SWORD_WIDTH, SWORD_HEIGHT);

        public const int SWORD_MAGICAL_RED_LEFTX = 646;
        public const int SWORD_MAGICAL_RED_LEFTY = 159;
        public static Rectangle SWORD_MAGICAL_RED_LEFT = new Rectangle(SWORD_MAGICAL_RED_LEFTX, SWORD_MAGICAL_RED_LEFTY, SWORD_HEIGHT, SWORD_WIDTH);

        public const int SWORD_MAGICAL_RED_RIGHTX = 80;
        public const int SWORD_MAGICAL_RED_RIGHTY = 159;
        public static Rectangle SWORD_MAGICAL_RED_RIGHT = new Rectangle(SWORD_MAGICAL_RED_RIGHTX, SWORD_MAGICAL_RED_RIGHTY, SWORD_HEIGHT, SWORD_WIDTH);

        public const int SWORD_MAGICAL_RED_DOWNX = 331;
        public const int SWORD_MAGICAL_RED_DOWNY = 154;
        public static Rectangle SWORD_MAGICAL_RED_DOWN = new Rectangle(SWORD_MAGICAL_RED_DOWNX, SWORD_MAGICAL_RED_DOWNY, SWORD_WIDTH, SWORD_HEIGHT);

        public static List<Rectangle> SWORDBEAM_UP_FRAMES = new List<Rectangle> { SWORD_MAGICAL_BLUE_UP, SWORD_MAGICAL_RED_UP };
        public static Vector2 SWORDBEAM_UP_LOCATIONSHIFT_DEFAULT = new Vector2(3, 0);
        public static List<Vector2> SWORDBEAM_UP_LOCATIONSHIFT = new List<Vector2> { SWORDBEAM_UP_LOCATIONSHIFT_DEFAULT + LINK_SWORD_ATTACKUP_LOCATIONSHIFT2 };
        public static List<Rectangle> SWORDBEAM_LEFT_FRAMES = new List<Rectangle> { SWORD_MAGICAL_BLUE_LEFT, SWORD_MAGICAL_RED_LEFT };
        public static Vector2 SWORDBEAM_LEFT_LOCATIONSHIFT_DEFAULT = new Vector2(0, 5);
        public static List<Vector2> SWORDBEAM_LEFT_LOCATIONSHIFT = new List<Vector2> { SWORDBEAM_LEFT_LOCATIONSHIFT_DEFAULT + LINK_SWORD_ATTACKLEFT_LOCATIONSHIFT2 };
        public static List<Rectangle> SWORDBEAM_RIGHT_FRAMES = new List<Rectangle> { SWORD_MAGICAL_BLUE_RIGHT, SWORD_MAGICAL_RED_RIGHT };
        public static List<Vector2> SWORDBEAM_RIGHT_LOCATIONSHIFT = new List<Vector2> { new Vector2(15, 5) };
        public static List<Rectangle> SWORDBEAM_DOWN_FRAMES = new List<Rectangle> { SWORD_MAGICAL_BLUE_DOWN, SWORD_MAGICAL_RED_DOWN };
        public static List<Vector2> SWORDBEAM_DOWN_LOCATIONSHIFT = new List<Vector2> { new Vector2(5, 15) };

        public const int WOODARROW_WIDTH = 5;
        public const int WOODARROW_HEIGHT = 16;

        public const int ARROW_WOOD_UPX = 3;
        public const int ARROW_WOOD_UPY = 185;
        public static Rectangle ARROW_WOOD_UP = new Rectangle(ARROW_WOOD_UPX, ARROW_WOOD_UPY, WOODARROW_WIDTH, WOODARROW_HEIGHT);
        public static List<Rectangle> ARROW_WOOD_UP_FRAMES = new List<Rectangle> { ARROW_WOOD_UP };
        public static List<Vector2> ARROW_UP_LOCATIONSHIFT = new List<Vector2>(new Vector2[] { new Vector2(6, 0) });

        public const int ARROW_WOOD_LEFTX = 716;
        public const int ARROW_WOOD_LEFTY = 190;
        public static Rectangle ARROW_WOOD_LEFT = new Rectangle(ARROW_WOOD_LEFTX, ARROW_WOOD_LEFTY, WOODARROW_HEIGHT, WOODARROW_WIDTH);
        public static List<Rectangle> ARROW_WOOD_LEFT_FRAMES = new List<Rectangle> { ARROW_WOOD_LEFT };
        public static List<Vector2> ARROW_LEFT_LOCATIONSHIFT = new List<Vector2>(new Vector2[] { new Vector2(0, 7) });

        public const int ARROW_WOOD_RIGHTX = 10;
        public const int ARROW_WOOD_RIGHTY = 190;
        public static Rectangle ARROW_WOOD_RIGHT = new Rectangle(ARROW_WOOD_RIGHTX, ARROW_WOOD_RIGHTY, WOODARROW_HEIGHT, WOODARROW_WIDTH);
        public static List<Rectangle> ARROW_WOOD_RIGHT_FRAMES = new List<Rectangle> { ARROW_WOOD_RIGHT };
        public static List<Vector2> ARROW_RIGHT_LOCATIONSHIFT = new List<Vector2>(new Vector2[] { new Vector2(0, 7) });

        public const int ARROW_WOOD_DOWNX = 318;
        public const int ARROW_WOOD_DOWNY = 185;
        public static Rectangle ARROW_WOOD_DOWN = new Rectangle(ARROW_WOOD_DOWNX, ARROW_WOOD_DOWNY, WOODARROW_WIDTH, WOODARROW_HEIGHT);
        public static List<Rectangle> ARROW_WOOD_DOWN_FRAMES = new List<Rectangle> { ARROW_WOOD_DOWN };
        public static List<Vector2> ARROW_DOWN_LOCATIONSHIFT = new List<Vector2>(new Vector2[] { new Vector2(7, 15) });

        public const int MAX_WOODEN_ARROW_RANGE = 200;
        public const int MAX_BLUE_ARROW_RANGE = 400;
        public const int MAX_SWORDBEAM_RANGE = 300;

        public const int PROJECTILE_SPEED = 5;
        public const int BOOMERANG_SPEED = 7;
        public const int BOMB_EXPLOSION_DELAY = 10;

        public const int BOOMERANG_WOOD_WIDTH = 8;
        public const int BOOMERANG_WOOD_HEIGHT = 5;

        static Rectangle BOOMERANG_WOOD_FRAME1 = new Rectangle(65, 189, BOOMERANG_WOOD_HEIGHT, BOOMERANG_WOOD_WIDTH);
        static Rectangle BOOMERANG_WOOD_FRAME2 = new Rectangle(73, 189, BOOMERANG_WOOD_WIDTH, BOOMERANG_WOOD_WIDTH);
        static Rectangle BOOMERANG_WOOD_FRAME3 = new Rectangle(82, 191, BOOMERANG_WOOD_WIDTH, BOOMERANG_WOOD_HEIGHT);
        static Rectangle BOOMERANG_WOOD_FRAME4 = new Rectangle(661, 189, BOOMERANG_WOOD_WIDTH, BOOMERANG_WOOD_WIDTH);
        static Rectangle BOOMERANG_WOOD_FRAME5 = new Rectangle(672, 189, BOOMERANG_WOOD_HEIGHT, BOOMERANG_WOOD_WIDTH);
        static Rectangle BOOMERANG_WOOD_FRAME6 = new Rectangle(341, 189, BOOMERANG_WOOD_WIDTH, BOOMERANG_WOOD_WIDTH);
        static Rectangle BOOMERANG_WOOD_FRAME7 = new Rectangle(368, 190, BOOMERANG_WOOD_WIDTH, BOOMERANG_WOOD_HEIGHT);
        static Rectangle BOOMERANG_WOOD_FRAME8 = new Rectangle(354, 189, BOOMERANG_WOOD_WIDTH, BOOMERANG_WOOD_WIDTH);
        public static List<Rectangle> BOOMERANG_WOOD_FRAMES = new List<Rectangle> { BOOMERANG_WOOD_FRAME1, BOOMERANG_WOOD_FRAME2, BOOMERANG_WOOD_FRAME3,
            BOOMERANG_WOOD_FRAME4, BOOMERANG_WOOD_FRAME5, BOOMERANG_WOOD_FRAME6, BOOMERANG_WOOD_FRAME7, BOOMERANG_WOOD_FRAME8 };

        public const float BOOMERANG_SPEEDCHANGE = 0.1f;
        public const int BOOMERANG_RETURNSPEEDCHANGE = 300;
        public const int BOOMERANG_RETURNRANGE = 30;

        const int CANDLEFLAME_WIDTH = 16;
        const int CANDLEFLAME_HEIGHT = 16;
        static Rectangle CANDLEFLAME_FRAME1 = new Rectangle(191, 185, CANDLEFLAME_WIDTH, CANDLEFLAME_HEIGHT);
        static Rectangle CANDLEFLAME_FRAME2 = new Rectangle(535, 185, CANDLEFLAME_WIDTH, CANDLEFLAME_HEIGHT);
        public static List<Rectangle> CANDLEFLAME_FRAMES = new List<Rectangle> { CANDLEFLAME_FRAME1, CANDLEFLAME_FRAME2 };

        public static Rectangle BOMB_FRAME = new Rectangle(129, 185, 8, 14);

        const int BOMB_EXPLOSIONY = 185;
        const int BOMB_EXPLOSION_WIDTH = 16;
        static Rectangle BOMB_EXPLOSION_FRAME1 = new Rectangle(138, BOMB_EXPLOSIONY, BOMB_EXPLOSION_WIDTH, BOMB_EXPLOSION_WIDTH);
        static Rectangle BOMB_EXPLOSION_FRAME2 = new Rectangle(155, BOMB_EXPLOSIONY, BOMB_EXPLOSION_WIDTH, BOMB_EXPLOSION_WIDTH);
        static Rectangle BOMB_EXPLOSION_FRAME3 = new Rectangle(172, BOMB_EXPLOSIONY, BOMB_EXPLOSION_WIDTH, BOMB_EXPLOSION_WIDTH);
        public static List<Rectangle> BOMB_EXPLOSION_FRAMES = new List<Rectangle> { BOMB_EXPLOSION_FRAME1, BOMB_EXPLOSION_FRAME2, BOMB_EXPLOSION_FRAME3 };

        public static void Initialize()
        {
        }
    }
}