using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace LOZ.Tools.NPCObjects
{
    internal class NPCFactory
    {
        private int currentNPCNum = 0;
        private INPC currentNPC;
        public int numNPC = 2;
        private int x = 600;
        private int y = 250;
        private Texture2D spriteSheet;
        public NPCFactory(int NPCnum, Texture2D spritesheet)
        {
            this.currentNPCNum = NPCnum;
            this.spriteSheet = spritesheet;
            this.currentNPC = new OldMan(spritesheet, this.x, this.y);
        }

        public void Update(List<Keys> keys, GameTime gametime)
        {
            foreach (Keys key in keys)
            {
                if (key.ToString().ToUpper().Equals("O"))
                {
                    if (this.currentNPCNum == 0)
                    {
                        this.currentNPCNum = numNPC - 1;
                    }
                    else
                    {
                        this.currentNPCNum--;
                    }
                }
                else if (key.ToString().ToUpper().Equals("P"))
                {
                    if (this.currentNPCNum == numNPC - 1)
                    {
                        this.currentNPCNum = 0;
                    }
                    else
                    {
                        this.currentNPCNum++;
                    }
                }
            }

            this.currentNPC.Update(gametime);

        }

        public void CreateNPC()
        {
            switch (this.currentNPCNum)
            {
                case 0: this.currentNPC = new OldMan(this.spriteSheet, x, y); break;

                case 1: this.currentNPC = new OldManFlame(this.spriteSheet, x, y); break;

                default: this.currentNPC = new OldMan(this.spriteSheet, x, y); break;


            }
        }

        public void Draw(SpriteBatch _spritebatch)
        {
            this.currentNPC.Draw(_spritebatch);
        }

    }
}
