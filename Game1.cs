using LOZ.Tools;
using LOZ.Tools.Command;
using LOZ.Tools.Controller;
using LOZ.Tools.EnvironmentObjects;
using LOZ.Tools.HUDObjects;
using LOZ.Tools.LevelManager;
using LOZ.Tools.PlayerObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using LOZ.Tools.RoomTransitionHandler;
using Microsoft.Xna.Framework.Media;
using LOZ.Tools.ItemObjects;
using Microsoft.Xna.Framework.Audio;
using LOZ.Tools.MusicObjects;
using LOZ.Tools.SoundObjects;
using LOZ.Tools.GameStateTransitionHandler;

namespace LOZ
{
    public class Game1 : Game
    {
        public int gameState;
        private List<IEnemy> enemyList;
        public static List<IEnemy> enemyDieList = new();
        private List<IItem> itemList;
        private List<IEnvironment> blockList;
        private List<IGate> gateList;

        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        public static Link link;
        private KeyboardController controller;
        private MouseController mouseController;
        public static LinkCommand linkCommandHandler;
        internal static RoomTransitionHandler roomTransitionHandler;
        internal static GameStateTransitionHandler gameStateTransitionHandler;

        private List<Room> rooms;
        public static int currentRoom = 2;
        private TextSprite currentRoomIndicator = new();

        private HUD hud;

        public static LevelManager lm = new();
        public static Texture2D LINK_SPRITESHEET;
        public static SpriteFont FONT;
        public static Texture2D ENVIRONMENT_SPRITESHEET;
        public static Texture2D REGULAR_ENEMIES_SPRITESHEET;
        public static Texture2D BOSSES_SPRITESHEET;
        public static Texture2D EXPLOSION;
        public static Texture2D NPC_SPRITESHEET;
        public static Texture2D ITEM_SPRITESHEET;
        public static Texture2D HUD_SPRITESHEET;
        public static Texture2D FONT_SPRITESHEET;

        private Song backgroundMusic;
        private MusicHandler musicBox;

        public static List<SoundEffect> soundEffectList;

        private KeyboardState previousState;

        /* hanging onto to save time later
       private string creditsString = "Credits\nProgram Made By: Team BoggusMWF\nSprites from: https://www.spriters-resource.com/nes/legendofzelda/";
        */


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            LoadContent();
            gameState = 1;
            gameStateTransitionHandler = new GameStateTransitionHandler();
            roomTransitionHandler = new RoomTransitionHandler();

            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 704 + HUDConstants.TOP_HEIGHT;
            _graphics.ApplyChanges();

            EnvironmentConstants.Initialize(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            link = new Link(PlayerConstants.DEFAULT_X, PlayerConstants.DEFAULT_Y, PlayerConstants.MAX_HEALTH,
                PlayerConstants.DEFAULT_STATE, PlayerConstants.DEFAULT_DIRECTION);
            linkCommandHandler = new LinkCommand((Link) link);

            /*Declaration of controllers*/
            controller = new KeyboardController();
            mouseController = new MouseController();

            lm = new LevelManager();
            lm.initialize();
            rooms = lm.RoomList;

            currentRoomIndicator.SetPosition(0, 20);

            hud = new HUD(HUD_SPRITESHEET, ITEM_SPRITESHEET, FONT, link);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D ItemSpriteSheet = Content.Load<Texture2D>(@"SpriteSheets\Items");
            Texture2D NPCSpriteSheet = Content.Load<Texture2D>(@"SpriteSheets\NPCs");

            musicBox = new MusicHandler();
            backgroundMusic = Content.Load<Song>(@"Music\DungeonTheme");
            musicBox.SelectSong(backgroundMusic);
            musicBox.Play();

            SoundEffectManager soundEffectManager = new (Content);
            soundEffectList = soundEffectManager.FillEffects();
            
            LINK_SPRITESHEET = Content.Load<Texture2D>(PlayerConstants.LINK_SPRITESHEET_NAME);
            FONT = Content.Load<SpriteFont>(@"textFonts\MainText");
            currentRoomIndicator.SetFont(FONT);
            ENVIRONMENT_SPRITESHEET = Content.Load<Texture2D>(Constants.DungeonSpriteSheetLocation);
            NPC_SPRITESHEET = Content.Load<Texture2D>(Constants.NPCSpriteSheetLocation);
            REGULAR_ENEMIES_SPRITESHEET = Content.Load<Texture2D>(Constants.RegEnemySpriteSheetLocation);
            BOSSES_SPRITESHEET = Content.Load<Texture2D>(Constants.BossesSpriteSheetLocation);
            ITEM_SPRITESHEET = Content.Load<Texture2D>(Constants.ItemSpriteSheetLocation);
            EXPLOSION = Content.Load<Texture2D>(Constants.ExplosionSpriteSheetLocation);
            HUD_SPRITESHEET = Content.Load<Texture2D>(Constants.HUDSpriteSheetLocation);
            FONT_SPRITESHEET = Content.Load<Texture2D>(Constants.FontSpriteSheetLocation);
        }

