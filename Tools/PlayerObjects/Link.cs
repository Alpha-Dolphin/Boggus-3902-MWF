using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework.Input;
using LOZ.Tools.LevelManager;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Audio;

namespace LOZ.Tools.PlayerObjects
{
    public class Link : IPlayer, ICollidable
    {
        public static Vector2 position;

        public LinkInventory inventory;

        private PlayerConstants.Link_Projectiles currentSpecialWeapon;
        private List<IProjectile> projectiles;
        private ProjectileFactory projectileFactory;

        private Rectangle hurtbox;
        private Rectangle? swordHitbox;
        private List<Rectangle> hitboxes;

        private int health;
        private int hearts;
        private int invincibilityFrames = 0;

        private Texture2D spriteSheet = Game1.LINK_SPRITESHEET;
        private AnimatedMovingSprite sprite;

        private PlayerConstants.Link_States state;
        private PlayerConstants.Direction direction;

        private List<SoundEffect> soundEffectList = Game1.soundEffectList;

        public Link()
        {
            Link.position = new Vector2(0, 0);
            health = PlayerConstants.MAX_HEALTH;
            direction = PlayerConstants.Direction.Up;
        }

        public Link(int xPos, int yPos, int health, PlayerConstants.Link_States state, PlayerConstants.Direction direction)
        {
            Link.position = new Vector2(xPos, yPos);

            inventory = new LinkInventory();

            this.currentSpecialWeapon = PlayerConstants.Link_Projectiles.None;
            this.projectiles = new List<IProjectile>();
            this.health = health;
            this.hearts = health / 2 + hearts % 2;
            this.state = state;
            this.direction = direction;
            this.hitboxes = new List<Rectangle>();
            this.hurtbox = new Rectangle(xPos, yPos, PlayerConstants.LINK_MOVEDOWN_FRAME1.Width, PlayerConstants.LINK_MOVEDOWN_FRAME1.Height);

            this.projectileFactory = new ProjectileFactory(PlayerConstants.Link_Projectiles.BlueArrow, this.spriteSheet);
            UpdateSprite();
            this.swordHitbox = null;
        }

        private void UpdateSprite()
        {
            switch (this.state)
            {
                case PlayerConstants.Link_States.Normal: CreateStationarySprite(); break;
                case PlayerConstants.Link_States.Walking: CreateWalkingSprite(); break;
                case PlayerConstants.Link_States.Attacking: CreateAttackingSprite(); break;
                case PlayerConstants.Link_States.Damaged: CreateDamagedSprite(); break;
                case PlayerConstants.Link_States.Dead: break;

            }
        }

        private void CreateStationarySprite()
        {
            Rectangle frame = new Rectangle();
            switch (this.direction)
            {
                case PlayerConstants.Direction.Up: frame = PlayerConstants.LINK_MOVEUP_FRAME1; break;
                case PlayerConstants.Direction.Left: frame = PlayerConstants.LINK_MOVELEFT_FRAME1; break;
                case PlayerConstants.Direction.Right: frame = PlayerConstants.LINK_MOVERIGHT_FRAME1; break;
                case PlayerConstants.Direction.Down: frame = PlayerConstants.LINK_MOVEDOWN_FRAME1; break;
            }

            List<Rectangle> frames = new List<Rectangle>();
            frames.Add(frame);

            sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, frames);
        }

