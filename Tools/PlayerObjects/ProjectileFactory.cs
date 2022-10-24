using LOZ.Tools.NPCObjects;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.PlayerObjects
{
    internal class ProjectileFactory
    {
        private LinkConstants.Link_Projectiles projectileType;
        private Texture2D spriteSheet;
        public ProjectileFactory(LinkConstants.Link_Projectiles projectileType, Texture2D spritesheet)
        {
            this.projectileType = projectileType;
            this.spriteSheet = spritesheet;
        }

        public void Update(LinkConstants.Link_Projectiles projectileType)
        {
            this.projectileType = projectileType;
        }

        public IProjectile CreateProjectile(Vector2 velocity)
        {
            switch (this.projectileType)
            {
                case LinkConstants.Link_Projectiles.SwordBeam: return new Swordbeam(this.spriteSheet, Link.position, LinkConstants.PROJECTILE_SPEED * velocity);
                case LinkConstants.Link_Projectiles.WoodArrow: return new ArrowProjectile(this.spriteSheet, Link.position, LinkConstants.PROJECTILE_SPEED * velocity, true);
                case LinkConstants.Link_Projectiles.BlueArrow: return new ArrowProjectile(this.spriteSheet, Link.position, LinkConstants.PROJECTILE_SPEED * velocity, false);
                case LinkConstants.Link_Projectiles.Boomerang: return new Boomerang(this.spriteSheet, Link.position, LinkConstants.BOOMERANG_SPEED * velocity);
                case LinkConstants.Link_Projectiles.CandleFlame: return new CandleFlame(this.spriteSheet, Link.position, LinkConstants.PROJECTILE_SPEED * velocity);
                case LinkConstants.Link_Projectiles.Bomb: return new Bomb(this.spriteSheet, Link.position, new Vector2(0, 0));
                default: return null;
            }
        }
    }
}
