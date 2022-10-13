using LOZ.Tools.Interfaces;
using LOZ.Tools.PlayerObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools
{
    internal class Collision
    {
        double damageCooldown;
        bool Intersects(Rectangle a, Rectangle b)
        {
            return a.Intersects(b);
        }
        void CollisionChecker(Object a, Object b)
        {
            //This code could be simplified if it can be guranteed Link will always be the 1st (or last) object in the array of collidable objects
            if (a is Link linka)
            {
                if (b is IEnemy) linka.Damage();
                /*else if (b.Moveable()) Collide(linka.getRect(), b.getRect());
                 else Collide(b,getRect(), linka.getRect());*/
            }
            else if (a is IEnvironment && b is IEnvironment)
            {
                /*if (a.Moveable()) Collide(a.getRect(), b.getRect())
                else Collide(b.getRect(), a.getRect())*/
            }
            //Wall colliding with enemy
            else if (a is IEnvironment) /*collide(a.getRect(),b.getRect())*/;
            else /*Collide(b.getRect(),a.getRect())*/;
        }
        void Collide(Rectangle unchanged, Rectangle changed)
        {
            Rectangle zone = Rectangle.Intersect(unchanged, changed);
            //If colliison is taller than wide
            if (zone.Bottom - zone.Top > zone.Right - zone.Left) changed.X -= zone.X;
            else changed.Y -= zone.Y;
        }
    }
}
