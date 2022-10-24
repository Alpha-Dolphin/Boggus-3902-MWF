using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.NPCObjects;
using LOZ.Tools.ItemObjects;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.Tools.LevelManager
{
    internal class Room
    {
        /*Lists of things in room*/
        public List<Rectangle> barrierList { get; set; } = new List<Rectangle>();
        public List<IEnvironment> environmentList { get; set; } = new List<IEnvironment> ();
        public List<IEnemy> enemyList { get; set; } = new List<IEnemy>();
        public List<INPC> NPCList { get; set; } = new List<INPC>();
        public List<IItem> itemList { get; set; } = new List<IItem>();
        public int northNeighbor { get; set; } = 0;
        public int southNeighbor { get; set; } = 0;
        public int westNeighbor { get; set; } = 0;
        public int eastNeighbor { get; set; } = 0;
        public int roomNumber { get; set; } = 0;
        public bool border { get; set; }
        public string template { get; set; }/*template is null if there is no template*/

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IEnvironment environment in environmentList)
            {
                environment.Draw(spriteBatch);
            }
            foreach (IEnemy enemy in enemyList)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (INPC npc in NPCList)
            {
                npc.Draw(spriteBatch);
            }
            foreach (IItem item in itemList)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