        private void CreateWalkingSprite()
        {
            List<Rectangle> frames = new List<Rectangle>();
            switch (this.direction)
            {
                case PlayerConstants.Direction.Up: frames = PlayerConstants.LINK_MOVEUP_FRAMES; break;
                case PlayerConstants.Direction.Left: frames = PlayerConstants.LINK_MOVELEFT_FRAMES; break;
                case PlayerConstants.Direction.Right: frames = PlayerConstants.LINK_MOVERIGHT_FRAMES; break;
                case PlayerConstants.Direction.Down: frames = PlayerConstants.LINK_MOVEDOWN_FRAMES; break;
            }

            sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, frames);
        }
        private void CreateAttackingSprite()
        {
            switch (this.direction)
            {
                case PlayerConstants.Direction.Up: this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, 
                    PlayerConstants.LINK_SWORD_ATTACKUP_FRAMES, PlayerConstants.LINK_SWORD_ATTACKUP_LOCATIONSHIFT, PlayerConstants.DEFAULT_FRAMERATE); break;
                case PlayerConstants.Direction.Left: this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, 
                    PlayerConstants.LINK_SWORD_ATTACKLEFT_FRAMES, PlayerConstants.LINK_SWORD_ATTACKLEFT_LOCATIONSHIFT, PlayerConstants.DEFAULT_FRAMERATE); break;
                case PlayerConstants.Direction.Right: this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, 
                    PlayerConstants.LINK_SWORD_ATTACKRIGHT_FRAMES); break;
                case PlayerConstants.Direction.Down: this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, 
                    PlayerConstants.LINK_SWORD_ATTACKDOWN_FRAMES); break;
            }
        }

        private void CreateDamagedSprite()
        {
            this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y, PlayerConstants.DAMAGED, PlayerConstants.DAMAGED_FRAMERATE);
        }

        public void Move(PlayerConstants.Direction direction)
        {
            int xDiff = 0;
            int yDiff = 0;

            switch (direction)
            {
                case PlayerConstants.Direction.Left: xDiff = -1; break;
                case PlayerConstants.Direction.Right: xDiff = 1; break;
                case PlayerConstants.Direction.Down: yDiff = 1; break;
                case PlayerConstants.Direction.Up: yDiff = -1; break;
                default: xDiff = 0; yDiff = 0; break;
            }

            //Boundary check
            Link.position += new Vector2(xDiff, yDiff);
        }

        public void Attack()
        {
            if (this.health == PlayerConstants.HEATH_PER_HEART*this.hearts) CreateProjectile(PlayerConstants.Link_Projectiles.SwordBeam);
        }

        public void UpdateSpecialWeapon(PlayerConstants.Link_Projectiles specialWeapon)
        {
            this.currentSpecialWeapon = specialWeapon;
        }

        public void SpecialAttack()
        {
            if (currentSpecialWeapon != PlayerConstants.Link_Projectiles.None)
            {
                UpdateState(PlayerConstants.Link_States.UseItem, this.direction);
                if (currentSpecialWeapon == PlayerConstants.Link_Projectiles.Potion)
                {
                    AddHealth(true);
                }
                else CreateProjectile(currentSpecialWeapon);
            }
        }

        public void UseItem(int input)
        {
            switch (input)
            {
                case 1: UpdateState(PlayerConstants.Link_States.UseItem, this.direction); CreateProjectile(PlayerConstants.Link_Projectiles.BlueArrow); break;
                case 2: UpdateState(PlayerConstants.Link_States.UseItem, this.direction);  CreateProjectile(PlayerConstants.Link_Projectiles.WoodArrow); break;
                case 3: UpdateState(PlayerConstants.Link_States.UseItem, this.direction);  CreateProjectile(PlayerConstants.Link_Projectiles.Boomerang); break;
                case 4: UpdateState(PlayerConstants.Link_States.UseItem, this.direction); CreateProjectile(PlayerConstants.Link_Projectiles.CandleFlame); break;
                case 5: UpdateState(PlayerConstants.Link_States.UseItem, this.direction); CreateProjectile(PlayerConstants.Link_Projectiles.Bomb); break;
                default: break;
            }
        }

        public void Damage()
        {
            if (this.invincibilityFrames == 0)
            {
                soundEffectList[(int)SoundEffects.LinkHurt].Play();
                this.health -= 1;
                this.invincibilityFrames = PlayerConstants.INVINCIBILITY_FRAMES;
                if (this.health <= 0)
                {
                    this.state = PlayerConstants.Link_States.Dead;
                    soundEffectList[(int)SoundEffects.LinkDie].Play();
                }
            }
        }

        private void CreateProjectile(PlayerConstants.Link_Projectiles projectileType)
        {
            bool containsProjectile = false;
            foreach(IProjectile projectile in projectiles)
            {
                if (projectile.GetProjectileType().Equals(projectileType))
                {
                    if (projectile.GetProjectileType().Equals(PlayerConstants.Link_Projectiles.Bomb)) projectile.Destroy();
                    containsProjectile = true; 
                    break;
                }
            }

            if (!containsProjectile)
            {
                bool projectileAvailable = true;
                if (projectileType == PlayerConstants.Link_Projectiles.Bomb)
                {
                    if (inventory.bombs > 0)
                    {
                        inventory.bombs--;
                    } else
                    {
                        projectileAvailable = false;
                    }
                }

                if (projectileAvailable)
                {
                    Vector2 velocity = new Vector2(0, 0);
                    switch (this.direction)
                    {
                        case PlayerConstants.Direction.Up: velocity = new Vector2(0, -1); break;
                        case PlayerConstants.Direction.Left: velocity = new Vector2(-1, 0); break;
                        case PlayerConstants.Direction.Right: velocity = new Vector2(1, 0); break;
                        case PlayerConstants.Direction.Down: velocity = new Vector2(0, 1); break;
                    }

                    this.projectileFactory.Update(projectileType);
                    this.projectiles.Add(this.projectileFactory.CreateProjectile(velocity, this));
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);

            foreach (IProjectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }

            UpdateHitboxes();
        }

        public void UpdateState(PlayerConstants.Link_States state, PlayerConstants.Direction direction)
        {
            if (this.invincibilityFrames == 0)
            {
                if (state == PlayerConstants.Link_States.Damaged || this.sprite.Finished() || this.state != PlayerConstants.Link_States.Attacking)
                {
                    if (!(this.state == state) || !(this.direction == direction))
                    {
                        this.state = state;
                        this.direction = direction;
                        UpdateSprite();
                    }
                }
            }
        }

        public void UpdateVisual()
        {
            this.sprite.Update((int)position.X, (int)position.Y);
            if (this.invincibilityFrames > 0)
                this.invincibilityFrames--;

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

        public int GetHealth()
        {
            return this.health;
        }

        public void AddHealth(bool fairy)
        {
            if (fairy) this.health += PlayerConstants.FAIRY_HEALING;
            else this.health += PlayerConstants.HEART_HEALING;

            if (this.health > (this.hearts * 2)) this.health = this.hearts * 2;
        }

        public int GetHearts() { 
            return this.hearts;
        }

        public void AddHeart()
        {
            this.hearts++;
            soundEffectList[(int)SoundEffects.GetHeart].Play();
            AddHealth(false);
        }

        private void UpdateHitboxes()
        {
            this.hitboxes = new List<Rectangle>();
            
            foreach (IProjectile projectile in projectiles)
            {
                List<Rectangle> temp = projectile.GetHitboxes();

                foreach(Rectangle rect in temp)
                {
                    this.hitboxes.Add(rect);
                }
            }

            if(this.state == PlayerConstants.Link_States.Attacking)
            {
                UpdateSwordHitbox();
                if (this.swordHitbox != null)
                {
                    this.hitboxes.Add(new Rectangle(this.swordHitbox.Value.X + this.sprite.GetX(), 
                        this.swordHitbox.Value.Y + this.sprite.GetY(), 
                        this.swordHitbox.Value.Width, this.swordHitbox.Value.Height));
                }
            }

            UpdateHurtbox();
        }

        private void UpdateHurtbox()
        {
            switch (this.state)
            {
                case PlayerConstants.Link_States.Attacking: UpdateAttackingHurtbox(); break;
                default: this.hurtbox = this.sprite.GetDestinationRectangle(); break;
            }
        }

        private void UpdateAttackingHurtbox()
        {
            int currentFrame = this.sprite.GetFrame() / sprite.frameRate;
            Rectangle spriteRect = this.sprite.GetDestinationRectangle();
            if (currentFrame == 0)
            {
                this.hurtbox = spriteRect;
            }
            else
            {
                switch (this.direction)
                {
                    case PlayerConstants.Direction.Up:
                        Rectangle tempUp = PlayerConstants.SWORD_ATTACKUP_HITBOX_FRAMES[currentFrame].Value;
                        this.hurtbox = new Rectangle(spriteRect.X, spriteRect.Y - tempUp.Height, spriteRect.Width, spriteRect.Height - tempUp.Height);
                        break;
                    case PlayerConstants.Direction.Left:
                        Rectangle tempLeft = PlayerConstants.SWORD_ATTACKLEFT_HITBOX_FRAMES[currentFrame].Value;
                        this.hurtbox = new Rectangle(spriteRect.X + tempLeft.Width, spriteRect.Y, spriteRect.Width - tempLeft.Width, spriteRect.Height);
                        break;
                    case PlayerConstants.Direction.Right:
                        Rectangle tempRight = PlayerConstants.SWORD_ATTACKRIGHT_HITBOX_FRAMES[currentFrame].Value;
                        this.hurtbox = new Rectangle(spriteRect.X, spriteRect.Y, spriteRect.Width - tempRight.Width, spriteRect.Height);
                        break;
                    case PlayerConstants.Direction.Down:
                        Rectangle tempDown = PlayerConstants.SWORD_ATTACKDOWN_HITBOX_FRAMES[currentFrame].Value;
                        this.hurtbox = new Rectangle(spriteRect.X, spriteRect.Y, spriteRect.Width, spriteRect.Height - tempDown.Height);
                        break;
                }
            }
        }

        private void UpdateSwordHitbox()
        {
            int currentFrame = this.sprite.GetFrame()/sprite.frameRate;
            switch (this.direction)
            {
                case PlayerConstants.Direction.Up: 
                    this.swordHitbox = PlayerConstants.SWORD_ATTACKUP_HITBOX_FRAMES[currentFrame]; break;
                case PlayerConstants.Direction.Left:
                    this.swordHitbox = PlayerConstants.SWORD_ATTACKLEFT_HITBOX_FRAMES[currentFrame]; break;
                case PlayerConstants.Direction.Right:
                    this.swordHitbox = PlayerConstants.SWORD_ATTACKRIGHT_HITBOX_FRAMES[currentFrame]; break;
                case PlayerConstants.Direction.Down:
                    this.swordHitbox = PlayerConstants.SWORD_ATTACKDOWN_HITBOX_FRAMES[currentFrame]; break;
            }
        }

        public void SetHurtbox(Rectangle rect)
        {
            Link.position = new Vector2(rect.X, rect.Y);
        }

        public Rectangle GetHurtbox()
        {
            return this.hurtbox;
        }

        public PlayerConstants.Direction GetDirection()
        {
            return this.direction;
        }
        public List<ICollidable> GetHitboxes()
        {
            List<ICollidable> list = new();
            foreach (Rectangle c in this.hitboxes) {
                Weapon temp = new();
                temp.SetHurtbox(c);
                list.Add(temp);
            }
            return list;
        }
        public void Teleport(int xPos,int yPos)
        {
            position.X = xPos;
            position.Y = yPos;
        }
    }
}