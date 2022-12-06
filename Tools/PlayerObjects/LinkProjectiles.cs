using LOZ.Tools.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.PlayerObjects
{
    public class LinkProjectiles
    {

        private List<IProjectile> projectiles;
        private ProjectileFactory projectileFactory;

        public LinkProjectiles(Texture2D spriteSheet)
        {
            this.projectiles = new List<IProjectile>();
            this.projectileFactory = new ProjectileFactory(PlayerConstants.Link_Projectiles.BlueArrow, spriteSheet);
        }

        public List<Rectangle> UpdateHitboxes()
        {
            List<Rectangle> hitboxes = new List<Rectangle>();

            foreach (IProjectile projectile in projectiles)
            {
                List<Rectangle> temp = projectile.GetHitboxes();

                foreach (Rectangle rect in temp)
                {
                    hitboxes.Add(rect);
                }
            }

            return hitboxes;
        }
        public void CreateProjectile(PlayerConstants.Link_Projectiles projectileType, PlayerConstants.Direction direction, ICollidable owner)
        {
            bool containsProjectile = false;
            foreach (IProjectile projectile in projectiles)
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
                    if (LinkInventory.bombs > 0)
                    {
                        LinkInventory.bombs--;
                    }
                    else
                    {
                        projectileAvailable = false;
                    }
                }

                if (projectileAvailable)
                {
                    Vector2 velocity = new Vector2(0, 0);
                    switch (direction)
                    {
                        case PlayerConstants.Direction.Up: velocity = new Vector2(0, -1); break;
                        case PlayerConstants.Direction.Left: velocity = new Vector2(-1, 0); break;
                        case PlayerConstants.Direction.Right: velocity = new Vector2(1, 0); break;
                        case PlayerConstants.Direction.Down: velocity = new Vector2(0, 1); break;
                    }

                    this.projectileFactory.Update(projectileType);
                    this.projectiles.Add(this.projectileFactory.CreateProjectile(velocity, owner));
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IProjectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }

        public void Update()
        {
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
    }
}
