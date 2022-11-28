using LOZ.Tools.Command;
using LOZ.Tools.EnvironmentObjects;
using LOZ.Tools.PlayerObjects;
using Microsoft.Xna.Framework;
using LOZ.Tools.Interfaces;

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
                if (b is IEnemy bEnemy) bEnemy.Damage();
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
                else if (b is Trap bt)
                {
                    bt.Collide(-1);
                }
                else Collide(a, b);
            }
            else if (a is IEnemy aE)
            {
                if (b is IEnemy bE)
                {
                    EnemyCollide(aE, bE);
                }
                if (b is Link damaged) EnemyCollide(aE, damaged);
            }
            else if(a is IGate)
            {
                Collide(a, b);
            }
        }

        private static void EnemyCollide(IEnemy b, ICollidable P)
        {
            if (P is Link l){
                if (typeof(Wallmaster) == b.GetType()) Game1.roomTransitionHandler.HandleTransitionAbs(17, l, 120, 140);
                else ((LinkCommand)Game1.linkCommandHandler).ExecuteDamage();
            }
            if (P is IEnemy X)
            {
                if (b is Trap bT) bT.Collide(-2);
                if (X is Trap xT) xT.Collide(-2);
            }
        }

        static void Collide(ICollidable unchanged, ICollidable changed)
        {
            Rectangle zone = Rectangle.Intersect(unchanged.GetHurtbox(), changed.GetHurtbox());
            //If collison is taller than wide
            if (zone.Bottom - zone.Top > zone.Right - zone.Left)
            {
                if (zone.Right == unchanged.GetHurtbox().Right) changed.SetHurtbox(new(zone.Right, changed.GetHurtbox().Y, changed.GetHurtbox().Width, changed.GetHurtbox().Height));
                else changed.SetHurtbox(new(zone.Left - changed.GetHurtbox().Width, changed.GetHurtbox().Y, changed.GetHurtbox().Width, changed.GetHurtbox().Height));
            }
            else
            {
                if (zone.Bottom == unchanged.GetHurtbox().Bottom) changed.SetHurtbox(new(changed.GetHurtbox().X, zone.Bottom, changed.GetHurtbox().Width, changed.GetHurtbox().Height));
                else changed.SetHurtbox(new(changed.GetHurtbox().X, zone.Top - changed.GetHurtbox().Height, changed.GetHurtbox().Width, changed.GetHurtbox().Height));
            }
        }
    }
}


