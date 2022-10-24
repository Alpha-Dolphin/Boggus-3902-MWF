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

            //NOTE - If object is of type rectangle, it is a Link weapon hitbox. Bad design, but it will work for now
            if (a is Rectangle) if (b is IEnemy) b = null;
            else if (a is Link linka)
            {
                //if Link is first, he is pushing a dynamic block, but might as well check to make sure
                IEnvironment b2 = (IEnvironment) b;
                if (typeof(PushBlock) == b2.GetType()) Collide(linka.GetHurtbox(), b2.GetRectangle());
                else Collide(b2.GetRectangle(), linka.GetHurtbox());
            }
            else if (a is IEnvironment aBlock)
            {
                if (b is IEnvironment bBlock)
                {
                    if (bBlock is PushBlock) Collide(aBlock.GetRectangle(), aBlock.GetRectangle());
                    //Otherwise a must be PushBlock
                    else Collide(bBlock.GetRectangle(), aBlock.GetRectangle());
                }
                else if (b is IEnemy enem) Collide(aBlock.GetRectangle(), enem.GetRectangle());
            }
            else if (a is IEnemy)
            {
                    if (b is Link damaged) damaged.Damage();
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
