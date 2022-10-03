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
    internal class CandleFlame : IProjectile
    {
        private Vector2 originalPosition;
        private Vector2 position;
        private Vector2 velocity;
        private ISprite sprite;

        private bool exists = true;

        public CandleFlame() { }

        public CandleFlame(Texture2D spriteSheet, Vector2 position, Vector2 velocity)
        {
            this.originalPosition = position;
            this.position = position;
            this.velocity = velocity;

            CreateSprite(spriteSheet);
        }

        private void CreateSprite(Texture2D spriteSheet)
        {
            sprite = new AnimatedMovingSprite(spriteSheet, (int)position.X, (int)position.Y,
                        LinkConstants.CANDLEFLAME_FRAMES);
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
            return LinkConstants.Link_Projectiles.CandleFlame;
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
