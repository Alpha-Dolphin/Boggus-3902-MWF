/*Storage for constant enums, globals etc.*/

public enum Environment
{
    Statues,
    SquareBlock,
    PushBlock,
    Fire,
    WalkableBlueGap,
    Stairs,
    WhiteBrick, 
    Ladders,
    BlueFloor, 
    BlueSand,
    RoomBorder,
    OpenDoor,
    BombedWallOpening,
    KeyholeLockedDoor,
    DiamondSymbolLockedDoor,
}

public enum Item
{
    Compass,
    Map,
    Key,
    HeartContainer,
    TriforcePiece,
    WoodenBoomerang,
    Bow,
    Heart,
    Rupee,
    Arrow,
    Bomb,
    Fairy,
    Clock,
    BlueCandle,
    BluePotion,
}

public class Constants
{
    public const string DungeonSpriteSheetLocation = "./SpriteSheets/Dungeon Tileset";
    public const string RegEnemySpriteSheetLocation = "SpriteSheets/Dungeon Enemies";
    public const string BossesSpriteSheetLocation = "./SpriteSheets/Bosses";
    public const string NPCSpriteSheetLocation = "./SpriteSheets/NPCs";
    public const int objectScale = 2;
    public const int enviroDefaultX = 10;
    public const int enviroDefaultY = 10;
}