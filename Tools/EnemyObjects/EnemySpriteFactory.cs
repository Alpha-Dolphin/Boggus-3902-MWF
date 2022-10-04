using LOZ.Tools.Interfaces;
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

namespace LOZ.Tools
{
    internal class EnemySpriteFactory
    {
        readonly int X = 100;
        readonly int Y = 300;
        int curr;

        public EnemySpriteFactory()
        {
            curr = 0;
        }

        public bool Update(List<Keys> pressed, List<Keys> held)
        {
            if (pressed.Contains(Keys.O) && !held.Contains(Keys.O))
            {
                //I don't know why, but the modulo operator wouldn't work so I'm doing this
                curr++;
                if (curr > 3) curr = 0;
                return true;
            }
            else if (pressed.Contains(Keys.P) && !held.Contains(Keys.P))
            {
                curr--;
                if (curr < 0) curr = 3;
                return true;
            }
            return false;
        }

        public Enemy NewEnemy()
        {
            if (curr == 0) return CreateKeese();
            else if (curr == 1) return CreateSlime();
            else if (curr == 2) return CreateGoriya();
            else if (curr == 3) return CreateAquamentus();
            else return CreateAquamentus();
        }

        public Enemy CreateKeese()
        {
            return new Keese(X, Y);
        }

        public Enemy CreateSlime()
        {
            return new Slime(X, Y);
        }

        public Enemy CreateGoriya()
        {
            return new Goriya(X, Y);
        }
        public Enemy CreateAquamentus()
        {
            return new Aquamentus(X, Y);
        }
        public Enemy CreateStalfos()
        {
            return new Stalfos(X, Y);
        }
    }
}
