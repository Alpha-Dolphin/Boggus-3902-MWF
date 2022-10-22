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
        private AnimatedMovingSprite sprite;

        private bool wood;

        private bool exists = true;

        public ArrowProjectile() { }

        public ArrowProjectile(Texture2D spriteSheet, Vector2 position, Vector2 velocity, bool wood)
        {
            this.originalPosition = position;
            this.position = position;
            this.velocity = velocity;
            this.wood = wood;

            CreateSprite(spriteSheet);
        }

        private void CreateSprite(Texture2D spriteSheet)
        {
            if (velocity.X == 0)
            {
                if (velocity.Y < 0)
                {
                    if (wood)
                        sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                            LinkConstants.ARROW_WOOD_UP_FRAMES, LinkConstants.ARROW_UP_LOCATIONSHIFT);
                    else
                        sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                            LinkConstants.ARROW_BLUE_UP_FRAMES, LinkConstants.ARROW_UP_LOCATIONSHIFT);
                }
                else
                {
                    if(wood)
                        sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                            LinkConstants.ARROW_WOOD_DOWN_FRAMES, LinkConstants.ARROW_DOWN_LOCATIONSHIFT);
                    else
                        sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                            LinkConstants.ARROW_BLUE_DOWN_FRAMES, LinkConstants.ARROW_DOWN_LOCATIONSHIFT);
                }
            }
            else
            {
                if (velocity.X < 0)
                {
                    if (wood)
                        sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                            LinkConstants.ARROW_WOOD_LEFT_FRAMES, LinkConstants.ARROW_LEFT_LOCATIONSHIFT);
                    else
                        sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                            LinkConstants.ARROW_BLUE_LEFT_FRAMES, LinkConstants.ARROW_LEFT_LOCATIONSHIFT);
                }
                else
                {
                    if (wood)
                        sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                            LinkConstants.ARROW_WOOD_RIGHT_FRAMES, LinkConstants.ARROW_RIGHT_LOCATIONSHIFT);
                    else
                        sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                            LinkConstants.ARROW_BLUE_RIGHT_FRAMES, LinkConstants.ARROW_RIGHT_LOCATIONSHIFT);
                }
            }
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public Vector2 Update()
        {
            if ((this.originalPosition - this.position).Length() > LinkConstants.MAX_SWORDBEAM_RANGE) this.Destroy();

            this.position += velocity;

            this.sprite.Update((int)position.X, (int)position.Y);

            return this.position;
        }

        public LinkConstants.Link_Projectiles GetProjectileType()
        {
            return wood ? LinkConstants.Link_Projectiles.WoodArrow : LinkConstants.Link_Projectiles.BlueArrow;
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

        public List<Rectangle> GetHitboxes()
        {
            return new List<Rectangle>() { this.sprite.GetDestinationRectangle() };
        }
    }
}