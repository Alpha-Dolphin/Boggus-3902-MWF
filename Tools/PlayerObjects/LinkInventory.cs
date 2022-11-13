using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.PlayerObjects
{
    public class LinkInventory
    {
        public bool woodenSword { get; set; } = false;
        public bool boomerang { get; set; } = false;
        public bool bow { get; set; } = false;
        public bool candleFlame { get; set; } = false;
        public bool map { get; set; } = false;
        public bool compass { get; set; } = false;
        public bool potion { get; set; } = false;
        public bool bomb { get; set; } = false;

        public int rupees { get; set; } = 0;
        public int keys { get; set; } = 0;
        public int bombs { get; set; } = 0;
        public int arrows { get; set; } = 0;
    }
}
