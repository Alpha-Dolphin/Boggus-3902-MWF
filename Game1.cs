using LOZ.Tools.Command;
using LOZ.Tools.PlayerObjects;
using LOZ.Tools.ItemObjects;
using LOZ.Tools.NPCObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using LOZ.Tools.Controller;

using System;


using LOZ.Tools;
using LOZ.Tools.EnvironmentObjects.Helpers;
using LOZ.Tools.LevelManager;

namespace LOZ
{
    public class Game1 : Game
    {
        private List<IEnemy> enemyList;
        private List<IEnvironment> blockList;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private ItemFactory itemFactory;
        private NPCFactory NPCFactory;
        private EnemySpriteFactory enemySpriteFactory;
        private IPlayer link;
        private KeyboardController controller;
        private MouseController mouseController;
        private ICommand linkCommandHandler;
        private EnvironmentCommandHandler environmentCommandHandler;
        private List<Room> rooms;
        public static int currentRoom = 2;

        private TextSprite currentRoomIndicator = new TextSprite();

        public static Texture2D LINK_SPRITESHEET;
        public static SpriteFont FONT;
        public static Texture2D ENVIRONMENT_SPRITESHEET;
        public static Texture2D REGULAR_ENEMIES;
        public static Texture2D BOSSES;
        public static Texture2D NPC_SPRITESHEET;
        public static Texture2D ITEM_SPRITESHEET;


        /* hanging onto to save time later
       private string creditsString = "Credits\nProgram Made By: Team BoggusMWF\nSprites from: https://www.spriters-resource.com/nes/legendofzelda/";
        */
        IEnemy enemy;



        /*Lists for various things to cycle through for sprint 2*/

        List<IEnvironment> environmentObjectList = new List<IEnvironment>();

        /*Factories for mass object generation*/

        EnvironmentFactory environmentFactory = new EnvironmentFactory();

        List<IItem> itemObjectList = new List<IItem>();


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
            _graphics.PreferredBackBufferHeight = 704;
            _graphics.ApplyChanges();

            BackgroundConstants.Initialize(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            link = new Link(LinkConstants.DEFAULT_X, LinkConstants.DEFAULT_Y, LinkConstants.DEFAULT_ITEMS, LinkConstants.MAX_HEALTH,
                LinkConstants.DEFAULT_STATE, LinkConstants.DEFAULT_DIRECTION,FONT);
            linkCommandHandler = new LinkCommand((Link) link);

            /*Declaration of controllers*/
            controller = new KeyboardController();
            mouseController = new MouseController();

            /*Here we will fill in the environment object list with one of every completed environment object*/
            foreach (Environment environment in Enum.GetValues(typeof(Environment)))
            {
                environmentObjectList.Add(environmentFactory.getEnvironment(environment));
            }

            LevelManager lm = new LevelManager();
            lm.initialize();            

            /*Here we create the command handler for the environment display management*/

            environmentCommandHandler = new EnvironmentCommandHandler();

            currentRoomIndicator.setPosition(0, 20);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D ItemSpriteSheet = Content.Load<Texture2D>(@"SpriteSheets\Items");
            Texture2D NPCSpriteSheet = Content.Load<Texture2D>(@"SpriteSheets\NPCs");
            itemFactory = new ItemFactory(ItemSpriteSheet);
            NPCFactory = new NPCFactory(0, NPCSpriteSheet);
            enemySpriteFactory = new();
            itemObjectList.Add(itemFactory.CreateItem(Item.Compass, 600, 400));
            NPCFactory.CreateNPC();
            enemy = enemySpriteFactory.CreateKeese();

            LINK_SPRITESHEET = Content.Load<Texture2D>(LinkConstants.LINK_SPRITESHEET_NAME);
            FONT = Content.Load<SpriteFont>(@"textFonts\MainText");
            currentRoomIndicator.setFont(FONT);
            ENVIRONMENT_SPRITESHEET = Content.Load<Texture2D>(Constants.DungeonSpriteSheetLocation);
            NPC_SPRITESHEET = Content.Load<Texture2D>(Constants.NPCSpriteSheetLocation);
            REGULAR_ENEMIES = Content.Load<Texture2D>(Constants.RegEnemySpriteSheetLocation);
            BOSSES = Content.Load<Texture2D>(Constants.BossesSpriteSheetLocation);
            ITEM_SPRITESHEET = Content.Load<Texture2D>(Constants.ItemSpriteSheetLocation);
        }

        protected override void Update(GameTime gameTime)
        {
            //UpdateCollision();

            /*
             * Update logic here
             */

            base.Update(gameTime);

            List<Keys> pressed = controller.Update();
            mouseController.Update();

            linkCommandHandler.Execute(pressed);

            if (enemySpriteFactory.Update(pressed, controller.held)) enemy = enemySpriteFactory.NewEnemy();
            else
            {
                enemy.Update(gameTime);
                enemy.Move(gameTime);
            }
            NPCFactory.Update(pressed, controller.held, gameTime);

            /*Here we update the environment placement for existing environment objects*/
            environmentCommandHandler.executeNewPressedOnly(pressed, controller.held);

            currentRoomIndicator.setText("Current room number: " + currentRoom);
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
                foreach (Rectangle weapon in link.GetHitboxes())
                {
                    if (Collision.Intersects(weapon, ene.GetHurtbox())) Collision.CollisionChecker(weapon, ene);
                }
            }
            foreach (IEnvironment bL in blockList)
            {
                if (Collision.Intersects(link.GetHurtbox(), bL.GetHurtbox())) Collision.CollisionChecker(link, bL);
            }

        }
    }

        protected override void Draw(GameTime gameTime)
        {
            /*Clean display*/
            GraphicsDevice.Clear(Color.CornflowerBlue);

            /*Initialize sprite drawing*/
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            /*Draw Environment*/
            //environmentObjectList[environmentCommandHandler.environmentBlockIndex].Draw(spriteBatch);
            
            //enemy.Draw(spriteBatch);
            
            /*Draw items*/
            /*itemFactory.CreateItem(Item.Clock, 600, 400);
            foreach(IItem i in itemObjectList)
            {
                i.Draw(spriteBatch);
            }*/
            
            /*Draw NPCs*/
            //NPCFactory.CreateNPC();
            //NPCFactory.Draw(spriteBatch);

            //spritesToDraw.Clear();
            /*Sprites to draw need to be in order in spritesToDrawList by here*/
            /*foreach (var item in spritesToDraw)
            {
                item.Draw(spriteBatch);
            }*/

            //environmentObjectList[environmentCommandHandler.environmentBlockIndex].Draw(spriteBatch);

            rooms[currentRoom].Draw(spriteBatch);
            link.Draw(spriteBatch);
            currentRoomIndicator.Draw(spriteBatch);

            //spriteBatch.Draw(Game1.ENVIRONMENT_SPRITESHEET, new Rectangle(0, 0, 256, 176), new Rectangle(521, 11, 256, 176), Color.White);
            //IEnemy test = rooms[currentRoom].enemyList[0];
            //test.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}