        protected override void Update(GameTime gameTime)
        {
            UpdateCollision();

            /*
             * Update logic here
             */
            base.Update(gameTime);

            if (link.GetHealth() == 0)
            {
                gameState = 0; 
            }
            
            // Track current state to see if M is held or not
            KeyboardState currentState = Keyboard.GetState();
            List<Keys> pressed = controller.Update();
            if (hud.Paused())
            {
                if (pressed.Contains(Keys.Right) && previousState.IsKeyUp(Keys.Right))
                {
                    hud.NextItem();
                }
                else if (pressed.Contains(Keys.Left) && previousState.IsKeyUp(Keys.Left))
                {
                    hud.PreviousItem();
                }
            }
            else
            {
                mouseController.Update();

                linkCommandHandler.Execute(pressed);
                rooms[currentRoom].Update(gameTime);
                foreach (IEnemy enemy in rooms[currentRoom].enemyList)
                {
                    enemy.Update(gameTime);
                    enemy.Move(gameTime);
                }
            }

            hud.Update(pressed);

            if (pressed.Contains(Keys.Q))
            {
                this.Exit();
            }

            // If M is pressed, but not held, mute the song
            if (pressed.Contains(Keys.M) && previousState.IsKeyUp(Keys.M))
            {
                musicBox.ToggleMute();
            }

            currentRoomIndicator.SetText("Current room number: " + currentRoom);
            
            
            previousState = currentState;
        }

        private void UpdateCollision()
        {
            enemyList = rooms[currentRoom].enemyList;
            itemList = rooms[currentRoom].itemList;
            blockList = rooms[currentRoom].environmentList;
            gateList = rooms[currentRoom].gateList;
            foreach (IEnemy ene in enemyList)
            {
                if (Collision.Intersects(link.GetHurtbox(), ene.GetHurtbox()))
                {
                    Collision.CollisionChecker(ene, link);
                }
                foreach (IEnvironment bL in blockList)
                {
                    if (Collision.Intersects(bL.GetHurtbox(), ene.GetHurtbox()))
                    {
                        Collision.CollisionChecker(bL, ene);
                    }
                }
                foreach (ICollidable weapon in link.GetHitboxes())
                {
                    if (Collision.Intersects(weapon.GetHurtbox(), ene.GetHurtbox()))
                    {
                        Collision.CollisionChecker(weapon, ene);
                    }
                }
                foreach (IGate gate in gateList)
                {
                    if (Collision.Intersects(ene.GetHurtbox(), gate.GetHurtbox()))
                    {
                        Collision.CollisionChecker(gate, ene);
                    }
                }
            }

            enemyList.RemoveAll(enem => enemyDieList.Contains(enem));

            for(int i = 0; i < itemList.Count; i++)
            {
                if (Collision.Intersects(link.GetHurtbox(), itemList[i].GetHurtbox()))
                {
                    linkCommandHandler.GetItem(itemList[i]);
                    itemList.RemoveAt(i);
                    i--;
                }
            }

            foreach (IEnvironment bL in blockList)
            {
                if (Collision.Intersects(link.GetHurtbox(), bL.GetHurtbox())) Collision.CollisionChecker(link, bL);
                foreach (IEnvironment bL2 in blockList)
                {
                    if (typeof(PushBlock) == bL.GetType() && bL != bL2)
                    {
                        if (Collision.Intersects(bL2.GetHurtbox(), bL.GetHurtbox())) Collision.CollisionChecker(bL, bL2);
                    }
                }
                foreach (IGate g in gateList)
                {
                    if (Collision.Intersects(g.GetHurtbox(), bL.GetHurtbox())) Collision.CollisionChecker(bL, g);
                }
            }
            foreach (IGate gate in gateList)
            {
                if (Collision.Intersects(link.GetHurtbox(), gate.GetHurtbox()))
                {
                    if (gate.IsGateOpen())
                    {
                        roomTransitionHandler.HandleTransition(rooms[currentRoom], gate, link);
                    }
                    else
                    {
                        Collision.CollisionChecker(gate, link);
                        if (link.inventory.keys > 0 )
                        {
                            roomTransitionHandler.unlockDoor(gate, rooms,currentRoom);
                            link.inventory.keys--;
                        }
                    }
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            /*Clean display*/
            GraphicsDevice.Clear(Color.CornflowerBlue);

            /*Initialize sprite drawing*/
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);


            /*Draw everything*/
            if (gameState != 0)
            {
                if (!hud.Paused())
                {
                    rooms[currentRoom].Draw(spriteBatch);
                    link.Draw(spriteBatch);
                    currentRoomIndicator.Draw(spriteBatch);
                }

                hud.Draw(spriteBatch);
            }
            else
            {
                gameStateTransitionHandler.HandleTransition(gameState,FONT_SPRITESHEET,spriteBatch);
            }
            
            /*End drawing*/
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public static void ResetGame()
        {
            link.Reset();
            roomTransitionHandler.HandleTransitionAbs(17, link, 120, 140);
        }
    }
}