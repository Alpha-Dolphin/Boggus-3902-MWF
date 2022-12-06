using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.PlayerObjects
{
    public static class LinkInventory
    {
        public static bool woodenSword { get; set; } = false;
        public static bool boomerang { get; set; } = false;
        public static bool bow { get; set; } = false;
        public static bool candleFlame { get; set; } = false;
        public static bool map { get; set; } = false;
        public static bool compass { get; set; } = false;
        public static bool potion { get; set; } = false;
        public static bool bomb { get; set; } = false;
        public static bool triforcePiece { get; set; } = false;

        public static int rupees { get; set; } = 0;
        public static int keys { get; set; } = 0;
        public static int bombs { get; set; } = 0;
        public static int arrows { get; set; } = 0;
    }
}
