using LOZ.Tools.Interfaces;

namespace LOZ.Tools.GateObjects.Helpers
{
    internal class GateFactory
    {
        public IGate getGate(Gate gate)
        {
            switch (gate)
            {
                case Gate.EastKeyholeDoor:
                    return new EastKeyholeDoor();

                case Gate.WestKeyholeDoor:
                    return new WestKeyholeDoor();

                case Gate.NorthKeyholeDoor:
                    return new NorthKeyholeDoor();

                case Gate.SouthKeyholeDoor:
                    return new SouthKeyholeDoor();

                case Gate.NorthDiamondDoor:
                    return new NorthDiamondDoor();

                case Gate.SouthDiamondDoor:
                    return new SouthDiamondDoor();

                case Gate.EastDiamondDoor:
                    return new EastDiamondDoor();

                case Gate.WestDiamondDoor:
                    return new WestDiamondDoor();

                case Gate.NorthBombHole:
                    return new NorthBombHole();

                case Gate.SouthBombHole:
                    return new SouthBombHole();

                case Gate.EastBombHole:
                    return new EastBombHole();

                case Gate.WestBombHole:
                    return new WestBombHole();

                case Gate.NorthWall:
                    return new NorthWall();

                case Gate.SouthWall:
                    return new SouthWall();

                case Gate.EastWall:
                    return new EastWall();

                case Gate.WestWall:
                    return new WestWall();

                case Gate.NorthOpenDoor:
                    return new NorthOpenDoor();

                case Gate.SouthOpenDoor:
                    return new SouthOpenDoor();

                case Gate.EastOpenDoor:
                    return new EastOpenDoor();

                case Gate.WestOpenDoor:
                    return new WestOpenDoor();

                case Gate.Stairs:
                    return new Stairs();

                case Gate.InvisibleGate:
                    return new InvisibleGate();

                default:
                    return new WestWall();
            }
        }
    }
}
/*Factory object to generate all environment objects*/


