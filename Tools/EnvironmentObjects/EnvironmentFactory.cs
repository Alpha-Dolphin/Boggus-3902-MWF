/*Factory object to generate all environment objects*/

/*TODO: Implement case logic for all environment blocks*/

class environmentFactory
{
    private IEnvironment GetEnvironment(Environment environment)
    {
        switch (environment)
        {
            case Environment.Statues:
                return new Statue();

            case Environment.SquareBlock:
                return new Statue();

            case Environment.PushBlock:
                return new Statue();

            case Environment.Fire:
                return new Statue();

            case Environment.WalkableBlueGap:
                return new Statue();
                
            case Environment.Stairs:
                return new Statue();
                
            case Environment.WhiteBrick:
                return new Statue();
                
            case Environment.Ladders:
                return new Statue();
                
            case Environment.BlueFloor:
                return new Statue();
                
            case Environment.BlueSand:
                return new Statue();
            
            case Environment.RoomBorder:
                return new Statue();

            case Environment.OpenDoor:
                return new Statue();

            case Environment.BombedWallOpening:
                return new Statue();

            case Environment.KeyholeLockedDoor:
                return new Statue();

            case Environment.DiamondSymbolLockedDoor:
                return new Statue();
            
            default:
                return new Statue();
        }
        
    }
}
