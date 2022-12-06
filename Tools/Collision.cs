using LOZ.Tools.Command;
using LOZ.Tools.EnvironmentObjects;
using LOZ.Tools.PlayerObjects;
using Microsoft.Xna.Framework;
using LOZ.Tools.Interfaces;
using LOZ.Tools.LevelManager;
using LOZ.Tools.RoomTransitionHandler;

namespace LOZ.Tools
{
    internal class Collision
    {
        public static void UpdateCollision()
        {
            Game1.enemyList = Game1.rooms[Game1.currentRoom].enemyList;
            Game1.itemList = Game1.rooms[Game1.currentRoom].itemList;
            Game1.blockList = Game1.rooms[Game1.currentRoom].environmentList;
            Game1.gateList = Game1.rooms[Game1.currentRoom].gateList;
            foreach (IEnemy ene in Game1.enemyList)
            {
                if (Collision.Intersects(Game1.link.GetHurtbox(), ene.GetHurtbox()))
                {
                    Collision.CollisionChecker(ene, Game1.link);
                }
                foreach (IEnvironment bL in Game1.blockList)
                {
                    if (Collision.Intersects(bL.GetHurtbox(), ene.GetHurtbox()))
                    {
                        Collision.CollisionChecker(bL, ene);
                    }
                }
                foreach (ICollidable weapon in Game1.link.GetHitboxes())
                {
                    if (Collision.Intersects(weapon.GetHurtbox(), ene.GetHurtbox()))
                    {
                        Collision.CollisionChecker(weapon, ene);
                    }
                }
                foreach (IGate gate in Game1.gateList)
                {
                    if (Collision.Intersects(ene.GetHurtbox(), gate.GetHurtbox()))
                    {
                        Collision.CollisionChecker(gate, ene);
                    }
                }
                foreach (IEnemy ene2 in Game1.enemyList)
                {
                    if (ene != ene2 && Collision.Intersects(ene.GetHurtbox(), ene2.GetHurtbox())) Collision.CollisionChecker(ene, ene2);
                }
            }

            Game1.enemyList.RemoveAll(enem => Game1.enemyDieList.Contains(enem));
            Game1.enemyList.AddRange(Game1.enemyNewList);
            //To prevent exponential enemy spawning, as funny as that is
            Game1.enemyNewList = new();

            for (int i = 0; i < Game1.itemList.Count; i++)
            {
                if (Collision.Intersects(Game1.link.GetHurtbox(), Game1.itemList[i].GetHurtbox()))
                {
                    Game1.linkCommandHandler.GetItem(Game1.itemList[i]);
                    Game1.itemList.RemoveAt(i);
                    i--;
                }
            }

            foreach (IEnvironment bL in Game1.blockList)
            {
                if (Collision.Intersects(Game1.link.GetHurtbox(), bL.GetHurtbox())) Collision.CollisionChecker(Game1.link, bL);
                foreach (IEnvironment bL2 in Game1.blockList)
                {
                    if (typeof(PushBlock) == bL.GetType() && bL != bL2)
                    {
                        if (Collision.Intersects(bL2.GetHurtbox(), bL.GetHurtbox())) Collision.CollisionChecker(bL, bL2);
                    }
                }
                foreach (IGate g in Game1.gateList)
                {
                    if (Collision.Intersects(g.GetHurtbox(), bL.GetHurtbox())) Collision.CollisionChecker(bL, g);
                }
            }
            foreach (IGate gate in Game1.gateList)
            {
                if (Collision.Intersects(Game1.link.GetHurtbox(), gate.GetHurtbox()))
                {
                    if (gate.IsGateOpen())
                    {
                        Game1.gameState = 3;
                        Game1.roomTransitionHandler.HandleTransition(Game1.rooms[Game1.currentRoom], gate, Game1.link);
                    }
                    else
                    {
                        Collision.CollisionChecker(gate, Game1.link);
                        if (LinkInventory.keys > 0)
                        {
                            Game1.roomTransitionHandler.unlockDoor(gate, Game1.rooms, Game1.currentRoom);
                            LinkInventory.keys--;
                        }
                    }
                }
            }
        }

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


