using CSE3902_Sprint0.Sprites;
using Microsoft.Xna.Framework;
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
        private Vector2 position;

        private string[] items;
        private string currentItem;

        private List<IProjectile> projectiles;

        private int health;
        private TextSprite healthText;

        private Texture2D spriteSheet;
        private AnimatedMovingSprite sprite;

        private Link_Constants.Link_States state;

        private Link_Constants.Direction direction;

        public Link()
        {
            this.position = new Vector2(0, 0);
            items = new string[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7", "Item 8", "Item 9", "Item 0" };
            currentItem = items[0];
            health = Link_Constants.MAX_HEALTH;
            direction = Link_Constants.Direction.Up;
        }

        public Link(int xPos, int yPos, string[] items, int health, Link_Constants.Link_States state, Link_Constants.Direction direction, Texture2D picture, SpriteFont font)
        {
            this.position = new Vector2(xPos, yPos);
            this.items = items;
            currentItem = items[0];
            this.projectiles = new List<IProjectile>();
            this.health = health;
            this.healthText = new TextSprite();
            this.state = state;
            this.direction = direction;

            this.healthText.setFont(font);
            this.healthText.setPosition(0, 0);
            this.spriteSheet = picture;
            updateSprite();
        }

        private void updateSprite()
        {
            switch (this.state)
            {
                case Link_Constants.Link_States.Normal: createStationarySprite(); break;
                case Link_Constants.Link_States.Walking: createWalkingSprite(); break;
                case Link_Constants.Link_States.Attacking: createAttackingSprite(); break;
                case Link_Constants.Link_States.Dead: break;

            }
        }

        private void createStationarySprite()
        {
            Rectangle frame = new Rectangle();
            switch (this.direction)
            {
                case Link_Constants.Direction.Up: frame = Link_Constants.LINK_MOVEUP_FRAME1; break;
                case Link_Constants.Direction.Left: frame = Link_Constants.LINK_MOVELEFT_FRAME1; break;
                case Link_Constants.Direction.Right: frame = Link_Constants.LINK_MOVERIGHT_FRAME1; break;
                case Link_Constants.Direction.Down: frame = Link_Constants.LINK_MOVEDOWN_FRAME1; break;
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
                case Link_Constants.Direction.Up: frames = Link_Constants.LINK_MOVEUP_FRAMES; break;
                case Link_Constants.Direction.Left: frames = Link_Constants.LINK_MOVELEFT_FRAMES; break;
                case Link_Constants.Direction.Right: frames = Link_Constants.LINK_MOVERIGHT_FRAMES; break;
                case Link_Constants.Direction.Down: frames = Link_Constants.LINK_MOVEDOWN_FRAMES; break;
            }

            sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, frames);
        }
        private void createAttackingSprite()
        {
            switch (this.direction)
            {
                case Link_Constants.Direction.Up: this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, 
                    Link_Constants.LINK_SWORD_ATTACKUP_FRAMES, Link_Constants.LINK_SWORD_ATTACKUP_LOCATIONSHIFT); break;
                case Link_Constants.Direction.Left: this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, 
                    Link_Constants.LINK_SWORD_ATTACKLEFT_FRAMES, Link_Constants.LINK_SWORD_ATTACKLEFT_LOCATIONSHIFT); break;
                case Link_Constants.Direction.Right: this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, 
                    Link_Constants.LINK_SWORD_ATTACKRIGHT_FRAMES); break;
                case Link_Constants.Direction.Down: this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, 
                    Link_Constants.LINK_SWORD_ATTACKDOWN_FRAMES); break;
            }
        }

        public void Move(Link_Constants.Direction direction)
        {
            int xDiff = 0;
            int yDiff = 0;

            switch (direction)
            {
                case Link_Constants.Direction.Left: xDiff = -1; break;
                case Link_Constants.Direction.Right: xDiff = 1; break;
                case Link_Constants.Direction.Down: yDiff = 1; break;
                case Link_Constants.Direction.Up: yDiff = -1; break;
                default: xDiff = 0; yDiff = 0; break;
            }

            //Boundary check
            this.position += new Vector2(xDiff, yDiff);
        }

        public void Attack()
        {
            if (health == Link_Constants.MAX_HEALTH) CreateProjectile(new Swordbeam());
        }

        public void ChangeItem(int input)
        {
            switch (input)
            {
                case 1: break;
                case 2: UpdateState(Link_Constants.Link_States.UseItem, this.direction);  CreateProjectile(new ArrowProjectile()); break;
                default: break;
            }
        }

        public void Damage()
        {
            this.health -= 1;

            if (this.health <= 0) this.state = Link_Constants.Link_States.Dead;
        }

        private void CreateProjectile(IProjectile projectileType)
        {
            bool containsProjectile = false;
            foreach(IProjectile projectile in projectiles)
            {
                if (projectile.GetProjectileType().Equals(projectileType.GetProjectileType()))
                {
                    containsProjectile = true; 
                    break;
                }
            }

            if (!containsProjectile)
            {
                Vector2 velocity = new Vector2(0, 0);
                switch (this.direction)
                {
                    case Link_Constants.Direction.Up: velocity = new Vector2(0, -1); break;
                    case Link_Constants.Direction.Left: velocity = new Vector2(-1, 0); break;
                    case Link_Constants.Direction.Right: velocity = new Vector2(1, 0); break;
                    case Link_Constants.Direction.Down: velocity = new Vector2(0, 1); break;
                }

                switch (projectileType.GetProjectileType()) {
                    case Link_Constants.Link_Projectiles.SwordBeam: this.projectiles.Add(
                        new Swordbeam(this.spriteSheet, position, Link_Constants.PROJECTILE_VELOCITY * velocity)); break;
                    case Link_Constants.Link_Projectiles.Arrow: this.projectiles.Add(
                        new ArrowProjectile(this.spriteSheet, position, Link_Constants.PROJECTILE_VELOCITY * velocity)); break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
            this.healthText.Draw(spriteBatch);

            foreach (IProjectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }

        public void UpdateState(Link_Constants.Link_States state, Link_Constants.Direction direction)
        {
            if (this.sprite.finished() || this.state != Link_Constants.Link_States.Attacking)
            {
                if (!(this.state == state) || !(this.direction == direction))
                {
                    this.state = state;
                    this.direction = direction;
                    updateSprite();
                }
            }
        }

        public void UpdateVisual()
        {
            this.sprite.Update((int)position.X, (int)position.Y);
            this.healthText.setText(health + "");

            for (int i = 0; i < projectiles.Count; i++)
            {
                if (!projectiles[i].stillExists())
                {
                    projectiles.RemoveAt(i);
                    i--;
                }
                else projectiles[i].Update();
            }
        }

        public Link_Constants.Direction getDirection()
        {
            return this.direction;
        }
    }
}
