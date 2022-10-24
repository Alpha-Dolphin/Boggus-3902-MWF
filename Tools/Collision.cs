using LOZ.Tools.EnvironmentObjects;
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
        public static void CollisionChecker(ICollidable a, ICollidable b)
        {
            //Link must always be the first object in the list if Link is in the list

            //NOTE - If object is of type rectangle, it is a Link weapon hitbox. Bad design, but it will work for now
            if (typeof(Weapon) == a.GetType())
            {
                if (b is IEnemy bEnemy) bEnemy.Die();
            }
            else if (a is Link)
            {
                //Then collision must be Link-block collision
                if (typeof(PushBlock) == b.GetType()) Collide(a, b);
                else Collide(b, a);
            }
            else if (a is IEnvironment)
            {
                if (typeof(PushBlock) == a.GetType() && b is not IEnemy) Collide(b, a);
                else Collide(a, b);
            }
            else if (a is IEnemy)
            {
                if (b is Link damaged) damaged.Damage();
            }
        }
        static void Collide(ICollidable unchanged, ICollidable changed)
        {
            Rectangle zone = Rectangle.Intersect(unchanged.GetHurtbox(), changed.GetHurtbox());
            //If collison is taller than wide
            if (zone.Bottom - zone.Top > zone.Right - zone.Left)
            {
                if (zone.Right == unchanged.GetHurtbox().Right)
                {
                    Rectangle temp = new (zone.Right, changed.GetHurtbox().Y, changed.GetHurtbox().Width, changed.GetHurtbox().Height);
                    changed.SetHurtbox(temp);
                }
                else
                {
                    Rectangle temp = new (zone.Left - changed.GetHurtbox().Width, changed.GetHurtbox().Y, changed.GetHurtbox().Width, changed.GetHurtbox().Height);
                    changed.SetHurtbox(temp);
                }
            }
            else
            {
                if (zone.Bottom == unchanged.GetHurtbox().Bottom)
                {
                    Rectangle temp = new(changed.GetHurtbox().X, zone.Bottom, changed.GetHurtbox().Width, changed.GetHurtbox().Height);
                    changed.SetHurtbox(temp);
                }
                else
                {
                    Rectangle temp = new(changed.GetHurtbox().X, zone.Top - changed.GetHurtbox().Height, changed.GetHurtbox().Width, changed.GetHurtbox().Height);
                    changed.SetHurtbox(temp);
                }
            }
        }
    }
}


