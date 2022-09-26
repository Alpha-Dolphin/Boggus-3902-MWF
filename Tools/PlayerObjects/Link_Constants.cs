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
    public class Link_Constants
    {
        public enum Link_States
        {
            Normal,
            Walking,
            Attacking,
            Dead
        }
        public enum Link_Actions
        {
            Move,
            Attack,
            ChangeItem,
            Damage
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
        public const Link_Constants.Link_States DEFAULT_STATE = Link_Constants.Link_States.Normal;
        public const Link_Constants.Direction DEFAULT_DIRECTION = Link_Constants.Direction.Down;

        public const string LINK_SPRITESHEET_NAME = "SpriteSheets/Link_EmptyBackground";
        public static Color DEFAULT_PICTURE_COLOR = Color.White;

        public static List<Keys> LINK_KEYS = new List<Keys>(new Keys[] { MOVE_UP_KEY, MOVE_LEFT_KEY, MOVE_RIGHT_KEY, MOVE_DOWN_KEY,
            ATTACK_SWORD1, ATTACK_SWORD2, 
            ITEM_1, ITEM_PAD1, ITEM_2, ITEM_PAD2, ITEM_3, ITEM_PAD3, ITEM_4, ITEM_PAD4, ITEM_5, ITEM_PAD5, 
            ITEM_6, ITEM_PAD6, ITEM_7, ITEM_PAD7, ITEM_8, ITEM_PAD8, ITEM_9, ITEM_PAD9, ITEM_0, ITEM_PAD0,
            DAMAGE_KEY });

        public static List<Keys> MOVEMENT_KEYS = new List<Keys>(new Keys[] { MOVE_UP_KEY, MOVE_LEFT_KEY, MOVE_RIGHT_KEY, MOVE_DOWN_KEY });
        public const Keys MOVE_DOWN_KEY = Keys.S;
        public const Keys MOVE_LEFT_KEY = Keys.A;
        public const Keys MOVE_RIGHT_KEY = Keys.D;
        public const Keys MOVE_UP_KEY = Keys.W;

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

        public const int LINK_MOVEDOWNWIDTH1 = 16;
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

        public static List<Rectangle> LINK_MOVEDOWN_FRAMES = new List<Rectangle>();
        public static Rectangle LINK_MOVEDOWN_FRAME1 = new Rectangle(LINK_MOVEDOWNX1, LINK_MOVEY, LINK_MOVEDOWNWIDTH1, LINK_MOVEHEIGHT);
        public static Rectangle LINK_MOVEDOWN_FRAME2 = new Rectangle(LINK_MOVEDOWNX2, LINK_MOVEY, LINK_MOVEDOWNWIDTH2, LINK_MOVEHEIGHT);

        public static List<Rectangle> LINK_MOVELEFT_FRAMES = new List<Rectangle>();
        public static Rectangle LINK_MOVELEFT_FRAME1 = new Rectangle(LINK_MOVELEFTX1, LINK_MOVEY, LINK_MOVESIDEWIDTH1, LINK_MOVEHEIGHT);
        public static Rectangle LINK_MOVELEFT_FRAME2 = new Rectangle(LINK_MOVELEFTX2, LINK_MOVESIDEY2, LINK_MOVESIDEWIDTH2, LINK_MOVESIDEHEIGHT2);

        public static List<Rectangle> LINK_MOVERIGHT_FRAMES = new List<Rectangle>();
        public static Rectangle LINK_MOVERIGHT_FRAME1 = new Rectangle(LINK_MOVERIGHTX1, LINK_MOVEY, LINK_MOVESIDEWIDTH1, LINK_MOVEHEIGHT);
        public static Rectangle LINK_MOVERIGHT_FRAME2 = new Rectangle(LINK_MOVERIGHTX2, LINK_MOVESIDEY2, LINK_MOVESIDEWIDTH2, LINK_MOVESIDEHEIGHT2);

        public static List<Rectangle> LINK_MOVEUP_FRAMES = new List<Rectangle>();
        public static Rectangle LINK_MOVEUP_FRAME1 = new Rectangle(LINK_MOVEUPX1, LINK_MOVEY, LINK_MOVEUPWIDTH, LINK_MOVEHEIGHT);
        public static Rectangle LINK_MOVEUP_FRAME2 = new Rectangle(LINK_MOVEUPX2, LINK_MOVEY, LINK_MOVEUPWIDTH, LINK_MOVEHEIGHT);

        public const int LINK_ATTACKDOWNWIDTH1 = 16;
        public const int LINK_ATTACKDOWNHEIGHT1 = 15;
        public const int LINK_ATTACKDOWNWIDTH2 = 16;
        public const int LINK_ATTACKDOWNHEIGHT2 = 27;
        public const int LINK_ATTACKDOWNWIDTH3 = 15;
        public const int LINK_ATTACKDOWNHEIGHT3 = 23;
        public const int LINK_ATTACKDOWNWIDTH4 = 13;
        public const int LINK_ATTACKDOWNHEIGHT4 = 19;

        public const int LINK_ATTACKSIDEWIDTH1 = 15;
        public const int LINK_ATTACKSIDEHEIGHT1 = 15;
        public const int LINK_ATTACKSIDEWIDTH2 = 27;
        public const int LINK_ATTACKSIDEHEIGHT2 = 15;
        public const int LINK_ATTACKSIDEWIDTH3 = 23;
        public const int LINK_ATTACKSIDEHEIGHT3 = 15;
        public const int LINK_ATTACKSIDEWIDTH4 = 19;
        public const int LINK_ATTACKSIDEHEIGHT4 = 16;

        public const int LINK_ATTACKUPWIDTH1 = 16;
        public const int LINK_ATTACKUPHEIGHT1 = 16;
        public const int LINK_ATTACKUPWIDTH2 = 16;
        public const int LINK_ATTACKUPHEIGHT2 = 28;
        public const int LINK_ATTACKUPWIDTH3 = 12;
        public const int LINK_ATTACKUPHEIGHT3 = 27;
        public const int LINK_ATTACKUPWIDTH4 = 12;
        public const int LINK_ATTACKUPHEIGHT4 = 19;

        public const int LINK_ATTACKX1 = 1;
        public const int LINK_ATTACKX2 = 19;
        public const int LINK_ATTACKDOWNX3 = 36;
        public const int LINK_ATTACKDOWNX4 = 54;
        public const int LINK_ATTACKDOWNY = 48;

        public const int LINK_ATTACKLEFTX1 = 726;
        public const int LINK_ATTACKLEFTX2 = 697;
        public const int LINK_ATTACKLEFTX3 = 673;
        public const int LINK_ATTACKLEFTX4 = 653;
        public const int LINK_ATTACKSIDEY = 78;
        public const int LINK_ATTACKSIDEY4 = 77;
        public const int LINK_ATTACKRIGHTX3 = 47;
        public const int LINK_ATTACKRIGHTX4 = 71;

        public const int LINK_ATTACK_UPY1 = 110;
        public const int LINK_ATTACK_UPY2 = 98;
        public const int LINK_ATTACKUPX3 = 38;
        public const int LINK_ATTACK_UPY3 = 99;
        public const int LINK_ATTACKUPX4 = 55;
        public const int LINK_ATTACK_UPY4 = 107;

        public static List<Rectangle> LINK_ATTACKDOWN_FRAMES = new List<Rectangle>();
        public static Rectangle LINK_ATTACKDOWN_FRAME1 = new Rectangle(LINK_ATTACKX1, LINK_ATTACKDOWNY, LINK_ATTACKDOWNWIDTH1, LINK_ATTACKDOWNHEIGHT1);
        public static Rectangle LINK_ATTACKDOWN_FRAME2 = new Rectangle(LINK_ATTACKX2, LINK_ATTACKDOWNY, LINK_ATTACKDOWNWIDTH2, LINK_ATTACKDOWNHEIGHT2);
        public static Rectangle LINK_ATTACKDOWN_FRAME3 = new Rectangle(LINK_ATTACKDOWNX3, LINK_ATTACKDOWNY, LINK_ATTACKDOWNWIDTH3, LINK_ATTACKDOWNHEIGHT3);
        public static Rectangle LINK_ATTACKDOWN_FRAME4 = new Rectangle(LINK_ATTACKDOWNX4, LINK_ATTACKDOWNY, LINK_ATTACKDOWNWIDTH4, LINK_ATTACKDOWNHEIGHT4);

        public static List<Rectangle> LINK_ATTACKLEFT_FRAMES = new List<Rectangle>();
        public static Rectangle LINK_ATTACKLEFT_FRAME1 = new Rectangle(LINK_ATTACKX1, LINK_ATTACKSIDEY, LINK_ATTACKSIDEWIDTH1, LINK_ATTACKSIDEHEIGHT1);
        public static Rectangle LINK_ATTACKLEFT_FRAME2 = new Rectangle(LINK_ATTACKX2, LINK_ATTACKSIDEY, LINK_ATTACKSIDEWIDTH2, LINK_ATTACKSIDEHEIGHT2);
        public static Rectangle LINK_ATTACKLEFT_FRAME3 = new Rectangle(LINK_ATTACKLEFTX3, LINK_ATTACKSIDEY, LINK_ATTACKSIDEWIDTH3, LINK_ATTACKSIDEHEIGHT3);
        public static Rectangle LINK_ATTACKLEFT_FRAME4 = new Rectangle(LINK_ATTACKLEFTX4, LINK_ATTACKSIDEY4, LINK_ATTACKSIDEWIDTH4, LINK_ATTACKSIDEHEIGHT4);

        public static List<Rectangle> LINK_ATTACKRIGHT_FRAMES = new List<Rectangle>();
        public static Rectangle LINK_ATTACKRIGHT_FRAME1 = new Rectangle(LINK_ATTACKX1, LINK_ATTACKSIDEY, LINK_ATTACKSIDEWIDTH1, LINK_ATTACKSIDEHEIGHT1);
        public static Rectangle LINK_ATTACKRIGHT_FRAME2 = new Rectangle(LINK_ATTACKX2, LINK_ATTACKSIDEY, LINK_ATTACKSIDEWIDTH2, LINK_ATTACKSIDEHEIGHT2);
        public static Rectangle LINK_ATTACKRIGHT_FRAME3 = new Rectangle(LINK_ATTACKRIGHTX3, LINK_ATTACKSIDEY, LINK_ATTACKSIDEWIDTH3, LINK_ATTACKSIDEHEIGHT3);
        public static Rectangle LINK_ATTACKRIGHT_FRAME4 = new Rectangle(LINK_ATTACKRIGHTX4, LINK_ATTACKSIDEY4, LINK_ATTACKSIDEWIDTH4, LINK_ATTACKSIDEHEIGHT4);

        public static List<Rectangle> LINK_ATTACKUP_FRAMES = new List<Rectangle>();
        public static Rectangle LINK_ATTACKUP_FRAME1 = new Rectangle(LINK_ATTACKX1, LINK_ATTACK_UPY1, LINK_ATTACKUPWIDTH1, LINK_ATTACKUPHEIGHT1);
        public static Rectangle LINK_ATTACKUP_FRAME2 = new Rectangle(LINK_ATTACKX2, LINK_ATTACK_UPY2, LINK_ATTACKUPWIDTH2, LINK_ATTACKUPHEIGHT2);
        public static Rectangle LINK_ATTACKUP_FRAME3 = new Rectangle(LINK_ATTACKUPX3, LINK_ATTACK_UPY3, LINK_ATTACKUPWIDTH3, LINK_ATTACKUPHEIGHT3);
        public static Rectangle LINK_ATTACKUP_FRAME4 = new Rectangle(LINK_ATTACKUPX4, LINK_ATTACK_UPY4, LINK_ATTACKUPWIDTH4, LINK_ATTACKUPHEIGHT4);

        public static void Initialize()
        {
            LINK_MOVEDOWN_FRAMES.Add(LINK_MOVEDOWN_FRAME1);
            LINK_MOVEDOWN_FRAMES.Add(LINK_MOVEDOWN_FRAME2);

            LINK_MOVELEFT_FRAMES.Add(LINK_MOVELEFT_FRAME1);
            LINK_MOVELEFT_FRAMES.Add(LINK_MOVELEFT_FRAME2);

            LINK_MOVERIGHT_FRAMES.Add(LINK_MOVERIGHT_FRAME1);
            LINK_MOVERIGHT_FRAMES.Add(LINK_MOVERIGHT_FRAME2);

            LINK_MOVEUP_FRAMES.Add(LINK_MOVEUP_FRAME1);
            LINK_MOVEUP_FRAMES.Add(LINK_MOVEUP_FRAME2);

            LINK_ATTACKDOWN_FRAMES.Add(LINK_ATTACKDOWN_FRAME1);
            LINK_ATTACKDOWN_FRAMES.Add(LINK_ATTACKDOWN_FRAME2);
            LINK_ATTACKDOWN_FRAMES.Add(LINK_ATTACKDOWN_FRAME3);
            LINK_ATTACKDOWN_FRAMES.Add(LINK_ATTACKDOWN_FRAME4);

            LINK_ATTACKLEFT_FRAMES.Add(LINK_ATTACKLEFT_FRAME1);
            LINK_ATTACKLEFT_FRAMES.Add(LINK_ATTACKLEFT_FRAME2);
            LINK_ATTACKLEFT_FRAMES.Add(LINK_ATTACKLEFT_FRAME3);
            LINK_ATTACKLEFT_FRAMES.Add(LINK_ATTACKLEFT_FRAME4);

            LINK_ATTACKRIGHT_FRAMES.Add(LINK_ATTACKRIGHT_FRAME1);
            LINK_ATTACKRIGHT_FRAMES.Add(LINK_ATTACKRIGHT_FRAME2);
            LINK_ATTACKRIGHT_FRAMES.Add(LINK_ATTACKRIGHT_FRAME3);
            LINK_ATTACKRIGHT_FRAMES.Add(LINK_ATTACKRIGHT_FRAME4);

            LINK_ATTACKUP_FRAMES.Add(LINK_ATTACKUP_FRAME1);
            LINK_ATTACKUP_FRAMES.Add(LINK_ATTACKUP_FRAME2);
            LINK_ATTACKUP_FRAMES.Add(LINK_ATTACKUP_FRAME3);
            LINK_ATTACKUP_FRAMES.Add(LINK_ATTACKUP_FRAME4);
        }
    }
}