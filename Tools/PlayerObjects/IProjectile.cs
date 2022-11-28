using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Tools.Interfaces;

namespace LOZ.Tools.PlayerObjects
{
    internal interface IProjectile : IHurtbox
    {
        public void SetVelocity(Vector2 velocity);
        public Vector2 Update();
        public PlayerConstants.Link_Projectiles GetProjectileType();
        public void Draw(SpriteBatch spriteBatch);
        public void Destroy();
        public bool stillExists();
    }
}