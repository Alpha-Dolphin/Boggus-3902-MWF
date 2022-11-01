using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.PlayerObjects
{
    internal class Boomerang : IProjectile
    {
        private Vector2 position;
        private Vector2 velocity;
        private AnimatedMovingSprite sprite;
        private bool movingAway = true;

        private bool exists = true;

        public Boomerang() { }
        public Boomerang(Texture2D spriteSheet, Vector2 position, Vector2 velocity)
        {
            this.position = position;
            this.velocity = velocity;

            CreateSprite(spriteSheet);
        }

        private void CreateSprite(Texture2D spriteSheet)
        {
            if (velocity.X == 0)
            {
                if (velocity.Y < 0)
                {
                    sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                        PlayerConstants.BOOMERANG_WOOD_FRAMES, PlayerConstants.SWORDBEAM_UP_LOCATIONSHIFT);
                }
                else sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                    PlayerConstants.BOOMERANG_WOOD_FRAMES, PlayerConstants.SWORDBEAM_DOWN_LOCATIONSHIFT);
            }
            else
            {
                if (velocity.X < 0)
                {
                    sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                        PlayerConstants.BOOMERANG_WOOD_FRAMES, PlayerConstants.SWORDBEAM_LEFT_LOCATIONSHIFT);
                }
                else sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                    PlayerConstants.BOOMERANG_WOOD_FRAMES, PlayerConstants.SWORDBEAM_RIGHT_LOCATIONSHIFT);
            }
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public Vector2 Update()
        {
            if(CloseEnough() && !movingAway)
            {
                this.Destroy();
            }
            this.position += velocity;

            this.sprite.Update((int)position.X, (int)position.Y);

            UpdateVelocity();

            return this.position;
        }

        private void UpdateVelocity()
        {
            if (this.movingAway)
            {
                if (this.velocity.X <= PlayerConstants.BOOMERANG_SPEEDCHANGE && this.velocity.X >= -PlayerConstants.BOOMERANG_SPEEDCHANGE)
                {
                    if (this.velocity.Y >= 0.1) this.velocity.Y -= PlayerConstants.BOOMERANG_SPEEDCHANGE;
                    else if (this.velocity.Y <= -0.1) this.velocity.Y += PlayerConstants.BOOMERANG_SPEEDCHANGE;
                    else this.movingAway = false;
                }
                else
                {
                    if (this.velocity.X >= 0) this.velocity.X -= PlayerConstants.BOOMERANG_SPEEDCHANGE;
                    else this.velocity.X += PlayerConstants.BOOMERANG_SPEEDCHANGE;
                }
            } else
            {
                MoveToLink();
            }
        }

        private void MoveToLink()
        {
            this.velocity += (Link.position - this.position) / PlayerConstants.BOOMERANG_RETURNSPEEDCHANGE;
        }

        private bool CloseEnough()
        {
            Vector2 centerOfLink = new Vector2(Link.position.X + PlayerConstants.LINK_MOVEDOWN_FRAME1.Width / 2, Link.position.Y + PlayerConstants.LINK_MOVEDOWN_FRAME1.Height / 2);
            Vector2 howFar = (centerOfLink - this.position);
            return howFar.Length() <= PlayerConstants.BOOMERANG_RETURNRANGE;
        }

        public PlayerConstants.Link_Projectiles GetProjectileType()
        {
            return PlayerConstants.Link_Projectiles.Boomerang;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        private void Split()
        {
            //Once the swordbeam reaches the end or hits something, split
            this.Destroy();
        }

        public void Destroy()
        {
            this.exists = false;
        }

        public bool stillExists()
        {
            return exists;
        }
        public List<Rectangle> GetHitboxes()
        {
            return new List<Rectangle>() { this.sprite.GetDestinationRectangle() };
        }
    }
}
