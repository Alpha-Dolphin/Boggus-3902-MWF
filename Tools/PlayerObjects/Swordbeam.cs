using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using LOZ.Tools.Sprites;

namespace LOZ.Tools.PlayerObjects
{
    internal class Swordbeam : IProjectile
    {
        private Vector2 originalPosition;
        private Vector2 position;
        private Vector2 velocity;
        private AnimatedMovingSprite sprite;

        private bool exists = true;

        public Swordbeam() { }
        public Swordbeam(Texture2D spriteSheet, Vector2 position, Vector2 velocity)
        {
            this.originalPosition = position;
            this.position = position;
            this.velocity = velocity;

            CreateSprite(spriteSheet);
        }

        private void CreateSprite(Texture2D spriteSheet)
        {
            if(velocity.X == 0)
            {
                if (velocity.Y < 0)
                {
                    sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y, 
                        LinkConstants.SWORDBEAM_UP_FRAMES, LinkConstants.SWORDBEAM_UP_LOCATIONSHIFT);
                }
                else sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y, 
                    LinkConstants.SWORDBEAM_DOWN_FRAMES, LinkConstants.SWORDBEAM_DOWN_LOCATIONSHIFT);
            } else
            {
                if(velocity.X < 0)
                {
                    sprite = new AnimatedMovingSprite(spriteSheet, (int) position.X, (int) position.Y, 
                        LinkConstants.SWORDBEAM_LEFT_FRAMES, LinkConstants.SWORDBEAM_LEFT_LOCATIONSHIFT);
                }
                else sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y, 
                    LinkConstants.SWORDBEAM_RIGHT_FRAMES, LinkConstants.SWORDBEAM_RIGHT_LOCATIONSHIFT);
            }
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public Vector2 Update()
        {
            if ((this.originalPosition - this.position).Length() > LinkConstants.MAX_SWORDBEAM_RANGE) this.Split();

            this.position += velocity;

            this.sprite.Update((int)position.X, (int)position.Y);

            return this.position;
        }

        public LinkConstants.Link_Projectiles GetProjectileType()
        {
            return LinkConstants.Link_Projectiles.SwordBeam;
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