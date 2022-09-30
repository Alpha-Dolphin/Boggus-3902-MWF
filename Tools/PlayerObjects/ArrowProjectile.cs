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
using CSE3902_Sprint0.Sprites;

namespace LOZ.Tools.PlayerObjects
{
    internal class ArrowProjectile : IProjectile
    {
        private Vector2 originalPosition;
        private Vector2 position;
        private Vector2 velocity;
        private ISprite sprite;

        private bool exists = true;

        public ArrowProjectile() { }

        public ArrowProjectile(Texture2D spriteSheet, Vector2 position, Vector2 velocity)
        {
            this.originalPosition = position;
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
                        Link_Constants.ARROW_WOOD_UP_FRAMES, Link_Constants.ARROW_UP_LOCATIONSHIFT);
                }
                else sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y, 
                    Link_Constants.ARROW_WOOD_DOWN_FRAMES, Link_Constants.ARROW_DOWN_LOCATIONSHIFT);
            }
            else
            {
                if (velocity.X < 0)
                {
                    sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y, 
                        Link_Constants.ARROW_WOOD_LEFT_FRAMES, Link_Constants.ARROW_LEFT_LOCATIONSHIFT);
                }
                else sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y, 
                    Link_Constants.ARROW_WOOD_RIGHT_FRAMES, Link_Constants.ARROW_RIGHT_LOCATIONSHIFT);
            }
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public Vector2 Update()
        {
            if ((this.originalPosition - this.position).Length() > Link_Constants.MAX_SWORDBEAM_RANGE) this.Destroy();

            this.position += velocity;

            this.sprite.Update((int)position.X, (int)position.Y);

            return this.position;
        }

        public Link_Constants.Link_Projectiles GetProjectileType()
        {
            return Link_Constants.Link_Projectiles.Arrow;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Destroy()
        {
            this.exists = false;
        }

        public bool stillExists()
        {
            return exists;
        }
    }
}