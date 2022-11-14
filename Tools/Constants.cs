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
    InvisibleBarrier,
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
    Wallmaster,
    Trap
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
public enum Gate
{
    NorthKeyholeDoor,
    WestKeyholeDoor,
    EastKeyholeDoor,
    SouthKeyholeDoor,
    NorthDiamondDoor,
    SouthDiamondDoor,
    EastDiamondDoor,
    WestDiamondDoor,
    NorthBombHole,
    SouthBombHole,
    EastBombHole,
    WestBombHole,
    NorthWall,
    SouthWall,
    EastWall,
    WestWall,
    NorthOpenDoor,
    SouthOpenDoor,
    EastOpenDoor,
    WestOpenDoor,
}
public enum Direction
{
    North,
    South,
    East,
    West,
}
public enum SoundEffects
{
    AquaScream,
    BossHit,
    DodongoScream,
    EnemyDie,
    EnemyHit,
    OtherBossScream,
    DoorUnlock,
    FoundSecret,
    KeyAppear,
    Text,
    TextSlow,
    WalkingStairs,
    ArrowBoomerang,
    BombBlow,
    BombDrop,
    Candle,
    GetHeart,
    GetItem,
    GetRupee,
    MagicRod,
    NewItemSong,
    ShieldDeflect,
    SwordCombined,
    SwordShoot,
    SwordSlash,
    LinkDie,
    LinkHurt,
    LowHealth,
    RefillHealth
}

public class Constants
{
    public const string DungeonSpriteSheetLocation = "./SpriteSheets/Dungeon Tileset";
    public const string RegEnemySpriteSheetLocation = "SpriteSheets/DungeonEnemies_EmptyBackground";
    public const string BossesSpriteSheetLocation = "./SpriteSheets/Bosses";
    public const string NPCSpriteSheetLocation = "./SpriteSheets/NPCs";
    public const string ItemSpriteSheetLocation = "./SpriteSheets/Items";
    public const string HUDSpriteSheetLocation = "./SpriteSheets/HUD";
    public const string AquaScreamLocation = "./SoundEffects/Enemies/AquaScream";
    public const string BossHitLocation = "./SoundEffects/Enemies/BossHit";
    public const string DodongoScreamLocation = "./SoundEffects/Enemies/DodongoScream";
    public const string EnemyDieLocation = "./SoundEffects/Enemies/EnemyDie";
    public const string EnemyHitLocation = "./SoundEffects/Enemies/EnemyHit";
    public const string OtherBossScream = "./SoundEffects/Enemies/OtherBossScream";
    public const string DoorUnlockLocation = "./SoundEffects/Environment/DoorUnlock";
    public const string FoundSecretLocation = "./SoundEffects/Environment/FoundSecret";
    public const string KeyAppearLocation = "./SoundEffects/Environment/KeyAppear";
    public const string TextLocation = "./SoundEffects/Environment/Text";
    public const string TextSlowLocation = "./SoundEffects/Environment/TextSlow";
    public const string WalkingStairsLocation = "./SoundEffects/Environment/WalkingStairs";
    public const string ArrowBoomerangLocation = "./SoundEffects/ItemWeapon/ArrowBoomerang";
    public const string BombBlowLocation = "./SoundEffects/ItemWeapon/BombBlow";
    public const string BombDropLocation = "./SoundEffects/ItemWeapon/BombDrop";
    public const string CandleLocation = "./SoundEffects/ItemWeapon/Candle";
    public const string GetHeartLocation = "./SoundEffects/ItemWeapon/GetHeart";
    public const string GetItemLocation = "./SoundEffects/ItemWeapon/GetItem";
    public const string GetRupeeLocation = "./SoundEffects/ItemWeapon/GetRupee";
    public const string MagicRodLocation = "./SoundEffects/ItemWeapon/MagicRod";
    public const string NewItemSongLocation = "./SoundEffects/ItemWeapon/NewItemSong";
    public const string ShieldDeflectLocation = "./SoundEffects/ItemWeapon/ShieldDeflect";
    public const string SwordCombinedLocation = "./SoundEffects/ItemWeapon/SwordCombined";
    public const string SwordShootLocation = "./SoundEffects/ItemWeapon/SwordShoot";
    public const string SwordSlashLocation = "./SoundEffects/ItemWeapon/SwordSlash";
    public const string LinkDieLocation = "./SoundEffects/Link/LinkDie";
    public const string LinkHurtLocation = "./SoundEffects/Link/LinkHurt";
    public const string LowHealthLocation = "./SoundEffects/Link/LowHealth";
    public const string RefillHealthLocation = "./SoundEffects/Link/RefillLoop";
    public const string ExplosionSpriteSheetLocation = "./SpriteSheets/EnemyDeathExplosion";
    public const int objectScale = 2;
    public const int enviroDefaultX = 10;
    public const int enviroDefaultY = 10;
    public const double enemyEntryExitTime = 500;
    public const string HUDSpriteSheetLocation = "./SpriteSheets/HUD";
    public const int numRooms = 19;
    public const int numSounds = 29;
    public const bool DEBUG = true;
}
