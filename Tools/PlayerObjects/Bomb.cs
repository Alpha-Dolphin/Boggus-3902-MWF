using CSE3902_Sprint0.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.PlayerObjects
{
    internal class Bomb : IProjectile
    {
        private Vector2 originalPosition;
        private Vector2 position;
        private Vector2 velocity;
        private ISprite sprite;
        private Texture2D spriteSheet;
        private int delay = LinkConstants.BOMB_EXPLOSION_DELAY;

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
                    new List<Rectangle> { LinkConstants.BOMB_FRAME }, LinkConstants.DEFAULT_FRAMERATE);
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public Vector2 Update()
        {
            this.sprite.Update((int)position.X, (int)position.Y);

            if (exploded && this.sprite.finished())
            {
                this.sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                    new List<Rectangle> { new Rectangle(0, 0, 0, 0) });
                this.exists = false;
            }

            if(delay > 0) delay--;

            return this.position;
        }

        public LinkConstants.Link_Projectiles GetProjectileType()
        {
            return LinkConstants.Link_Projectiles.Bomb;
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
                    LinkConstants.BOMB_EXPLOSION_FRAMES);
            this.exploded = true;
        }

        public bool stillExists()
        {
            return exists;
        }
    }
}
