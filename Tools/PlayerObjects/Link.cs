using CSE3902_Sprint0.Sprites;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.PlayerObjects
{
    internal class Link : IPlayer
    {
        private int xPos;
        private int yPos;

        private string[] items;
        private string currentItem;

        private int health;

        private Texture2D spriteSheet;
        private ISprite sprite;

        private Link_Constants.Link_States state;

        private Link_Constants.Direction direction;

        public Link()
        {
            this.xPos = 0;
            this.yPos = 0;
            items = new string[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7", "Item 8", "Item 9", "Item 0" };
            currentItem = items[0];
            health = Link_Constants.MAX_HEALTH;
            direction = Link_Constants.Direction.Up;
        }

        public Link(int xPos, int yPos, string[] items, int health, Link_Constants.Link_States state, Link_Constants.Direction direction, Texture2D picture)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.items = items;
            currentItem = items[0];
            this.health = health;
            this.state = state;
            this.direction = direction;

            this.spriteSheet = picture;
            updateSprite();
        }

        private void updateSprite()
        {
            switch (this.state)
            {
                case Link_Constants.Link_States.Normal: sprite = new Sprite(this.spriteSheet, this.xPos, this.yPos, Link_Constants.LINK_MOVEDOWN_FRAMES); break;
                case Link_Constants.Link_States.Walking: createWalkingSprite(); break;
                case Link_Constants.Link_States.Attacking: sprite = new Sprite(this.spriteSheet, this.xPos, this.yPos, Link_Constants.LINK_MOVEDOWN_FRAMES); break;
                case Link_Constants.Link_States.Dead: sprite = new Sprite(this.spriteSheet, this.xPos, this.yPos, Link_Constants.LINK_MOVEDOWN_FRAMES); break;

            }
        }

        private void createWalkingSprite()
        {
            switch (this.direction)
            {
                case Link_Constants.Direction.Down: sprite = new AnimatedMovingSprite(this.spriteSheet, this.xPos, this.yPos, Link_Constants.LINK_MOVEDOWN_FRAMES); break;
                case Link_Constants.Direction.Left: sprite = new AnimatedMovingSprite(this.spriteSheet, this.xPos, this.yPos, Link_Constants.LINK_MOVELEFT_FRAMES); break;
                case Link_Constants.Direction.Right: sprite = new AnimatedMovingSprite(this.spriteSheet, this.xPos, this.yPos, Link_Constants.LINK_MOVERIGHT_FRAMES); break;
                case Link_Constants.Direction.Up: sprite = new AnimatedMovingSprite(this.spriteSheet, this.xPos, this.yPos, Link_Constants.LINK_MOVEUP_FRAMES); break;
            }
        }

        public void Move(Link_Constants.Direction direction)
        {
            int xDiff = 0;
            int yDiff = 0;

            this.direction = direction;
            this.state = Link_Constants.Link_States.Walking;

            createWalkingSprite();

            switch (direction)
            {
                case Link_Constants.Direction.Left: xDiff = -1; break;
                case Link_Constants.Direction.Right: xDiff = 1; break;
                case Link_Constants.Direction.Down: yDiff = 1; break;
                case Link_Constants.Direction.Up: yDiff = -1; break;
                default: xDiff = 0; yDiff = 0; break;
            }

            //Boundary check
            this.xPos += xDiff;
            this.yPos += yDiff;

            this.sprite.Update(xPos, yPos);
        }

        public void Attack()
        {
            this.state = Link_Constants.Link_States.Attacking;
            if (health == Link_Constants.MAX_HEALTH) CreateSwordBeam();
        }

        public void ChangeItem(int input)
        {
            currentItem = items[input];
        }

        public void Damage()
        {
            this.health -= 1;

            if (this.health <= 0) this.state = Link_Constants.Link_States.Dead;
        }

        private void CreateSwordBeam()
        {
            //Create the beam
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }
    }
}
