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

        public void Update(List<Keys> pressed, List<Keys> held, GameTime gametime)
        {
            if (pressed.Contains(Keys.O) && !held.Contains(Keys.O)) /*Increment with rollover*/
            {
                currentNPCNum = (currentNPCNum + 1) % numNPC;
            }
            if (pressed.Contains(Keys.P) && !held.Contains(Keys.P)) /*Decrement with rollover*/
            {
                currentNPCNum = (numNPC + (currentNPCNum - 1)) % numNPC;
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
