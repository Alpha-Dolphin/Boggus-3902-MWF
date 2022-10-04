using CSE3902_Sprint0.Sprites;
using LOZ.Tools.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.PlayerObjects
{
    internal class Dodongo : Enemy
    {
        public static Vector2 position;

        private int health;
        private int invincibilityFrames = 0;

        private Texture2D spriteSheet = Game1.BOSSES;

        private AnimatedMovingSprite sprite;

        private Dodo_States state;

        private Dodo_Direction direction;

        private enum Dodo_States
        {
            Normal,
            Walking,
            Damaged,
            Dead
        }
       
        private enum Dodo_Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        public Dodongo()
        {
            Dodongo.position = new Vector2(0, 0);
            
            health = 2;
            direction = Dodo_Direction.Up;
        }

        public Dodongo(int xPos, int yPos)
        {
            Dodongo.position = new Vector2(xPos, yPos);
            /*
            this.health = health;
            */
            
            

     
            updateSprite();
        }

        private void updateSprite()
        {
            switch (this.state)
            {
                case Dodo_States.Normal: createStationarySprite(); break;
                case Dodo_States.Walking: createWalkingSprite(); break;
                
                case Dodo_States.Damaged: createDamagedSprite(); break;
                case Dodo_States.Dead: break;

            }
        }

        private static Rectangle DODO_MOVEUP_FRAME1 = new Rectangle(35, 58, 16, 16);
        private static Rectangle DODO_MOVEUP_FRAME2 = new Rectangle(937, 58, 16, 16);
        private static List<Rectangle> DODO_MOVEUP_FRAMES = new List<Rectangle> { DODO_MOVEUP_FRAME1, DODO_MOVEUP_FRAME2 };

        private static Rectangle DODO_MOVELEFT_FRAME1 = new Rectangle(854, 58, 16, 16);
        private static Rectangle DODO_MOVELEFT_FRAME2 = new Rectangle(887, 58, 16, 16);
        private static List<Rectangle> DODO_MOVELEFT_FRAMES = new List<Rectangle> { DODO_MOVELEFT_FRAME1, DODO_MOVELEFT_FRAME2 };

        private static Rectangle DODO_MOVERIGHT_FRAME1 = new Rectangle(69, 58, 32, 16);
        private static Rectangle DODO_MOVERIGHT_FRAME2 = new Rectangle(102, 58, 32, 16);
        private static List<Rectangle> DODO_MOVERIGHT_FRAMES = new List<Rectangle> { DODO_MOVERIGHT_FRAME1, DODO_MOVERIGHT_FRAME2 };
        

        private static Rectangle DODO_MOVEDOWN_FRAME1 = new Rectangle(1, 58, 16, 16);
        private static Rectangle DODO_MOVEDOWN_FRAME2 = new Rectangle(971, 58, 16,16);
        private static List<Rectangle> DODO_MOVEDOWN_FRAMES = new List<Rectangle> { DODO_MOVEDOWN_FRAME1, DODO_MOVEDOWN_FRAME2 };

        private static Rectangle DODO_DAMAGEDUP_FRAME1 = new Rectangle(52, 58, 16, 16);
        private static List<Rectangle> DODO_DEMAGEDUP_FRAMES = new List<Rectangle> { DODO_MOVEUP_FRAME1, DODO_DAMAGEDUP_FRAME1 };

        private static Rectangle DODO_DAMAGEDLEFT_FRAME1 = new Rectangle(821, 58, 32, 16);
        private static List<Rectangle> DODO_DEMAGEDLEFT_FRAMES = new List<Rectangle> { DODO_MOVELEFT_FRAME1, DODO_DAMAGEDLEFT_FRAME1 };

        private static Rectangle DODO_DAMAGEDRIGHT_FRAME1 = new Rectangle(135, 58, 32, 16);
        private static List<Rectangle> DODO_DEMAGEDRIGHT_FRAMES = new List<Rectangle> { DODO_MOVERIGHT_FRAME1, DODO_DAMAGEDRIGHT_FRAME1 };

        private static Rectangle DODO_DAMAGEDDOWN_FRAME1 = new Rectangle(18, 58, 16, 16);
        private static List<Rectangle> DODO_DEMAGEDDOWN_FRAMES = new List<Rectangle> { DODO_MOVEDOWN_FRAME1, DODO_DAMAGEDDOWN_FRAME1 };
        private void createStationarySprite()
        {
            Rectangle frame = new Rectangle();
            switch (this.direction)
            {
                case Dodo_Direction.Up: frame = DODO_MOVEUP_FRAME1; break;               
                case Dodo_Direction.Left: frame = DODO_MOVELEFT_FRAME1; break;
                case Dodo_Direction.Right: frame = DODO_MOVERIGHT_FRAME1; break;
                case Dodo_Direction.Down: frame = DODO_MOVEDOWN_FRAME1; break;
            }

            List<Rectangle> frames = new List<Rectangle>();
            frames.Add(frame);

            sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, frames);
        }

        private void createWalkingSprite()
        {
            List<Rectangle> frames = new List<Rectangle>();
            switch (this.direction)
            {
                case Dodo_Direction.Up: frames =DODO_MOVEUP_FRAMES; break;
                case Dodo_Direction.Left: frames = DODO_MOVELEFT_FRAMES; break;
                case Dodo_Direction.Right: frames = DODO_MOVERIGHT_FRAMES; break;
                case Dodo_Direction.Down: frames = DODO_MOVEDOWN_FRAMES; break;
            }

            sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, frames);
        }


        public void Attack(GameTime gameTime)
        {
            //Nothing
        }

        public void Die(GameTime gameTime)
        {
            if (this.health <= 0) this.state = Dodo_States.Dead;
        }
        private void createDamagedSprite()
        {
            switch (this.direction)
            {
                case Dodo_Direction.Up:
                    this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, DODO_DEMAGEDUP_FRAMES, 5) ; break;
                case Dodo_Direction.Left:
                    this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, DODO_DEMAGEDLEFT_FRAMES, 5); break;
                case Dodo_Direction.Right:
                    this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, DODO_DEMAGEDRIGHT_FRAMES, 5); break;
                case Dodo_Direction.Down:
                    this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, DODO_DEMAGEDDOWN_FRAMES, 5); break;
            }
        }

        public void Move(GameTime gameTime)
        {
            if (this.invincibilityFrames == 0)
            {
                int xDiff = 0;
                int yDiff = 0;

                switch (direction)
                {
                    case Dodo_Direction.Left: xDiff = -(int)(float)(gameTime.ElapsedGameTime.TotalMilliseconds / 25); break;
                    case Dodo_Direction.Right: xDiff = (int)(float)(gameTime.ElapsedGameTime.TotalMilliseconds / 25); break;
                    case Dodo_Direction.Down: yDiff = (int)(float)(gameTime.ElapsedGameTime.TotalMilliseconds / 25); break;
                    case Dodo_Direction.Up: yDiff = -(int)(float)(gameTime.ElapsedGameTime.TotalMilliseconds / 25); break;
                    default: xDiff = 0; yDiff = 0; break;
                }

                //Boundary check
                Dodongo.position += new Vector2(xDiff, yDiff);
            }
        }

    

        
        public void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        
        }
        public void Update(GameTime gameTime)
        {
            UpdateState(gameTime);
            UpdateVisual(gameTime);
        }

        private void UpdateState(GameTime gameTime)
        {
            if (this.invincibilityFrames == 0)
            {
                updateSprite();
            }
        }

        public void UpdateVisual(GameTime gameTime)
        {
            this.sprite.Update((int)position.X, (int)position.Y);
           
            if (this.invincibilityFrames > 0) this.invincibilityFrames--;

            
        }

        private Dodo_Direction getDirection()
        {
            return this.direction;
        }
    }
}

