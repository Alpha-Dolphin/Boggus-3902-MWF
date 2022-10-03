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
        public static Vector2 position;

        private string[] items;
        private string currentItem;

        private List<IProjectile> projectiles;
        private ProjectileFactory projectileFactory;

        private int health;
        private int invincibilityFrames = 0;
        private TextSprite healthText;

        private Texture2D spriteSheet;
        private AnimatedMovingSprite sprite;

        private LinkConstants.Link_States state;

        private LinkConstants.Direction direction;

        public Link()
        {
            Link.position = new Vector2(0, 0);
            items = new string[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7", "Item 8", "Item 9", "Item 0" };
            currentItem = items[0];
            health = LinkConstants.MAX_HEALTH;
            direction = LinkConstants.Direction.Up;
        }

        public Link(int xPos, int yPos, string[] items, int health, LinkConstants.Link_States state, LinkConstants.Direction direction, Texture2D picture, SpriteFont font)
        {
            Link.position = new Vector2(xPos, yPos);
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
            this.projectileFactory = new ProjectileFactory(0, this.spriteSheet);
            updateSprite();
        }

        private void updateSprite()
        {
            switch (this.state)
            {
                case LinkConstants.Link_States.Normal: createStationarySprite(); break;
                case LinkConstants.Link_States.Walking: createWalkingSprite(); break;
                case LinkConstants.Link_States.Attacking: createAttackingSprite(); break;
                case LinkConstants.Link_States.Damaged: createDamagedSprite(); break;
                case LinkConstants.Link_States.Dead: break;

            }
        }

        private void createStationarySprite()
        {
            Rectangle frame = new Rectangle();
            switch (this.direction)
            {
                case LinkConstants.Direction.Up: frame = LinkConstants.LINK_MOVEUP_FRAME1; break;
                case LinkConstants.Direction.Left: frame = LinkConstants.LINK_MOVELEFT_FRAME1; break;
                case LinkConstants.Direction.Right: frame = LinkConstants.LINK_MOVERIGHT_FRAME1; break;
                case LinkConstants.Direction.Down: frame = LinkConstants.LINK_MOVEDOWN_FRAME1; break;
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
                case LinkConstants.Direction.Up: frames = LinkConstants.LINK_MOVEUP_FRAMES; break;
                case LinkConstants.Direction.Left: frames = LinkConstants.LINK_MOVELEFT_FRAMES; break;
                case LinkConstants.Direction.Right: frames = LinkConstants.LINK_MOVERIGHT_FRAMES; break;
                case LinkConstants.Direction.Down: frames = LinkConstants.LINK_MOVEDOWN_FRAMES; break;
            }

            sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, frames);
        }
        private void createAttackingSprite()
        {
            switch (this.direction)
            {
                case LinkConstants.Direction.Up: this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, 
                    LinkConstants.LINK_SWORD_ATTACKUP_FRAMES, LinkConstants.LINK_SWORD_ATTACKUP_LOCATIONSHIFT, LinkConstants.DEFAULT_FRAMERATE); break;
                case LinkConstants.Direction.Left: this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, 
                    LinkConstants.LINK_SWORD_ATTACKLEFT_FRAMES, LinkConstants.LINK_SWORD_ATTACKLEFT_LOCATIONSHIFT, LinkConstants.DEFAULT_FRAMERATE); break;
                case LinkConstants.Direction.Right: this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, 
                    LinkConstants.LINK_SWORD_ATTACKRIGHT_FRAMES); break;
                case LinkConstants.Direction.Down: this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, 
                    LinkConstants.LINK_SWORD_ATTACKDOWN_FRAMES); break;
            }
        }

        private void createDamagedSprite()
        {
            this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, LinkConstants.DAMAGED, LinkConstants.DAMAGED_FRAMERATE);
        }

        public void Move(LinkConstants.Direction direction)
        {
            if (this.invincibilityFrames == 0)
            {
                int xDiff = 0;
                int yDiff = 0;

                switch (direction)
                {
                    case LinkConstants.Direction.Left: xDiff = -1; break;
                    case LinkConstants.Direction.Right: xDiff = 1; break;
                    case LinkConstants.Direction.Down: yDiff = 1; break;
                    case LinkConstants.Direction.Up: yDiff = -1; break;
                    default: xDiff = 0; yDiff = 0; break;
                }

                //Boundary check
                Link.position += new Vector2(xDiff, yDiff);
            }
        }

        public void Attack()
        {
            if (health == LinkConstants.MAX_HEALTH) CreateProjectile(new Swordbeam());
        }

        public void UseItem(int input)
        {
            switch (input)
            {
                case 1: break;
                case 2: UpdateState(LinkConstants.Link_States.UseItem, this.direction);  CreateProjectile(new ArrowProjectile()); break;
                case 3: UpdateState(LinkConstants.Link_States.UseItem, this.direction);  CreateProjectile(new Boomerang()); break;
                case 4: UpdateState(LinkConstants.Link_States.UseItem, this.direction); CreateProjectile(new CandleFlame()); break;
                case 5: UpdateState(LinkConstants.Link_States.UseItem, this.direction); CreateProjectile(new Bomb()); break;
                default: break;
            }
        }

        public void Damage()
        {
            if (this.invincibilityFrames == 0)
            {
                this.health -= 1;
                this.invincibilityFrames = LinkConstants.INVINCIBILITY_FRAMES;
                if (this.health <= 0) this.state = LinkConstants.Link_States.Dead;
            }
        }

        private void CreateProjectile(IProjectile projectileType)
        {
            bool containsProjectile = false;
            foreach(IProjectile projectile in projectiles)
            {
                if (projectile.GetProjectileType().Equals(projectileType.GetProjectileType()))
                {
                    if (projectile.GetProjectileType().Equals(LinkConstants.Link_Projectiles.Bomb)) projectile.Destroy();
                    containsProjectile = true; 
                    break;
                }
            }

            if (!containsProjectile)
            {
                Vector2 velocity = new Vector2(0, 0);
                switch (this.direction)
                {
                    case LinkConstants.Direction.Up: velocity = new Vector2(0, -1); break;
                    case LinkConstants.Direction.Left: velocity = new Vector2(-1, 0); break;
                    case LinkConstants.Direction.Right: velocity = new Vector2(1, 0); break;
                    case LinkConstants.Direction.Down: velocity = new Vector2(0, 1); break;
                }

                this.projectileFactory.Update(projectileType.GetProjectileType());
                this.projectiles.Add(this.projectileFactory.CreateProjectile(velocity));
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

        public void UpdateState(LinkConstants.Link_States state, LinkConstants.Direction direction)
        {
            if (this.invincibilityFrames == 0)
            {
                if (state == LinkConstants.Link_States.Damaged || this.sprite.finished() || this.state != LinkConstants.Link_States.Attacking)
                {
                    if (!(this.state == state) || !(this.direction == direction))
                    {
                        this.state = state;
                        this.direction = direction;
                        updateSprite();
                    }
                }
            }
        }

        public void UpdateVisual()
        {
            this.sprite.Update((int)position.X, (int)position.Y);
            this.healthText.setText(health + "");
            if (this.invincibilityFrames > 0) this.invincibilityFrames--;

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

        public LinkConstants.Direction getDirection()
        {
            return this.direction;
        }
    }
}
