using LOZ.Tools.EnvironmentObjects;
using LOZ.Tools.Interfaces;
using LOZ.Tools.PlayerObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools
{
    internal class Collision
    {
        public static bool Intersects(Rectangle a, Rectangle b)
        {
            return a.Intersects(b);
        }
        public static void CollisionChecker(Object a, Object b)
        {
            //Link must always be the first object in the list if Link is in the list
            if (a is Link linka)
            {
                if (b is IEnemy) linka.Damage();
                else
                {
                    IEnvironment b2 = (IEnvironment) b;
                    if (typeof(PushBlock) == b2.GetType()) Collide(linka.GetHurtbox(), b2.GetRectangle());
                    else Collide(b2.GetRectangle(), linka.GetHurtbox());
                }
            }
            else if (a is IEnvironment aBlock && b is IEnvironment bBlock)
            {
                if (bBlock is PushBlock) Collide(aBlock.GetRectangle(), aBlock.GetRectangle());
                //Otherwise a must be PushBlock
                else Collide(bBlock.GetRectangle(), aBlock.GetRectangle());
            }
            else if (a is IEnemy aEnemy)
            {
                if (b is IEnvironment bBlock2) Collide(bBlock2.GetRectangle(), aEnemy.GetRectangle());
                else
                {
                    //Won't let me assign bEnemy on it's own.
                    if (b is IEnemy bEnemy) Collide(aEnemy.GetRectangle(), bEnemy.GetRectangle());
                }
            }
        }
        static void Collide(Rectangle unchanged, Rectangle changed)
        {
            Rectangle zone = Rectangle.Intersect(unchanged, changed);
            //If colliison is taller than wide
            if (zone.Bottom - zone.Top > zone.Right - zone.Left)
            {
                if (changed.Right > zone.Right) changed.X += zone.X;
                else changed.X -= zone.X;
            }
            else {
                if (changed.Top > zone.Top) changed.Y -= zone.Y;
                else changed.Y += zone.Y;
            }
        }
    }
}
