using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.Interfaces;
using LOZ.Tools.NPCObjects;
using LOZ.Tools.ItemObjects;

namespace LOZ.Tools.LevelManager
{
    internal class Room
    {
        /*Lists of things in room*/
        public List<Rectangle> barrierList { get; set; }
        public List<IEnvironment> environmentList { get; set; }
        public List<IEnemy> enemyList { get; set; }
        public List<INPC> NPCList { get; set; }
        public List<IItem> itemList { get; set; }
        public int northNeighbor { get; set; }
        public int southNeighbor { get; set; }
        public int westNeighbor { get; set; }
        public int eastNeighbor { get; set; }
        public int roomNumber { get; set; }
        public bool border { get; set; }
        public string template { get; set; }/*template is null if there is no template*/
    }
}
