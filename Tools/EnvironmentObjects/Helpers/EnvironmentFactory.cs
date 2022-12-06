/*Factory object to generate all environment objects*/

/*TODO: Implement case logic for all environment blocks*/

using LOZ.Tools.Interfaces;

namespace LOZ.Tools.EnvironmentObjects.Helpers
{
    class EnvironmentFactory
    {
        public IEnvironment getEnvironment(Environment environment)
        {
            switch (environment)
            {
                case Environment.Statue:
                    return new Statue();

                case Environment.Statue2:
                    return new Statue2();

                case Environment.SquareBlock:
                    return new SquareBlock();

                case Environment.PushBlock:
                    return new PushBlock();

                case Environment.Fire:
                    return new Fire();

                case Environment.WalkableBlueGap:
                    return new WalkableBlueGap();

                case Environment.Stairs:
                    return new Stairs();

                case Environment.WhiteBrick:
                    return new WhiteBrick();

                case Environment.Ladders:
                    return new Ladders();

                case Environment.BlueFloor:
                    return new BlueFloor();

                case Environment.BlueSand:
                    return new BlueSand();

                case Environment.RoomBorder:
                    return new RoomBorder();

                case Environment.OpenDoor:
                    return new OpenDoor();

                case Environment.BombedWallOpening:
                    return new BombedWallOpening();

                case Environment.KeyholeLockedDoor:
                    return new KeyholeLockedDoor();

                case Environment.DiamondSymbolLockedDoor:
                    return new DiamondSymbolLockedDoor();

                case Environment.InvisibleBarrier:
                    return new InvisibleBarrier();

                default:
                    return new Statue();
            }

        }
    }
}
