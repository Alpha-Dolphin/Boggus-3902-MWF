/*Storage for constant enums, globals etc.*/

public enum Environment
{
    Statue,
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

public enum Enemy
{
    Keese,
    Slime,
    Stalfos,
    Goriya,
    Zol,
    Rope,
    Dodongo,
    Aquamentus,
}

public enum NPC
{
    OldMan,
    OldManFlame,
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
    public const string RegEnemySpriteSheetLocation = "SpriteSheets/DungeonEnemies_EmptyBackground";
    public const string BossesSpriteSheetLocation = "./SpriteSheets/Bosses";
    public const string NPCSpriteSheetLocation = "./SpriteSheets/NPCs";
    public const string ItemSpriteSheetLocation = "./SpriteSheets/Items";
    public const int objectScale = 2;
    public const int enviroDefaultX = 10;
    public const int enviroDefaultY = 10;
}