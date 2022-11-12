using LOZ.Tools.Command;
using LOZ.Tools.PlayerObjects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using LOZ.Tools.Controller;

using System;


using LOZ.Tools;

using LOZ.Tools.LevelManager;
using LOZ.Tools.EnvironmentObjects;
using LOZ.Tools.HUDObjects;

namespace LOZ
{
    public class Game1 : Game
    {
        private List<IEnemy> enemyList;
        public static List<IEnemy> enemyDieList = new();
        private List<IEnvironment> blockList;

        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private Link link;
        private KeyboardController controller;
        private MouseController mouseController;
        public static ICommand linkCommandHandler;

        private List<Room> rooms;
        public static int currentRoom = 4;
        private TextSprite currentRoomIndicator = new();

        //private HUD hud;

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

            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 704 + HUDConstants.TOP_HEIGHT;
            _graphics.ApplyChanges();

            EnvironmentConstants.Initialize(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            link = new Link(PlayerConstants.DEFAULT_X, PlayerConstants.DEFAULT_Y, PlayerConstants.DEFAULT_ITEMS, PlayerConstants.MAX_HEALTH,
                PlayerConstants.DEFAULT_STATE, PlayerConstants.DEFAULT_DIRECTION,FONT);
            linkCommandHandler = new LinkCommand((Link) link);

            /*Declaration of controllers*/
            controller = new KeyboardController();
            mouseController = new MouseController();


            lm = new LevelManager();
            lm.initialize();
            rooms = lm.RoomList;

            currentRoomIndicator.SetPosition(0, 20);

            //hud = new HUD(HUD_SPRITESHEET, ITEM_SPRITESHEET, FONT);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D ItemSpriteSheet = Content.Load<Texture2D>(@"SpriteSheets\Items");
            Texture2D NPCSpriteSheet = Content.Load<Texture2D>(@"SpriteSheets\NPCs");

            LINK_SPRITESHEET = Content.Load<Texture2D>(PlayerConstants.LINK_SPRITESHEET_NAME);
            FONT = Content.Load<SpriteFont>(@"textFonts\MainText");
            currentRoomIndicator.SetFont(FONT);
            ENVIRONMENT_SPRITESHEET = Content.Load<Texture2D>(Constants.DungeonSpriteSheetLocation);
            NPC_SPRITESHEET = Content.Load<Texture2D>(Constants.NPCSpriteSheetLocation);
            REGULAR_ENEMIES_SPRITESHEET = Content.Load<Texture2D>(Constants.RegEnemySpriteSheetLocation);
            BOSSES_SPRITESHEET = Content.Load<Texture2D>(Constants.BossesSpriteSheetLocation);
            ITEM_SPRITESHEET = Content.Load<Texture2D>(Constants.ItemSpriteSheetLocation);
            EXPLOSION = Content.Load<Texture2D>(Constants.ExplosionSpriteSheetLocation);
        }

        protected override void Update(GameTime gameTime)
        {
            UpdateCollision();

            /*
             * Update logic here
             */

            base.Update(gameTime);

            List<Keys> pressed = controller.Update();
            mouseController.Update();

            linkCommandHandler.Execute(pressed);
            rooms[currentRoom].Update(gameTime);
            foreach (IEnemy enemy in rooms[currentRoom].enemyList)
            {
                enemy.Update(gameTime);
                enemy.Move(gameTime);
            }

            //hud.Update(link, pressed);
            
            if (pressed.Contains(Keys.Q))
            {
                this.Exit();
            }

            currentRoomIndicator.SetText("Current room number: " + currentRoom);
        }

        private void UpdateCollision()
        {
            enemyList = rooms[currentRoom].enemyList;
            blockList = rooms[currentRoom].environmentList;
            foreach (IEnemy ene in enemyList)
            {
                if (Collision.Intersects(link.GetHurtbox(), ene.GetHurtbox())) Collision.CollisionChecker(ene, link);
                foreach (IEnvironment bL in blockList)
                {
                    if (Collision.Intersects(bL.GetHurtbox(), ene.GetHurtbox())) Collision.CollisionChecker(bL, ene);
                }
                foreach (ICollidable weapon in link.GetHitboxes())
                {
                    if (Collision.Intersects(weapon.GetHurtbox(), ene.GetHurtbox())) Collision.CollisionChecker(weapon, ene);
                }
            }
            enemyList.RemoveAll(enem => enemyDieList.Contains(enem));
            foreach (IEnvironment bL in blockList)
            {
                if (Collision.Intersects(link.GetHurtbox(), bL.GetHurtbox())) Collision.CollisionChecker(link, bL);
            }

        }
    

        protected override void Draw(GameTime gameTime)
        {
            /*Clean display*/
            GraphicsDevice.Clear(Color.CornflowerBlue);

            /*Initialize sprite drawing*/
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            /*Draw everything*/
            //if (!hud.Paused())
            {
                rooms[currentRoom].Draw(spriteBatch);
                link.Draw(spriteBatch);
                currentRoomIndicator.Draw(spriteBatch);
            }

            //hud.Draw(spriteBatch);

            /*End drawing*/
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}