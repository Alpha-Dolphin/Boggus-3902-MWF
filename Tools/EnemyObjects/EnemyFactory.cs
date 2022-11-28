using LOZ.Tools;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using LOZ.Tools.ItemObjects;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Tools.EnemyObjects;
using LOZ.Tools.PlayerObjects;

namespace LOZ.Tools
{
    internal class EnemyFactory
    {
        readonly int X = 128;
        readonly int Y = 88;
        public int curr;

        public EnemyFactory()
        {
            curr = 0;
        }

        public bool Update(List<Keys> pressed, List<Keys> held)
        {
            if (pressed.Contains(Keys.O) && !held.Contains(Keys.O))
            {
                curr = ++curr % 9;
                return true;
            }
            else if (pressed.Contains(Keys.P) && !held.Contains(Keys.P))
            {
                curr = --curr % 9;
                return true;
            }
            return false;
        }

        public IEnemy NewEnemy()
        {
            if (curr == 0) return CreateKeese();
            else if (curr == 1) return CreateSlime();
            else if (curr == 2) return CreateStalfos();
            else if (curr == 3) return CreateGoriya();
            else if (curr == 4) return CreateZol();
            else if (curr == 5) return CreateRope();
            else if (curr == 6) return CreateDodongo();
            else if (curr == 7) return CreateWallmaster();
            else if (curr == 8) return CreateTrap();
            else if (curr == 9) return CreateAquamentus();
            else return CreateEnemySpawner();
        }

        public IEnemy CreateEnemySpawner()
        {
            return new EnemySpawner(X, Y);
        }
        public IEnemy CreateKeese()
        {
            return new Keese(X, Y);
        }

        public IEnemy CreateSlime()
        {
            return new Slime(X, Y);
        }
        public IEnemy CreateGoriya()
        {
            return new Goriya(X, Y);
        }
        public IEnemy CreateAquamentus()
        {
            return new Aquamentus(X, Y);
        }
        public IEnemy CreateStalfos()
        {
            return new Stalfos(X, Y);
        }
        public IEnemy CreateZol()
        {
            return new Zol(X, Y);
        }
        public IEnemy CreateRope()
        {
            return new Rope(X, Y);
        }
        public IEnemy CreateDodongo()
        {
            return new Dodongo(X, Y);
        }
        public IEnemy CreateWallmaster()
        {
            return new Wallmaster(X, Y);
        }
        public IEnemy CreateTrap()
        {
            return new Trap(X, Y);
        }
    }
}
