using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.Sprites;

namespace LOZ.Tools.PlayerObjects
{
    internal class Bomb : IProjectile
    {
        private Vector2 originalPosition;
        private Vector2 position;
        private Vector2 velocity;
        private AnimatedMovingSprite sprite;
        private Texture2D spriteSheet;
        private int delay = PlayerConstants.BOMB_EXPLOSION_DELAY;

        private bool exploded = false;
        private bool exists = true;

        public Bomb() { }

        public Bomb(Texture2D spriteSheet, Vector2 position, Vector2 velocity)
        {
            this.originalPosition = position;
            this.position = position;
            this.velocity = velocity;
            this.spriteSheet = spriteSheet;

            CreateSprite(this.spriteSheet);
        }

        private void CreateSprite(Texture2D spriteSheet)
        {
            this.sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                    new List<Rectangle> { PlayerConstants.BOMB_FRAME }, PlayerConstants.DEFAULT_FRAMERATE);
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public Vector2 Update()
        {
            this.sprite.Update((int)position.X, (int)position.Y);

            if (exploded && this.sprite.Finished())
            {
                this.sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                    new List<Rectangle> { new Rectangle(0, 0, 0, 0) });
                this.exists = false;
            }

            if(delay > 0) delay--;

            return this.position;
        }

        public PlayerConstants.Link_Projectiles GetProjectileType()
        {
            return PlayerConstants.Link_Projectiles.Bomb;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Destroy()
        {
            if (delay <= 0)
            {
                Explode();
            }
        }

        private void Explode()
        {
            this.sprite = new AnimatedMovingSprite(this.spriteSheet, (int)position.X, (int)position.Y,
                    PlayerConstants.BOMB_EXPLOSION_FRAMES);
            this.exploded = true;
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
